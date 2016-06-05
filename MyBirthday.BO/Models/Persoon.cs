using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBirthday.BO.Models
{
    public class Persoon
    {
        public Persoon(String voornaam, String achternaam, String groep, DateTime geboortedatum)
        {
            this.voornaam = voornaam;
            this.achternaam = achternaam;
            this.groep = groep;
            this.geboortedatum = geboortedatum;
        }
        public String voornaam { get; private set; }
        public String achternaam { get; private set; }
        public String groep { get; private set; }
        public DateTime geboortedatum { get; private set; }
        public String ToString
        {
            get
            {
                return toString();
            }
        }

        public String toString()
        {
            return voornaam + " " + achternaam + " " + getNextBirthdayAge() + "j ";
        }
        public int getAge()
        {
            var now = DateTime.Today;
            int age = now.Year - geboortedatum.Year;
            if (geboortedatum > now.AddYears(-age)) age--;
            return age;
        }
        public int getNextBirthdayAge()
        {
            return getAge() + 1;
        }
        public DateTime getNextBirthday()
        {
            DateTime result = geboortedatum; //struct
            while (result < DateTime.Now && geboortedatum < DateTime.Now)
            {
                result = result.AddYears(1);
            }
            return result;
        }
    }
}
