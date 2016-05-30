using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace MyBirthday.BO.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            // declaration of Ioc container
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            // registratie van alle Viewmodels
            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel OverzichLijst
        {
            get { return SimpleIoc.Default.GetInstance<MainViewModel>(); }
        }

        public static void Cleanup()
        {

        }
    }
}
