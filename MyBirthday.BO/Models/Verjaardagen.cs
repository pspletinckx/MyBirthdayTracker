using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBirthday.BO.Models
{
    public class Verjaardagen : IObservable<Persoon>
    {
        private List<IObserver<Persoon>> observers;
        private List<Persoon> verjaardagen;

        public Verjaardagen()
        {
            //dummy data
            observers = new List<IObserver<Persoon>>();
            verjaardagen = new List<Persoon>();


        }
        public IDisposable Subscribe(IObserver<Persoon> observer)
        {

            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
            foreach (var item in verjaardagen)
            {
                observer.OnNext(item);
            }
            return new Unsubscriber<Persoon>(observers, observer);
        }

        internal Persoon getFeestvarken(int selectedIndex)
        {
            return verjaardagen.ElementAt(selectedIndex);
        }

        public void VoegVerjaardagToe(Persoon persoon)
        {
            verjaardagen.Add(persoon);
            foreach (var observer in observers)
            {
                observer.OnNext(persoon); //observer push
            }
        }
        internal class Unsubscriber<T> : IDisposable
        {
            private IObserver<Persoon> observer;
            private List<IObserver<Persoon>> observers;

            public Unsubscriber(List<IObserver<Persoon>> observers, IObserver<Persoon> observer)
            {
                this.observers = observers;
                this.observer = observer;
            }

            public void Dispose()
            {
                if (observers.Contains(observer))
                {
                    observers.Remove(observer);
                }
            }
        }
    }

}
