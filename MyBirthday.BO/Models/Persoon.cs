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
        #region Retrofitted Legacy Code
        public String voornaam {
            get { return Voornaam; }
            set { Voornaam = value; } }

        public String achternaam {
            get { return Achternaam; }
            set { Achternaam = value; }
        }
        public Groep groep { get; set; }
        public DateTime geboortedatum { get; set; }

        #endregion


        #region refactor

        private int _persoonId;

        public int PersoonId
        {
            get { return _persoonId; }
            set { if(_persoonId == value) return;
                _persoonId = value;
                RaisePropertyChanged(() => PersoonId);
            }
        }

        private String _voornaam;

        public String Voornaam
        {
            get { return _voornaam; }
            set { if(_voornaam == value) return;
                _voornaam = value;
                RaisePropertyChanged(() => Voornaam);
            }
        }

        private string _achternaam;

        public string Achternaam
        {
            get { return _achternaam; }
            set { _achternaam = value; }
        }

        private Groep _groep;

        public Groep Groep
        {
            get { return _groep; }
            set { _groep = value; }
        }




        private Foto _foto;
        public Foto Foto
        {
            get { return _foto; }
            set
            {
                if (_foto == value) return;
                _foto = value;
                RaisePropertyChanged(() => Foto);
            }
        }
        #endregion
        #region public functions
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
        #endregion

    }
}
