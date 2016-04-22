using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApplication1
{
    class VerjaardagenLijst : IObserver<Persoon>
    {
        protected ListBox verjaardagen;
        protected IDisposable cancellation;

        public VerjaardagenLijst(ListBox uiLijst)
        {
            this.verjaardagen = uiLijst;
        }
        public virtual void Subscribe(BirthdayArray provider)
        {
            cancellation = provider.Subscribe(this);
        }
        public virtual void Unsubscribe()
        {
            cancellation.Dispose();
            verjaardagen.Items.Clear();
            System.Diagnostics.Debug.Write("unsubscribed");
        }
        public void OnCompleted()
        {
            verjaardagen.Items.Clear();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public  virtual void OnNext(Persoon value)
        {
            verjaardagen.Items.Add(value.toString());
        }
    }
    class FilterLijst : VerjaardagenLijst {
        private String filter;

        public FilterLijst(ListBox uiLijst,String category) : base(uiLijst)
        {
            this.filter = category;
        }
        public override void OnNext(Persoon value)
        {
            System.Diagnostics.Debug.Write(value.groep + "" + filter);
            if (value.groep == filter)
            {
                base.OnNext(value);
            }
        }

    }
    class BijnaJarigLijst : VerjaardagenLijst
    {
        private int dagen;
        public BijnaJarigLijst(ListBox uiLijst, int dagen): base(uiLijst)
        {
            this.dagen = dagen;
        }
        public override void OnNext(Persoon persoon)
        {
            DateTime nextBirthday = persoon.getNextBirthday();
            DateTime vandaag = DateTime.Today;
            DateTime voor = DateTime.Today.AddDays(dagen);

            if (nextBirthday> vandaag && nextBirthday < voor )
            {
                verjaardagen.Items.Add(persoon.toString());
            }
        }

    }
}
