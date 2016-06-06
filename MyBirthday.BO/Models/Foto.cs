using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBirthday.BO.Models
{
    public class Foto:ViewModelBase
    {
        //locatie foto
        private String uri;

        public String Uri
        {
            get { return uri; }
            set {
                if (uri == value) return;
                uri = value;
                RaisePropertyChanged(() => Uri);
            }
        }
        //eventuele bitmap
        //eventuele Meta
    }
}
