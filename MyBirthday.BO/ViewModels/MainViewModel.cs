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
            _verjaardagen = new Verjaardagen(); //model
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
            
        }

        public OverzichtLijst OverzichtLijst
        {
            get { return _overzichtLijst;}
            set { _overzichtLijst = value;}
        }

        public BijnaJarigLijst BijnaJarigLijst
        {
            get { return _bijnaJarigLijst; }
            set { _bijnaJarigLijst = value; }
        }

        
        public String  SelectedCategory
        {
            get { return _selectedCategory; }
            set { _selectedCategory = value; }
        }

       
        public Persoon SelectedPersoon
        {
            get { return _selectedPersoon; }
            set { _selectedPersoon = value; }
        }



    }
}
