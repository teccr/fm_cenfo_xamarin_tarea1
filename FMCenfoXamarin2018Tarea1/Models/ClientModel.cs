using System;
namespace FMCenfoXamarin2018Tarea1.Models
{
    public class ClientModel
    {
        public int Id
        {
            get;
            set;
        }

        public string CompanyName
        {
            get;
            set;
        }

        public string City
        {
            get;
            set;
        }

        public double DebtToCollect
        {
            get;
            set;
        }

        public DateTime ClientSinceDate
        {
            get;
            set;
        }

        public string Area
        {
            get;
            set;
        }

        public string Industry
        {
            get;
            set;
        }

		public override string ToString()
		{
            return $"Id: {Id}, Name: {CompanyName}, Area: {Area}, Industry: {Industry}, City: {City}, Debt: ${DebtToCollect}";
		}
	}
}
