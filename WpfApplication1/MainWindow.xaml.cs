using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BirthdayArray verjaardagen;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        private void MainWindow_Loaded(object sender, System.EventArgs e)
        {
            VerjaardagenLijst lijst = new VerjaardagenLijst(listBox1); //adapter
            verjaardagen = new BirthdayArray(); //model
            lijst.Subscribe(verjaardagen);  //binding

            Persoon Jan = new Persoon("Jantje", "Vermeulen", "Familie", new DateTime(1991, 4, 25));
            verjaardagen.VoegVerjaardagToe(Jan);
            Persoon Els = new Persoon("Els", "De Visser", "Vrienden", new DateTime(1960, 5, 20));
            verjaardagen.VoegVerjaardagToe(Els);
            Persoon Ann = new Persoon("An", "De Brandt", "Algemeen", new DateTime(1920, 4, 24));
            verjaardagen.VoegVerjaardagToe(Ann);
            
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listBox1.SelectedIndex;
            Persoon p = verjaardagen.getFeestvarken(listBox1.SelectedIndex);
            voornaamBlock.Text = p.voornaam;
            achternaamBlock.Text = p.achternaam;
            geboorteDatumBlock.Text = p.geboortedatum.Day + "/" + p.geboortedatum.Month + "/" + p.geboortedatum.Year;
        }

        private void newButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
