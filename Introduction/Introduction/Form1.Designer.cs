﻿namespace Introduction
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.removeButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.peopleListBox = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.nameLabel = new System.Windows.Forms.Label();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ageTextBox = new System.Windows.Forms.TextBox();
            this.imgLabel = new System.Windows.Forms.Label();
            this.imgButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(536, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 504);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.removeButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 436);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(290, 68);
            this.panel3.TabIndex = 2;
            // 
            // removeButton
            // 
            this.removeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.removeButton.Location = new System.Drawing.Point(0, 0);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(290, 68);
            this.removeButton.TabIndex = 0;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.peopleListBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(290, 430);
            this.panel2.TabIndex = 1;
            // 
            // peopleListBox
            // 
            this.peopleListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.peopleListBox.FormattingEnabled = true;
            this.peopleListBox.ItemHeight = 20;
            this.peopleListBox.Location = new System.Drawing.Point(0, 0);
            this.peopleListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.peopleListBox.Name = "peopleListBox";
            this.peopleListBox.Size = new System.Drawing.Size(290, 430);
            this.peopleListBox.TabIndex = 0;
            this.peopleListBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.peopleListBox_MouseClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.nameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.surnameLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.nameTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.surnameTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.addButton, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ageTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.imgLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.imgButton, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(536, 504);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(108, 44);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(52, 20);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            // 
            // surnameLabel
            // 
            this.surnameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.Location = new System.Drawing.Point(99, 153);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(70, 20);
            this.surnameLabel.TabIndex = 1;
            this.surnameLabel.Text = "Surname:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Location = new System.Drawing.Point(271, 41);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(262, 27);
            this.nameTextBox.TabIndex = 2;
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.surnameTextBox.Location = new System.Drawing.Point(271, 150);
            this.surnameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(262, 27);
            this.surnameTextBox.TabIndex = 3;
            // 
            // addButton
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.addButton, 2);
            this.addButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addButton.Location = new System.Drawing.Point(3, 371);
            this.addButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(530, 59);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Age:";
            // 
            // ageTextBox
            // 
            this.ageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ageTextBox.Location = new System.Drawing.Point(271, 242);
            this.ageTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.Size = new System.Drawing.Size(262, 27);
            this.ageTextBox.TabIndex = 6;
            // 
            // imgLabel
            // 
            this.imgLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgLabel.AutoSize = true;
            this.imgLabel.Location = new System.Drawing.Point(108, 320);
            this.imgLabel.Name = "imgLabel";
            this.imgLabel.Size = new System.Drawing.Size(51, 20);
            this.imgLabel.TabIndex = 7;
            this.imgLabel.Text = "Image";
            // 
            // imgButton
            // 
            this.imgButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgButton.Location = new System.Drawing.Point(355, 315);
            this.imgButton.Name = "imgButton";
            this.imgButton.Size = new System.Drawing.Size(94, 29);
            this.imgButton.TabIndex = 8;
            this.imgButton.Text = "Browse";
            this.imgButton.UseVisualStyleBackColor = true;
            this.imgButton.Click += new System.EventHandler(this.imgButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 504);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private ListBox peopleListBox;
        private TableLayoutPanel tableLayoutPanel1;
        private Label nameLabel;
        private Label surnameLabel;
        private TextBox nameTextBox;
        private TextBox surnameTextBox;
        private Button addButton;
        private Label label1;
        private TextBox ageTextBox;
        private Label imgLabel;
        private Button imgButton;
        private Panel panel3;
        private Button removeButton;
        private Panel panel2;
    }
}