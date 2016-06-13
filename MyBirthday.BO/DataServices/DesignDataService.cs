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
            throw new NotImplementedException();
        }

        public bool DeletePersoon(int persoonid)
        {
            throw new NotImplementedException();
        }

        public List<IPersoon> GetPersonen()
        {
            return new List<IPersoon>()
            {
                new Persoon( "Jantje", "Vermeulen", "Familie", new DateTime(1991, 4, 25)),
                new Persoon("Els", "De Visser", "Vrienden", new DateTime(1960, 6, 10)),
                new Persoon("An", "De Brandt", "Algemeen", new DateTime(1920, 4, 24)),
                new Persoon("Josefien", "De Brandt", "Algemeen", new DateTime(1920, 4, 24))
            };
            throw new NotImplementedException();
        }

        public IPersoon GetPersoon(int persoonid)
        {
            throw new NotImplementedException();
        }
    }
}
