using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using MyBirthday.BO.Models;

namespace MyBirthday.BO.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private Verjaardagen _verjaardagen;
        private OverzichtLijst _overzichtLijst;
        private BijnaJarigLijst _bijnaJarigLijst;
        private String _selectedCategory;
        private Persoon _selectedPersoon;

        public MainViewModel()
        {
            _overzichtLijst = new OverzichtLijst(); //adapter
            _verjaardagen = Verjaardagen.getInstanceOf();
            _overzichtLijst.Subscribe(_verjaardagen);  //binding

            _bijnaJarigLijst = new BijnaJarigLijst(7); //7 dagen
            _bijnaJarigLijst.Subscribe(_verjaardagen); //bind
            //mock data
            Persoon Jan = new Persoon("Jantje", "Vermeulen", "Familie", new DateTime(1991, 4, 25));
            _verjaardagen.VoegVerjaardagToe(Jan);
            Persoon Els = new Persoon("Els", "De Visser", "Vrienden", new DateTime(1960, 6, 10));
            _verjaardagen.VoegVerjaardagToe(Els);
            Persoon Ann = new Persoon("An", "De Brandt", "Algemeen", new DateTime(1920, 4, 24));
            _verjaardagen.VoegVerjaardagToe(Ann);

            //test
            SelectedPersoon = Els;    
            
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

        
        public String  SelectedCategory
        {
            get { return _selectedCategory; }
            set {
                //if (value == "(leeg)" || value ==null)
                //{
                //    OverzichtLijst = new OverzichtLijst();
                //}
                //else
                //{
                //    OverzichtLijst = new FilterLijst(value);
                //}
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



    }
}
