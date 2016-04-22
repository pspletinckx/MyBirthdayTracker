using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class Persoon
    {
        public Persoon(String voornaam, String achternaam, String groep, DateTime geboortedatum)
        {
            this.voornaam = voornaam;
            this.achternaam = achternaam;
            this.groep = groep;
            this.geboortedatum = geboortedatum;
        }
        public String voornaam { get; private set; }
        public String achternaam { get; private set; }
        public String groep { get; private set; }
        public DateTime geboortedatum { get; private set; }

        public String toString()
        {
            return voornaam + " " + achternaam +" " + getNextBirthdayAge()+"j ";
        }
        public int getAge()
        {
            var now = DateTime.Today;
            int age = now.Year - geboortedatum.Year;
            if (geboortedatum > now.AddYears(-age))age--;              
            return age;
        }
        public int getNextBirthdayAge()
        {
            return getAge() + 1;
        }
        public DateTime getNextBirthday()
        {
            DateTime result = geboortedatum; //struct
            while(result < DateTime.Now && geboortedatum <DateTime.Now)
            {
                result = result.AddYears(1);
            }
            return result;
        }
    }

    public class BirthdayArray : IObservable<Persoon> 
    {
        private List<IObserver<Persoon>> observers;
        private List<Persoon> verjaardagen;
       
        public BirthdayArray()
        {
            //dummy data
            observers = new List<IObserver<Persoon>>();
            verjaardagen = new List<Persoon>();

            
        }
        public IDisposable Subscribe(IObserver<Persoon> observer) {

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