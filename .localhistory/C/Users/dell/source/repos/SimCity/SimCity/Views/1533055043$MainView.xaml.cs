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

        private int Id_Country { get; set; }
        private int Id_City { get; set; }
        private int Place_Id_Building { get; set; }

        public MainView()
        {
            InitializeComponent();
            CountryComboBoxList();




            //pomocnicze w view: Text="{Binding ElementName=CountryComboBox, Path=Text}"

        }

        private void CountryComboBoxList() //Column 1
        {
            var Cou = CountryService.UpDataCountry().Select(x => x.Name);

            foreach (var cou in Cou)
            {
                CountryComboBox.Items.Add(cou);
            }

        }
        private void PresidentComboBoxList() //Column 2
        {
            PresidentComboBox.Items.Clear();
            var Pre = PresidentService.UpdataPresident().Where(x => x.Id == Id_Country).Select(x => x.Name);
            foreach (var pre in Pre)
            {
                PresidentComboBox.Items.Add(pre);
            }

        }
        private void CityComboBoxList() //Column 3
        {
            CityComboBox.Items.Clear();
            var Cit = CityService.UpDataCity().Where(x => x.CountryModel.Id == Id_Country).Select(x => x.Name);

            foreach (var cit in Cit)
            {
                CityComboBox.Items.Add(cit);
            }

        }
        private void PlaceComboBoxList() //Column 4
        {
            PlaceComboBox.Items.Clear();
            var Pla = PlaceService.UpDataPlace().Where(x => x.CityModel.Id == Id_City).Select(x => x.Street);

            foreach (var pla in Pla)
            {
                PlaceComboBox.Items.Add(pla);
            }


        }
        private void BuildingComboBoxList() //Column 5
        {
            BuildingComboBox.Items.Clear();
            var Bui = BuildingService.UpDataBuilding().Where(x => x.Id == Place_Id_Building).Select(x => x.Type);

            foreach (var bui in Bui)
            {
                BuildingComboBox.Items.Add(bui);
            }

        }



        private void CountryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Id_Country = CountryService.UpDataCountry()
                    .Where(x => (x.Name == CountryComboBox.SelectedItem.ToString()))
                    .Select(x => x.Id).FirstOrDefault();

            CountrySetName.Text = CountryService.UpDataCountry()
                    .Where(x => (x.Name == CountryComboBox.SelectedItem.ToString()))
                    .Select(x => x.Name).FirstOrDefault().ToString();

            CountrySetContinent.Text = CountryService.UpDataCountry()
               .Where(x => (x.Name == CountryComboBox.SelectedItem.ToString()))
               .Select(x => x.Continent).FirstOrDefault().ToString();

            PresidentComboBoxList();
            CityComboBoxList();

        }

        private void PresidentComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PresidentComboBox.SelectedItem != null)
            {
                PresidentSetName.Text = PresidentService.UpdataPresident()
                    .Where(x => (x.Name == PresidentComboBox.SelectedItem.ToString()))
                    .Select(x => x.Name).FirstOrDefault().ToString();

                PresidentSetAge.Text = PresidentService.UpdataPresident()
                   .Where(x => (x.Name == PresidentComboBox.SelectedItem.ToString()))
                        .Select(x => x.Age).FirstOrDefault().ToString();
            }



        }

        private void CityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CityComboBox.SelectedItem != null)
            {
                Id_City = CityService.UpDataCity()
                    .Where(x => (x.Name == CityComboBox.SelectedItem.ToString()))
                    .Select(x => x.Id).FirstOrDefault();

                CitySetName.Text = CityService.UpDataCity()
                   .Where(x => (x.Name == CityComboBox.SelectedItem.ToString()))
                   .Select(x => x.Name).FirstOrDefault().ToString();

                CitySetPopulation.Text = CityService.UpDataCity()
                   .Where(x => (x.Name == CityComboBox.SelectedItem.ToString()))
                   .Select(x => x.Population).FirstOrDefault().ToString();

                PlaceComboBoxList();
            }

        }

        private void PlaceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (PlaceComboBox.SelectedItem != null)
            {
                Place_Id_Building = PlaceService.UpDataPlace()
                        .Where(x => (x.Street == PlaceComboBox.SelectedItem.ToString()))
                        .Select(x => x.BuildingModel.Id).FirstOrDefault();
                PlaceSetName.Text = PlaceService.UpDataPlace()
                        .Where(x => (x.Street == PlaceComboBox.SelectedItem.ToString()))
                        .Select(x => x.Street).FirstOrDefault().ToString();

                PlaceSetPopulation.Text = PlaceService.UpDataPlace()
                        .Where(x => (x.Street == PlaceComboBox.SelectedItem.ToString()))
                        .Select(x => x.PlacePopulation).FirstOrDefault().ToString();

                BuildingComboBoxList();
            }

        }

        private void BuildingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BuildingComboBox.SelectedItem != null)
            {
                BuildingSetType.Text = BuildingService.UpDataBuilding()
                       .Where(x => (x.Type == BuildingComboBox.SelectedItem.ToString()))
                       .Select(x => x.Type).FirstOrDefault().ToString();

                BuildingSetWindows.Text = BuildingService.UpDataBuilding()
                       .Where(x => (x.Type == BuildingComboBox.SelectedItem.ToString()))
                       .Select(x => x.InfoWindows).FirstOrDefault().ToString();

                BuildingSetIsIndustrial.Text = BuildingService.UpDataBuilding()
                       .Where(x => (x.Type == BuildingComboBox.SelectedItem.ToString()))
                       .Select(x => x.InfoIndustrial).FirstOrDefault().ToString();
            }

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string countryName = CountrySetName.Text;
            string countryContinent = CountrySetContinent.Text;
            string presidentName = PresidentSetName.Text;
            string presidentAge = PresidentSetAge.Text;
            string cityName = CountrySetName.Text;
            string cityContinent = CountrySetContinent.Text;
            string palceName = PlaceSetName.Text;
            string placePOpulation = PlaceSetPopulation.Text;
            string buildingType = BuildingSetType.Text;
            string buildingWindows = BuildingSetWindows.Text;
            string buildingIndustrial = BuildingSetIsIndustrial.Text;


        }
    }
}
