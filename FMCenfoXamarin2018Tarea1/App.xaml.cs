using System;
using System.Collections.Generic;
using System.Globalization;
using FMCenfoXamarin2018Tarea1.Models;
using Xamarin.Forms;
using System.Linq;
using Log = System.Diagnostics.Debug;

namespace FMCenfoXamarin2018Tarea1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Ejericicios de Tarea 1 del curso de Xamarin
            var clients = GetClients();

            var southClientsWithHighDebt = clients.Where( client => client.Area == "South" && client.DebtToCollect > 10000d );
            var oldestClientsWithM = from client in clients
                                     where client.CompanyName.ToUpper().Contains("E") && client.ClientSinceDate.Year < 2005 
                                     select client;
            var clientsInRetailAndEducation = clients.Where(client => client.Industry == "Retail" || client.Industry == "Education");

            PrintListInConsole( "Clients in South with more than 10k in debt.", southClientsWithHighDebt );
            PrintListInConsole("Clients before 2005 with letter M in name.", oldestClientsWithM);
            PrintListInConsole("Clients in Central area from the Education industry.", clientsInRetailAndEducation);

            MainPage = new FMCenfoXamarin2018Tarea1Page();
        }

        /// <summary>
        /// Prints the list in the Application Output window with a title.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="clients">Clients.</param>
        private void PrintListInConsole(string message, IEnumerable<ClientModel> clients)
        {
            Log.WriteLine("==============================================");
            Log.WriteLine($"Printing list: {message}");
            Log.WriteLine("Content:");
            foreach(var client in clients)
            {
                Log.WriteLine( client.ToString() );
            }
        }

        private List<ClientModel> GetClients()
        {
            var targetCulture = new CultureInfo("en-US");
            List<ClientModel> clients = new List<ClientModel>()
            {
                new ClientModel() { Id = 1001, Area="Central", 
                    CompanyName="MaxiPali", City="San Sebastian", 
                    ClientSinceDate=DateTime.Parse("03/20/2005", targetCulture), 
                    DebtToCollect=12682.5d, Industry="Retail"    },
                new ClientModel() { Id = 1002, Area="South",
                    CompanyName="ICE", City="San Pedro",
                    ClientSinceDate=DateTime.Parse("11/15/1990", targetCulture),
                    DebtToCollect=26877.1d, Industry="Energy"    },
                new ClientModel() { Id = 1003, Area="Central",
                    CompanyName="AyA", City="Hatillo",
                    ClientSinceDate=DateTime.Parse("10/05/1998", targetCulture),
                    DebtToCollect=18501.9d, Industry="Water"    },
                new ClientModel() { Id = 1004, Area="South",
                    CompanyName="Perimercados", City="San Sebastian",
                    ClientSinceDate=DateTime.Parse("07/18/2009", targetCulture),
                    DebtToCollect=7000.1d, Industry="Retail"    },
                new ClientModel() { Id = 1005, Area="Central",
                    CompanyName="MasXMenos", City="Barrio Mexico",
                    ClientSinceDate=DateTime.Parse("01/25/2015", targetCulture),
                    DebtToCollect=9850.5d, Industry="Retail"    },
                new ClientModel() { Id = 1006, Area="South",
                    CompanyName="AM/PM", City="Desamparados",
                    ClientSinceDate=DateTime.Parse("04/16/2011", targetCulture),
                    DebtToCollect=12000.5d, Industry="Retail"    },
                new ClientModel() { Id = 1007, Area="South",
                    CompanyName="Telecable", City="Desamparados",
                    ClientSinceDate=DateTime.Parse("04/16/2011", targetCulture),
                    DebtToCollect=22000d, Industry="TV/Internet"    },
                new ClientModel() { Id = 1008, Area="Central",
                    CompanyName="Cabletica", City="San Pedro",
                    ClientSinceDate=DateTime.Parse("07/30/1995", targetCulture),
                    DebtToCollect=22000d, Industry="TV/Internet"    },
                new ClientModel() { Id = 1009, Area="Central",
                    CompanyName="ULatina", City="San Pedro",
                    ClientSinceDate=DateTime.Parse("07/30/1995", targetCulture),
                    DebtToCollect=16800d, Industry="Education"    },
                new ClientModel() { Id = 1010, Area="Central",
                    CompanyName="Cenfotec", City="San Pedro",
                    ClientSinceDate=DateTime.Parse("05/30/2016", targetCulture),
                    DebtToCollect=2500d, Industry="Education"    },
                new ClientModel() { Id = 1011, Area="Central",
                    CompanyName="Fidelitas", City="San Pedro",
                    ClientSinceDate=DateTime.Parse("04/30/2014", targetCulture),
                    DebtToCollect=6500d, Industry="Education"    },
                new ClientModel() { Id = 1012, Area="Central",
                    CompanyName="Ulacit", City="Barrio Amon",
                    ClientSinceDate=DateTime.Parse("04/30/2014", targetCulture),
                    DebtToCollect=17500d, Industry="Education"    }
            };
            return clients;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
