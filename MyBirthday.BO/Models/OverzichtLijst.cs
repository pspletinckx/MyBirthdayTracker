using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBirthday.BO.Models
{
    class OverzichtLijst : IObserver<Persoon>
    {
        
        protected IDisposable cancellation;
        protected List<Persoon> gefilterdeLijst;

        public OverzichtLijst()
        {
            gefilterdeLijst = new List<Persoon>();
        }
        public virtual void Subscribe(Verjaardagen provider)
        {
            cancellation = provider.Subscribe(this);
        }
        public virtual void Unsubscribe()
        {
            cancellation.Dispose();
            gefilterdeLijst.Clear();
            //System.Diagnostics.Debug.Write("unsubscribed");
        }
        public void OnCompleted()
        {
            gefilterdeLijst.Clear();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public virtual void OnNext(Persoon value)
        {
            verjaardagen.Items.Add(value.toString());
            gefilterdeLijst.Add(value);
        }
        internal Persoon getFeestvarken(int selectedIndex)
        {
            return gefilterdeLijst.ElementAt(selectedIndex);
        }
    }
}
