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
        public MainViewModel()
        {
            _overzichtLijst = new OverzichtLijst(); //adapter
            _verjaardagen = new Verjaardagen(); //model
            _overzichtLijst.Subscribe(_verjaardagen);  //binding

            BijnaJarigLijst bijnaJarigLijst = new BijnaJarigLijst(7); //7 dagen
            bijnaJarigLijst.Subscribe(_verjaardagen);

            Persoon Jan = new Persoon("Jantje", "Vermeulen", "Familie", new DateTime(1991, 4, 25));
            _verjaardagen.VoegVerjaardagToe(Jan);
            Persoon Els = new Persoon("Els", "De Visser", "Vrienden", new DateTime(1960, 5, 20));
            _verjaardagen.VoegVerjaardagToe(Els);
            Persoon Ann = new Persoon("An", "De Brandt", "Algemeen", new DateTime(1920, 4, 24));
            _verjaardagen.VoegVerjaardagToe(Ann);
            System.Diagnostics.Debug.WriteLine(Ann.toString());
        }

        public OverzichtLijst Overzichtlijst
        {
            get { return _overzichtLijst;}
            set { _overzichtLijst = value;}
        }

    }
}
