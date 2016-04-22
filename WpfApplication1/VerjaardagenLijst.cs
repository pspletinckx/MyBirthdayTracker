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
        private ListBox verjaardagen;
        private IDisposable cancellation;

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
        }
        public void OnCompleted()
        {
            verjaardagen.Items.Clear();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Persoon value)
        {
            verjaardagen.Items.Add(value.toString());
        }
    }
}
