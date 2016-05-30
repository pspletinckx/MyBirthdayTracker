using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBirthday.BO.Models
{
    public class OverzichtLijst : ViewModelBase,IObserver<Persoon>
    {
        
        protected IDisposable cancellation;
        protected List<Persoon> _gefilterdeLijst;

        public OverzichtLijst()
        {
            _gefilterdeLijst = new List<Persoon>();
        }
        public List <Persoon> GefilterdeLijst
        {
            get; set;
        }

        public virtual void Subscribe(Verjaardagen provider)
        {
            cancellation = provider.Subscribe(this);
        }
        public virtual void Unsubscribe()
        {
            cancellation.Dispose();
            _gefilterdeLijst.Clear();
            //System.Diagnostics.Debug.Write("unsubscribed");
        }
        public void OnCompleted()
        {
            _gefilterdeLijst.Clear();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public virtual void OnNext(Persoon value)
        {
            _gefilterdeLijst.Add(value);
        }
        internal Persoon getFeestvarken(int selectedIndex)
        {
            return _gefilterdeLijst.ElementAt(selectedIndex);
        }
    }
}
