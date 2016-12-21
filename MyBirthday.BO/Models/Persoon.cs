using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using MyBirthday.Communicatie.Models;

namespace MyBirthday.BO.Models
{
    public class Persoon: ViewModelBase, IPersoon
    {
        public Persoon(String voornaam, String achternaam, String groep, DateTime geboortedatum)
        {
            this.voornaam = voornaam;
            this.achternaam = achternaam;
            this.groep = Groep.createNew(groep);
            this.geboortedatum = geboortedatum;
        }
        
        public String voornaam { get; set; }
        public String achternaam { get; set; }
        public Groep groep { get; set; }
        public DateTime geboortedatum { get; set; }
        private Foto _foto;
        public Foto Foto {
            get { return _foto; }
            set {
                if (_foto == value) return;
                _foto = value;
                RaisePropertyChanged(() => Foto);
            }
        }
        public new String ToString
        { get { return toString(); } }

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
        private int _persoonid;

        public int PersoonId
        {
            get { return _persoonid; }
            set { _persoonid = value; }
        }

    }
}
