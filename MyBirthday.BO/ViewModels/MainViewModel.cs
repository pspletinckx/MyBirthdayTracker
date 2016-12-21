using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using MyBirthday.BO.Models;
using MyBirthday.Communicatie.Data;
using MyBirthday.Communicatie.DataServices;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MyBirthday.BO.Messages;

namespace MyBirthday.BO.ViewModels
{
    public class MainViewModel : ViewModelBase,IDataOperations
    {

        private Verjaardagen _verjaardagen;
        private OverzichtLijst _overzichtLijst;
        private BijnaJarigLijst _bijnaJarigLijst;
        private Groep _selectedCategory;
        private Persoon _selectedPersoon;
        private IDataService _dataService;

        //public MainViewModel()
        //{
        //    _overzichtLijst = new OverzichtLijst(); //adapter
        //    _verjaardagen = Verjaardagen.getInstanceOf();
        //    _overzichtLijst.Subscribe(_verjaardagen);  //binding
        //    beschikbareGroepen = Groep.BeschikbareGroepen;

        //    _bijnaJarigLijst = new BijnaJarigLijst(7); //7 dagen
        //    _bijnaJarigLijst.Subscribe(_verjaardagen); //bind
        //    //mock data
        //    Persoon Jan = new Persoon("Jantje", "Vermeulen", "Familie", new DateTime(1991, 4, 25));
        //    _verjaardagen.VoegVerjaardagToe(Jan);
        //    Persoon Els = new Persoon("Els", "De Visser", "Vrienden", new DateTime(1960, 6, 10));
        //    _verjaardagen.VoegVerjaardagToe(Els);
        //    Persoon Ann = new Persoon("An", "De Brandt", "Algemeen", new DateTime(1920, 4, 24));
        //    _verjaardagen.VoegVerjaardagToe(Ann);
        //    Persoon Josefien = new Persoon("Josefien", "De Brandt", "Algemeen", new DateTime(1920, 4, 24));
        //    _verjaardagen.VoegVerjaardagToe(Josefien);
        //    //test
        //    SelectedPersoon = Els;

        //}

        public ICommand SaveCommand { get; set; }
        private void InitCommands()
        {
            SaveCommand = new RelayCommand(Save);
        }
        public MainViewModel (IDataService dataService)
        {
            _dataService = dataService;
            _overzichtLijst = new OverzichtLijst(); //adapter
            _bijnaJarigLijst = new BijnaJarigLijst(7); //7 dagen
            _verjaardagen = Verjaardagen.getInstanceOf();//todo fix me
            _overzichtLijst.Subscribe(_verjaardagen);  //binding
            _bijnaJarigLijst.Subscribe(_verjaardagen); //binding
            foreach (Persoon persoon in dataService.GetPersonen())
            {
                _verjaardagen.VoegVerjaardagToe(persoon);
            }
            InitCommands();

            //Messenger.Default.Register<UpdatePersoonCollectionMesssage>(
            //    this, (list) =>
            //    {
            //        list.UpdatePersoonCollection;
            //    }

            //TODO Analyse
        }



        public OverzichtLijst OverzichtLijst
        {
            get { return _overzichtLijst;}
            set {
                if (value == _overzichtLijst) return;
                _overzichtLijst = value;
                RaisePropertyChanged(() => OverzichtLijst); }
        }

        public BijnaJarigLijst BijnaJarigLijst
        {
            get { return _bijnaJarigLijst; }
            set { _bijnaJarigLijst = value; }
        }

        
        public Groep  SelectedCategory
        {
            get { return _selectedCategory; }
            set {
                Groep.createNew("(leeg)");
                RaisePropertyChanged(() => BeschikbareGroepen); //Waarom veranderd de view niet?

                if (value.GroepNaam == "(leeg)" || value == null)
                {
                    OverzichtLijst = new OverzichtLijst();
                }
                else
                {
                    _overzichtLijst.Unsubscribe();
                    OverzichtLijst = new FilterLijst(value);
                    _overzichtLijst.Subscribe(_verjaardagen);
                }
                if (value == _selectedCategory) return;
                _selectedCategory = value;
                RaisePropertyChanged(() => SelectedCategory);
            }
        }

       
        public Persoon SelectedPersoon
        {
            get { return _selectedPersoon; }
            set {
                if (_selectedPersoon == value) return; 
                _selectedPersoon = value;
                RaisePropertyChanged(() => SelectedPersoon);
            }
        }

        private List<Groep> beschikbareGroepen;

        public List<Groep> BeschikbareGroepen
        {
            get {
                return Groep.BeschikbareGroepen;
            }
            set {
                if (value == beschikbareGroepen) return;
                beschikbareGroepen = value;
                RaisePropertyChanged(() => BeschikbareGroepen);
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
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
