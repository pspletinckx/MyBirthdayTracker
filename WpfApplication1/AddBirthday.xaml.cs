using System;
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
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for AddBirthday.xaml
    /// </summary>
    public partial class AddBirthday : Window
    {
        private BirthdayArray verjaardagen;
        public AddBirthday(BirthdayArray verjaardagen)
        {
            InitializeComponent();
            this.verjaardagen = verjaardagen;
            datePicker.DisplayDateEnd = DateTime.Today;
        }

        private void opslaanButton_Click(object sender, RoutedEventArgs e)
        {
            //optional: validation

            Persoon p = new Persoon(
                voornaamBox.Text,
                achternaamBox.Text,
                comboBox.Text,
                datePicker.SelectedDate.Value);

            verjaardagen.VoegVerjaardagToe(p);
            this.Close();
        }

        private void meerdereButton_Click(object sender, RoutedEventArgs e)
        {
            //optional: validation

            Persoon p = new Persoon(
                voornaamBox.Text,
                achternaamBox.Text,
                comboBox.SelectedValue.ToString(),
                datePicker.SelectedDate.Value);

            verjaardagen.VoegVerjaardagToe(p);
            //reset this persistent window
            voornaamBox.Clear();
            achternaamBox.Clear();
            //datePicker.SetValue(datePicker.valu)
            comboBox.SelectedIndex = 0;
        }

        private void sluitenButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
