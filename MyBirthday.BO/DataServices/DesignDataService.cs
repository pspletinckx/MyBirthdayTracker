using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBirthday.Communicatie.DataServices;
using MyBirthday.BO.Models;
using MyBirthday.Communicatie.Models;

namespace MyBirthday.BO.DataServices
{
    public class DesignDataService : IDataService
    {

        public void AddPersoon(IPersoon persoon)
        {
            System.Diagnostics.Debug.WriteLine("Persoon wordt gesaved : " + persoon.ToString());
        }

        public bool DeletePersoon(int persoonid)
        {
            throw new NotImplementedException();
        }

        public List<IPersoon> GetPersonen()
        {
            //JsonDataService jsonservice = new JsonDataService();
            //jsonservice.AddPersoon(GetPersonen().First<IPersoon>());

            return new List<IPersoon>()
            {
                new Persoon( "Sam", "Van Staebroek", "Familie", new DateTime(1991, 7, 12)),
                new Persoon( "Piet", "Van Staebroek", "Familie", new DateTime(1991, 7, 2)),
                new Persoon( "Jantje", "Vermeulen", "Familie", new DateTime(1991, 6, 25)),
                new Persoon("Els", "De Visser", "Vrienden", new DateTime(1960, 6, 20)),
                new Persoon("An", "De Brandt", "Algemeen", new DateTime(1920, 4, 24)),
                new Persoon("Josefien", "De Brandt", "Algemeen", new DateTime(1920, 4, 24))
            };
        }

        public IPersoon GetPersoon(int persoonid)
        {
            throw new NotImplementedException();
        }
    }
}
