using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBirthday.BO.Models
{
    public class FilterLijst : OverzichtLijst
    {
        private Groep filter;

        public FilterLijst( Groep category) : base()
        {
            this.filter = category;
        }
        public override void OnNext(Persoon value)
        {
            if (value.groep == filter)
            {
                base.OnNext(value);
            }
        }

    }
}
