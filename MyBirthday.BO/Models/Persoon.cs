using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace MyBirthday.BO.Models
{
    public class Persoon: ViewModelBase
    {
        public Persoon(String voornaam, String achternaam, String groep, DateTime geboortedatum)
        {
            this.voornaam = voornaam;
            this.achternaam = achternaam;
            this.groep = Groep.createNew(groep);
            this.geboortedatum = geboortedatum;
        }
        
        public String voornaam { get; private set; }
        public String achternaam { get; private set; }
        public Groep groep { get; private set; }
        public DateTime geboortedatum { get; private set; }
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
    }
}
