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

        private int id_Country = 1;
        public MainView()
        {
            InitializeComponent();
            CountryComboBoxList();
            
            
            PlaceComboBoxList();
            BuildingComboBoxList();


            //pomocnicze w view: Text="{Binding ElementName=CountryComboBox, Path=Text}"

        }

        private void CountryComboBoxList() //Column 1
        {
            var Cou = CountryService.GetCountry().Select(x => x.Name);
            
            foreach (var cou in Cou)
            {
                CountryComboBox.Items.Add(cou);
            }
            
        }
        private void PresidentComboBoxList() //Column 2
        {
            PresidentComboBox.Items.Clear();
            var Pre = PresidentService.GetPresident().Where(x=>x.Id== id_Country). Select(x => x.Name);
            foreach (var pre in Pre)
            {
                PresidentComboBox.Items.Add(pre);
            }

        }
        private void CityComboBoxList() //Column 3
        {
            CityComboBox.Items.Clear();
            var Cit = CityService.GetCity().Where(x => x.Id == id_Country).Select(x => x.Name);

            foreach (var cit in Cit)
            {
                CityComboBox.Items.Add(cit);
            }

        }
        private void PlaceComboBoxList() //Column 4
        {
            var Pla = PlaceService.GetPlace().Select(x => x.Street);

            foreach (var pla in Pla)
            {
                PlaceComboBox.Items.Add(pla);
            }

        }
        private void BuildingComboBoxList() //Column 5
        {
            var Bui = BuildingService.GetBuilding().Select(x => x.Type);

            foreach (var bui in Bui)
            {
                BuildingComboBox.Items.Add(bui);
            }

        }



        private void CountryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            id_Country = CountryService.GetCountry()
                    .Where(x => (x.Name == CountryComboBox.SelectedItem.ToString()))
                    .Select(x => x.Id).FirstOrDefault();

            CountrySetNameCountry.Text = CountryService.GetCountry()
                    .Where(x=>(x.Name== CountryComboBox.SelectedItem.ToString()))
                    .Select(x => x.Name).FirstOrDefault().ToString();

                CountrySetContinent.Text = CountryService.GetCountry()
                   .Where(x => (x.Name == CountryComboBox.SelectedItem.ToString()))
                   .Select(x => x.Continent).FirstOrDefault().ToString();

            PresidentComboBoxList();
            CityComboBoxList();

        }

        private void PresidentComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PresidentComboBox.SelectedItem != null)
            {
                PresidentSetName.Text = PresidentService.GetPresident()
                    .Where(x => (x.Name == PresidentComboBox.SelectedItem.ToString()))
                    .Select(x => x.Name).FirstOrDefault().ToString();

                PresidentSetAge.Text = PresidentService.GetPresident()
                   .Where(x => (x.Name == PresidentComboBox.SelectedItem.ToString()))
                        .Select(x => x.Age).FirstOrDefault().ToString();
            }
                
            

        }

        private void CityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CityComboBox.SelectedItem != null)
            {
                CitySetName.Text = CityService.GetCity()
                   .Where(x => (x.Name == CityComboBox.SelectedItem.ToString()))
                   .Select(x => x.Name).FirstOrDefault().ToString();

                CitySetPopulation.Text = CityService.GetCity()
                   .Where(x => (x.Name == CityComboBox.SelectedItem.ToString()))
                   .Select(x => x.Population).FirstOrDefault().ToString();

            }
               

        }

        private void PlaceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PlaceSetName.Text = PlaceService.GetPlace()
                    .Where(x => (x.Street == PlaceComboBox.SelectedItem.ToString()))
                    .Select(x => x.Street).FirstOrDefault().ToString();

            PlaceSetPopulation.Text = PlaceService.GetPlace()
                    .Where(x => (x.Street == PlaceComboBox.SelectedItem.ToString()))
                    .Select(x => x.PlacePopulation).FirstOrDefault().ToString();
        }

        private void BuildingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BuildingSetType.Text = BuildingService.GetBuilding()
                   .Where(x => (x.Type == BuildingComboBox.SelectedItem.ToString()))
                   .Select(x => x.Type).FirstOrDefault().ToString();

            BuildingSetWindows.Text = BuildingService.GetBuilding()
                   .Where(x => (x.Type == BuildingComboBox.SelectedItem.ToString()))
                   .Select(x => x.InfoWindows).FirstOrDefault().ToString();

            BuildingSetIsIndustrial.Text = BuildingService.GetBuilding()
                   .Where(x => (x.Type == BuildingComboBox.SelectedItem.ToString()))
                   .Select(x => x.InfoIndustrial).FirstOrDefault().ToString();
        }
    }
}
