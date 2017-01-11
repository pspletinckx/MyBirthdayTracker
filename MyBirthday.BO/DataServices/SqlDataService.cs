using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBirthday.Communicatie.DataServices;
using MyBirthday.Communicatie.Models;
using System.Data;
using MyBirthday.DAL;
using MyBirthday.BO.Models;

namespace MyBirthday.BO.DataServices
{
    class SqlDataService : IDataService
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
            try
            {
                var results = (from DataRow rij in PersoonDAL.GetItems().Rows
                               select new Persoon()
                               {
                                   voornaam = rij["Firstname"].ToString(),
                                   achternaam = rij["Lastname"].ToString(),
                                   groep = rij["CategoryId"],
                                   geboortedatum = rij["DateOfBirth"]
                               })
            }
        }

        public IPersoon GetPersoon(int persoonid)
        {
            try
            {
                var results = (from DataRow rij in PersoonDAL.GetItems().Rows
                               select new Persoon()
                               {
                                    //TODO
                                    throw new NotImplementedException();
                                }
            }
                                )
            }
        }
    }
}
