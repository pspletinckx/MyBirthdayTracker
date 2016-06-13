using GalaSoft.MvvmLight;
using MyBirthday.BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBirthday.BO.ViewModels
{
    public class AddBirthdayViewModel : ViewModelBase
    {
        private Verjaardagen _verjaardagen;
        public AddBirthdayViewModel()
        {
            _verjaardagen = Verjaardagen.getInstanceOf();
        }

        public Verjaardagen Verjaardagen
        {
            get { return _verjaardagen; } //er zijn altijd verjaardagen
            set {
                if (_verjaardagen == value) return;
                _verjaardagen = value;
                RaisePropertyChanged(() => Verjaardagen); }
        }
        private Persoon nieuwePersoon;

        public Persoon NieuwePersoon
        {
            get {
                return nieuwePersoon; // don't crash
                Persoon tempPersoon = new Persoon("Voornaam", "Achternaam", "Algemeen", new DateTime());
                return tempPersoon;

                return nieuwePersoon ?? (nieuwePersoon = new Persoon("Voornaam","Achternaam","Algemeen", new DateTime())); } //Todo: Dit is een foute manier van een object aan te maken

            set {
                if (nieuwePersoon == value) return;

                nieuwePersoon = value;
                RaisePropertyChanged(() => NieuwePersoon);
            }
        }
    }
}
