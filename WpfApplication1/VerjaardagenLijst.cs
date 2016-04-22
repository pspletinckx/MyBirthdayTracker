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
        protected List<Persoon> gefilterdeLijst;

        public VerjaardagenLijst(ListBox uiLijst)
        {
            this.verjaardagen = uiLijst;
            gefilterdeLijst = new List<Persoon>();
        }
        public virtual void Subscribe(BirthdayArray provider)
        {
            cancellation = provider.Subscribe(this);
        }
        public virtual void Unsubscribe()
        {
            cancellation.Dispose();
            verjaardagen.Items.Clear();
            gefilterdeLijst.Clear();
            //System.Diagnostics.Debug.Write("unsubscribed");
        }
        public void OnCompleted()
        {
            verjaardagen.Items.Clear();
            gefilterdeLijst.Clear();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public  virtual void OnNext(Persoon value)
        {
            verjaardagen.Items.Add(value.toString());
            gefilterdeLijst.Add(value);
        }
        internal Persoon getFeestvarken(int selectedIndex)
        {
            return gefilterdeLijst.ElementAt(selectedIndex);
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
                //verjaardagen.Items.Add(persoon.toString());
                base.OnNext(persoon);
            }
        }

    }
}
