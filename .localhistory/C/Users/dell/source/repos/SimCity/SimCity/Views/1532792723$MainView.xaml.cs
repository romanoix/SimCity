using SimCity.Models;
using SimCity.Services;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimCity
{
    /// <summary>
    /// Logika interakcji dla klasy MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            CountryComboBoxList();
            PresidentComboBoxList();


            //pomocnicze w view: Text="{Binding ElementName=CountryComboBox, Path=Text}"

        }

        private void CountryComboBoxList()
        {
            var Cou = CountryService.GetCountry().Select(x => x.Name);
            
            foreach (var cou in Cou)
            {
                CountryComboBox.Items.Add(cou);
            }
            
        }
        private void PresidentComboBoxList()
        {
            var Pre = PresidentService.GetPresident().Select(x => x.Name);

            foreach (var pre in Pre)
            {
                PresidentComboBox.Items.Add(pre);
            }

        }
        private void CityComboBoxList()
        {
            var Cit = PresidentService.GetPresident().Select(x => x.Name);

            foreach (var cit in Cit)
            {
                PresidentComboBox.Items.Add(cit);
            }

        }


        private void CountryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
                CountrySetNameCountry.Text = CountryService.GetCountry()
                    .Where(x=>(x.Name== CountryComboBox.SelectedItem.ToString()))
                    .Select(x => x.Name).FirstOrDefault().ToString();

                CountrySetContinent.Text = CountryService.GetCountry()
                   .Where(x => (x.Name == CountryComboBox.SelectedItem.ToString()))
                   .Select(x => x.Continent).FirstOrDefault().ToString();

        }

        private void PresidentComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PresidentSetName.Text = PresidentService.GetPresident()
                    .Where(x => (x.Name == PresidentComboBox.SelectedItem.ToString()))
                    .Select(x => x.Name).FirstOrDefault().ToString();

            PresidentSetAge.Text = PresidentService.GetPresident()
               .Where(x => (x.Name == PresidentComboBox.SelectedItem.ToString()))
                    .Select(x => x.Age).FirstOrDefault().ToString();

        }

        private void CityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
