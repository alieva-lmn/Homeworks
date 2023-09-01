using GalaSoft.MvvmLight;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PaintProject.View.DrawingView;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using static System.Reflection.Metadata.BlobBuilder;
using System.Windows.Ink;
using System.ComponentModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.LinkLabel;
using PaintProject.Services.Interfaces;
using PaintProject.Model;
using System.Windows.Forms;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;
using PrintDialog = System.Windows.Controls.PrintDialog;
using GalaSoft.MvvmLight.Messaging;
using PaintProject.Messages;
using Microsoft.VisualBasic.ApplicationServices;
using User = PaintProject.Model.User;
using Server.FTP;

namespace PaintProject.ViewModel
{
    public class DrawingViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly IShapeDrawService _shapeDrawService;
        private readonly IPictureSaverService _pictureSaverService;
        private readonly INavigationService _navigationService;
        private readonly IUserManageService _userManageService;
        private readonly IMessenger _messenger;
        public enum ShapeType { None, Rectangle, Circle, Line };

        private InkCanvasEditingMode _currentMode;
        public InkCanvasEditingMode CurrentMode
        {
            get { return _currentMode; }
            set
            {
                _currentMode = value;
                RaisePropertyChanged(nameof(CurrentMode));
            }
        }

        private DrawingAttributes _inkDrawingAttributes = new();
        public DrawingAttributes InkDrawingAttributes
        {
            get { return _inkDrawingAttributes; }
            set
            {
                _inkDrawingAttributes = value;
                RaisePropertyChanged(nameof(InkDrawingAttributes));
            }
        }

        private SolidColorBrush _currentColor = Brushes.Black;
        public SolidColorBrush CurrentColor
        {
            get { return _currentColor; }
            set
            {
                _currentColor = value;
                RaisePropertyChanged(nameof(CurrentColor));
            }
        }

        private ShapeType _currentShape;
        public ShapeType CurrentShape
        {
            get { return _currentShape; }
            set
            {
                _currentShape = value;
                RaisePropertyChanged(nameof(CurrentShape));
            }
        }

        private Point startPoint;

        private bool isDrawingLine = false;
        private bool isSaved = false;

        public Picture Picture { get; set; } = new();
        //public Picture SelectedPic { get; set; } = new();
        public User User { get; set; } = new();


        public DrawingViewModel(IShapeDrawService shapeDrawService, IPictureSaverService pictureSaverService, INavigationService navigationService, IMessenger messenger, IUserManageService userManageService)
        {
            _shapeDrawService = shapeDrawService;
            _pictureSaverService = pictureSaverService;
            _navigationService = navigationService;
            _messenger = messenger;
            _userManageService = userManageService;

            _messenger.Register<DataMessage>(this, message =>
            {
                if (message.Data.GetType().Name == nameof(User))
                    User = message.Data as User;
                else if (message.Data.GetType().Name == nameof(Picture))
                    Picture = message.Data as Picture;

            });
        }


        // DRAWING MANIPULATIONS

        public RelayCommand<object> SetShapeCommand
        {
            get => new(shape =>
            {
                if (shape != null)
                {
                    CurrentMode = InkCanvasEditingMode.None;

                    if (shape.ToString() == "Rectangle")
                    {           
                        CurrentShape = ShapeType.Rectangle;
                    }
                    else if (shape.ToString() == "Circle")
                    {
                        CurrentShape = ShapeType.Circle;
                    }
                    else if (shape.ToString() == "Line")
                    {
                        CurrentShape = ShapeType.Line;
                    }
                }
            });
        }

        public RelayCommand<InkCanvas> CanvasMouseDownCommand
        {
            get => new(inkCanvas =>
            {
                if (CurrentMode == InkCanvasEditingMode.None)
                {
                    if (Mouse.LeftButton == MouseButtonState.Pressed)
                    {
                        Point position = Mouse.GetPosition(inkCanvas);

                        if (CurrentShape == ShapeType.Rectangle)
                        {
                            inkCanvas.Children.Add(_shapeDrawService.AddRectangle(position, InkDrawingAttributes));
                        }
                        else if (CurrentShape == ShapeType.Circle)
                        {
                            inkCanvas.Children.Add(_shapeDrawService.AddCircle(position, InkDrawingAttributes));
                        }
                        else if (CurrentShape == ShapeType.Line)
                        {
                            if (!isDrawingLine)
                            {
                                startPoint = position;
                                isDrawingLine = true;
                            }
                            else
                            {
                                isDrawingLine = false;
                                inkCanvas.Children.Add(_shapeDrawService.AddLine(startPoint, position, InkDrawingAttributes));
                            }
                        }
                    }
                }
            });
        }

        public RelayCommand PenButton
        {
            get => new(() =>
            {
                CurrentMode = InkCanvasEditingMode.Ink;
            });
        }

        public RelayCommand EraserButton
        {
            get => new RelayCommand(() =>
            {
                CurrentMode = InkCanvasEditingMode.EraseByPoint;
            });
        }

        public RelayCommand SelectionButton
        {
            get => new(() =>
            {
                CurrentMode = InkCanvasEditingMode.Select;
            });
        }

        public RelayCommand ColorButton
        {
            get => new(() =>
            {
                var colorDialog = new System.Windows.Forms.ColorDialog();

                if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    CurrentColor = new SolidColorBrush(Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B));
                    InkDrawingAttributes.Color = CurrentColor.Color;
                }
            });
        }

        public RelayCommand TextButton
        {
            get => new(() =>
            {
                
            });
        }


        // FILE MANIPULATIONS

        public RelayCommand OpenFile
        {
            get => new(() =>
            {
                _navigationService.NavigateTo<GreetingViewModel>(User);
            });
        }

        public RelayCommand<InkCanvas> SaveFile
        {
            get => new(inkCanvas =>
            {
                
                var ftppath = FTP_Server.CreateLocalDirectory(User.Username);
                var filepath = $"{User.Username}/{Picture.ProjectName}";

                _pictureSaverService.SaveInkCanvasToFTPServer(inkCanvas, filepath, Picture.ProjectName);

                Picture.PicturePath = $"{ftppath}/{Picture.ProjectName}.png";

                if (User.PicCollection == null)
                {
                    User.PicCollection = new();
                    User.PicCollection.Add(Picture);
                }
                else
                    User.PicCollection.Add(Picture);

                _userManageService.UpdateUserAsync(User);

                isSaved = true;

            });
        }

        public RelayCommand<InkCanvas> ExportFile
        {
            get => new(inkCanvas =>
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = "JPEG Files (*.jpg)|*.jpg|All files (*.*)|*.*";
                saveFileDialog.FileName = Picture.ProjectName;

                if (saveFileDialog.ShowDialog() == true)
                {
                    string filePath = saveFileDialog.FileName;
                    _pictureSaverService.SaveInkCanvasToImage(inkCanvas, filePath);
                }
            });
        }

        public RelayCommand<InkCanvas> SendFileToEmail
        {
            get => new(inkCanvas =>
            {
                
            });
        }

        public RelayCommand<InkCanvas> PrintFile
        {
            get => new(inkCanvas =>
            {
                PrintDialog printDialog = new PrintDialog();

                if (printDialog.ShowDialog() == true)
                {
                    DrawingVisual drawingVisual = new DrawingVisual();
                    using (DrawingContext drawingContext = drawingVisual.RenderOpen())
                    {
                        VisualBrush visualBrush = new VisualBrush(inkCanvas);
                        drawingContext.DrawRectangle(visualBrush, null, new Rect(new Point(), inkCanvas.RenderSize));
                    }

                    printDialog.PrintVisual(drawingVisual, "InkCanvas Printing");
                }
            });
        }


        //EXIT

        public RelayCommand<InkCanvas> SignOutCommand //peresmotret
        {
            get => new(inkCanvas =>
            {
                if (!isSaved)
                {
                    var res = System.Windows.MessageBox.Show($"Do you want to save your work?\nThere are unsaved changes in '{Picture.ProjectName}'.", "WARNING", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

                    switch (res)
                    {
                        case MessageBoxResult.Yes:
                            SaveFile.Execute(inkCanvas);
                            break;
                        case MessageBoxResult.No:
                            break;
                    }
                    LoginViewModel.isLoggedIn = false;
                    _navigationService.NavigateTo<LoginViewModel>();
                }
                LoginViewModel.isLoggedIn = false;
                _navigationService.NavigateTo<LoginViewModel>();
            });
        }
    }
}
