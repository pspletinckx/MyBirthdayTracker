using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBirthday.BO.Models
{
    class BijnaJarigLijst : OverzichtLijst
    {
        private int dagen;
        public BijnaJarigLijst( int dagen) : base()
        {
            this.dagen = dagen;
        }
        public override void OnNext(Persoon persoon)
        {
            DateTime nextBirthday = persoon.getNextBirthday();
            DateTime vandaag = DateTime.Today;
            DateTime voor = DateTime.Today.AddDays(dagen);

            if (nextBirthday > vandaag && nextBirthday < voor)
            {
                //verjaardagen.Items.Add(persoon.toString());
                base.OnNext(persoon);
            }
        }

    }
}
