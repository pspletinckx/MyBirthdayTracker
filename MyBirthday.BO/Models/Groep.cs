using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBirthday.BO.Models
{
    public class Groep
    {
        private Groep(String groupNaam)
        {
            GroepNaam = groupNaam;
        }
        private String groepNaam;

        public String GroepNaam
        {
            get { return groepNaam; }
            set { groepNaam = value; }
        }


        private static List<Groep> beschikbareGroepen = new List<Groep>();

        public static List<Groep> BeschikbareGroepen
        {
            get { return beschikbareGroepen; }
            set { beschikbareGroepen = value; }
        }

        public static Groep createNew (String gnaam)
        {
            //if groep string already exists
            Groep bestaande = BeschikbareGroepen.Find(g => g.GroepNaam == gnaam);
            if (bestaande != null) {
                return bestaande;
            }
            Groep nieuweGroep = new Groep(gnaam);
            BeschikbareGroepen.Add(nieuweGroep);
            return nieuweGroep;
            
        }
        
    }
}
