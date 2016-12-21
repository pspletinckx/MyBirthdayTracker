using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MyBirthday.BO.Models;
using MyBirthday.Communicatie.Data;
using MyBirthday.Communicatie.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyBirthday.BO.ViewModels
{
    public class AddBirthdayViewModel : ViewModelBase,IDataOperations
    {
        private Verjaardagen _verjaardagen;
        public ICommand SaveCommand { get; set; }
        private void InitCommands()
        {
            SaveCommand = new RelayCommand(Save);
        }

       
        public AddBirthdayViewModel(IDataService dataService)
        {
            _dataService = dataService;
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
            get
            {
                // return nieuwePersoon; // don't crash
                //Persoon tempPersoon = new Persoon("Voornaam", "Achternaam", "Algemeen", new DateTime());
                //return tempPersoon;

                return nieuwePersoon ?? (nieuwePersoon = new Persoon("Voornaam","Achternaam","Algemeen", new DateTime()));  //Todo: Dit is een foute manier van een object aan te maken
            }

            set {
                if (nieuwePersoon == value) return;

                nieuwePersoon = value;
                RaisePropertyChanged(() => NieuwePersoon);
            }
        }

        private List<Groep> beschikbareGroepen;
        private IDataService _dataService;

        public List<Groep> BeschikbareGroepen
        {
            get
            {
                return Groep.BeschikbareGroepen;
            }
            set
            {
                if (value == beschikbareGroepen) return;
                beschikbareGroepen = value;
                RaisePropertyChanged(() => BeschikbareGroepen);
            }
        }
        public void Save()
        {
            _dataService.AddPersoon(NieuwePersoon);
            NieuwePersoon = new Persoon("Voornaam", "Achternaam", "Algemeen", new DateTime());
        }

        public void Search()
        {
            throw new NotImplementedException();
        }

        public void Save(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
