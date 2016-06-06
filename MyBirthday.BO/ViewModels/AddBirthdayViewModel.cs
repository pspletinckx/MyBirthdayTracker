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

        public Verjaardagen Verjaardagen
        {
            get { return _verjaardagen; }
            set { _verjaardagen = value; }
        }
        private Persoon nieuwePersoon;

        public Persoon NieuwePersoon
        {
            get { return nieuwePersoon; }
            set { nieuwePersoon = value; }
        }
    }
}
