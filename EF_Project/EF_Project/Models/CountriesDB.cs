using EF_Project.DB_Context;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EF_Project.Models
{
    public class CountriesDB
    {
        public CountriesDBContext Context { get; set; }

        public CountriesDB()
        {
            Context = new CountriesDBContext();
            {
                //GovernmentForms govform1 = new GovernmentForms { Form = "Democracy" };
                //GovernmentForms govform2 = new GovernmentForms { Form = "Monarchy" };
                //GovernmentForms govform3 = new GovernmentForms { Form = "Totalitarianism" };
                //GovernmentForms govform4 = new GovernmentForms { Form = "Capitalism" };
                //GovernmentForms govform5 = new GovernmentForms { Form = "Imperialism" };

                //Country country1 = new Country()
                //{
                //    Name = "Japan",
                //    Year = 660,
                //    GovernmentForms = govform2,
                //    Url = "https://img.tourister.ru/files/1/5/0/0/4/4/0/1500440.png",
                //    Population = 124840000,
                //    Area = 377975,
                //    GDP = 6139000
                //};

                //Country country2 = new Country()
                //{
                //    Name = "South Korea",
                //    Year = 1948,
                //    GovernmentForms = govform1,
                //    Url = "https://i.travel.ru/images2/2007/04/object108793/124_000_south_korea.jpg",
                //    Population = 51966948,
                //    Area = 100363,
                //    GDP = 2924000
                //};


                //Country country3 = new Country()
                //{
                //    Name = "Azerbaijan",
                //    Year = 1918,
                //    GovernmentFormID = 3,
                //    Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/38/Azerbaijan_location_map.svg/2560px-Azerbaijan_location_map.svg.png",
                //    Population = 10353296,
                //    Area = 86600,
                //    GDP = 18310,
                //    HeadOfState = "Ilham Aliyev",
                //    Anthem = "Azerbaijan, Azerbaijan, ey gehreman oglu"
                //};

                //Context.GovernmentForms.AddRange(govform1, govform2, govform3, govform4, govform5);
                //Context.Countries.AddRange(country1, country2);

                //Context.Countries.Add(country3);

                //Context.SaveChanges();
            }
        }
    }
}
