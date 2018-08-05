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
        string countryName;
        string countryContinent;
        string presidentName;
        string presidentAge;
        string cityName;
        string cityPopulation;
        string placeStreet;
        string placePopulation;
        string buildingType;
        string buildingWindows;
        string buildingIndustrial;





        private int Id_Country { get; set; }
        private int Id_City { get; set; }
        private int Place_Id_Building { get; set; }
        private int Place_Id { get; set; }

        public MainView()
        {
            InitializeComponent();
            CountryComboBoxList();




            //pomocnicze w view: Text="{Binding ElementName=CountryComboBox, Path=Text}"

        }

        private void CountryComboBoxList() //Column 1
        {
            CountryComboBox.Items.Clear();
            var Cou = CountryService.GetCountry().Select(x => x.Name);

            foreach (var cou in Cou)
            {
                CountryComboBox.Items.Add(cou);
            }

        }
        private void PresidentComboBoxList() //Column 2
        {
            PresidentComboBox.Items.Clear();
            var Pre = PresidentService.GetPresident().Where(x => x.Id == Id_Country).Select(x => x.Name);
            foreach (var pre in Pre)
            {
                PresidentComboBox.Items.Add(pre);
            }

        }
        private void CityComboBoxList() //Column 3
        {
            CityComboBox.Items.Clear();
            var Cit = CityService.GetCity().Where(x => x.CountryModel.Id == Id_Country).Select(x => x.Name);

            foreach (var cit in Cit)
            {
                CityComboBox.Items.Add(cit);
            }

        }
        private void PlaceComboBoxList() //Column 4
        {
            PlaceComboBox.Items.Clear();
            var Pla = PlaceService.GetPlace().Where(x => x.CityModel.Id == Id_City).Select(x => x.Street);

            foreach (var pla in Pla)
            {
                PlaceComboBox.Items.Add(pla);
            }


        }
        private void BuildingComboBoxList() //Column 5
        {
            BuildingComboBox.Items.Clear();
            var Bui = BuildingService.GetBuilding().Where(x => x.Id == Place_Id_Building).Select(x => x.Type);

            foreach (var bui in Bui)
            {
                BuildingComboBox.Items.Add(bui);
            }

        }



        private void CountryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CountryComboBox.SelectedItem != null)
            {
                Id_Country = CountryService.GetCountry()
                    .Where(x => (x.Name == CountryComboBox.SelectedItem.ToString()))
                    .Select(x => x.Id).FirstOrDefault();

                countryName = CountrySetName.Text = CountryService.GetCountry()
                        .Where(x => (x.Name == CountryComboBox.SelectedItem.ToString()))
                        .Select(x => x.Name).FirstOrDefault().ToString();

                countryContinent = CountrySetContinent.Text = CountryService.GetCountry()
                   .Where(x => (x.Name == CountryComboBox.SelectedItem.ToString()))
                   .Select(x => x.Continent).FirstOrDefault().ToString();

                PresidentComboBoxList();
                CityComboBoxList();
                PlaceComboBoxList();
                BuildingComboBoxList();
            }

        }

        private void PresidentComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PresidentComboBox.SelectedItem != null)
            {
                presidentName = PresidentSetName.Text = PresidentService.GetPresident()
                    .Where(x => (x.Name == PresidentComboBox.SelectedItem.ToString()))
                    .Select(x => x.Name).FirstOrDefault().ToString();

                presidentAge = PresidentSetAge.Text = PresidentService.GetPresident()
                   .Where(x => (x.Name == PresidentComboBox.SelectedItem.ToString()))
                        .Select(x => x.Age).FirstOrDefault().ToString();
            }



        }

        private void CityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CityComboBox.SelectedItem != null)
            {
                Id_City = CityService.GetCity()
                    .Where(x => (x.Name == CityComboBox.SelectedItem.ToString()))
                    .Select(x => x.Id).FirstOrDefault();

                cityName = CitySetName.Text = CityService.GetCity()
                   .Where(x => (x.Name == CityComboBox.SelectedItem.ToString()))
                   .Select(x => x.Name).FirstOrDefault().ToString();

                cityPopulation = CitySetPopulation.Text = CityService.GetCity()
                   .Where(x => (x.Name == CityComboBox.SelectedItem.ToString()))
                   .Select(x => x.Population).FirstOrDefault().ToString();

                
                PlaceComboBoxList();
                BuildingComboBoxList();
            }

        }

        private void PlaceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (PlaceComboBox.SelectedItem != null)
            {
                Place_Id = PlaceService.GetPlace()
                        .Where(x => (x.Street == PlaceComboBox.SelectedItem.ToString()))
                        .Select(x => x.Id).FirstOrDefault();
                Place_Id_Building = PlaceService.GetPlace()
                        .Where(x => (x.Street == PlaceComboBox.SelectedItem.ToString()))
                        .Select(x => x.BuildingModel.Id).FirstOrDefault();
                placeStreet = PlaceSetStreet.Text = PlaceService.GetPlace()
                        .Where(x => (x.Street == PlaceComboBox.SelectedItem.ToString()))
                        .Select(x => x.Street).FirstOrDefault().ToString();

                placePopulation = PlaceSetPopulation.Text = PlaceService.GetPlace()
                        .Where(x => (x.Street == PlaceComboBox.SelectedItem.ToString()))
                        .Select(x => x.PlacePopulation).FirstOrDefault().ToString();

                BuildingComboBoxList();
            }

        }

        private void BuildingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BuildingComboBox.SelectedItem != null)
            {
                buildingType = BuildingSetType.Text = BuildingService.GetBuilding()
                       .Where(x => (x.Type == BuildingComboBox.SelectedItem.ToString()))
                       .Select(x => x.Type).FirstOrDefault().ToString();

                buildingWindows = BuildingSetWindows.Text = BuildingService.GetBuilding()
                       .Where(x => (x.Type == BuildingComboBox.SelectedItem.ToString()))
                       .Select(x => x.InfoWindows).FirstOrDefault().ToString();

                buildingIndustrial = BuildingSetIsIndustrial.Text = BuildingService.GetBuilding()
                       .Where(x => (x.Type == BuildingComboBox.SelectedItem.ToString()))
                       .Select(x => x.InfoIndustrial).FirstOrDefault().ToString();
            }

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string _countryName = CountrySetName.Text;
            string _countryContinent = CountrySetContinent.Text;
            string _presidentName = PresidentSetName.Text;
            int _presidentAge;
            bool _presidentAgeBool = Int32.TryParse(PresidentSetAge.Text, out _presidentAge);
            string _cityName = CitySetName.Text;
            int _cityPopulation;
            bool _cityPopulationBool = Int32.TryParse(CitySetPopulation.Text, out _cityPopulation);
            string _placeStreet = PlaceSetStreet.Text;
            int _placePopulation;
            bool _placePopulationBool = Int32.TryParse(PlaceSetPopulation.Text, out _placePopulation);
            string _buildingType = BuildingSetType.Text;
            string _buildingWindows = BuildingSetWindows.Text;
            string _buildingIndustrial = BuildingSetIsIndustrial.Text;
            bool _buildingWindowsBool;
            bool _buildingIndustrialBool;

            if (_buildingWindows.ToUpper().Trim() == "TAK") { _buildingWindowsBool = true; }
            else { _buildingWindowsBool = false; }
            if (_buildingIndustrial.ToUpper().Trim() == "TAK") { _buildingIndustrialBool = true; }
            else { _buildingIndustrialBool = false; }

            if (_countryName == "" || _presidentName == "")
            {
                MessageBox.Show("Nie została podana nazwa państwa lub/i nazwisko prezydenta");
                return;
            }
            if (!_presidentAgeBool || !_cityPopulationBool || !_placePopulationBool)
            {
                MessageBox.Show("Wartości dla wieku czy populacji należy podawać w liczbach całkowitych");
                return;
            }

            if(_countryName == countryName)
            {
                if (_countryContinent != countryContinent)
                    CountryService.SaveCountry(_countryName, _countryContinent, Id_Country);


                if (_cityName == cityName && _cityPopulation != Convert.ToInt32(cityPopulation))
                    CityService.SaveCity(_cityName, Convert.ToInt32(_cityPopulation), Id_Country, Id_City);

                if (_cityName != cityName)
                {
                    CityService.SaveCity(_cityName, Convert.ToInt32(_cityPopulation), Id_Country);
                    Id_City = CityService.GetCity().Select(x => x.Id).LastOrDefault();
                }

                if ((_buildingType == buildingType && (_buildingWindows != buildingWindows || _buildingIndustrial != buildingIndustrial)))
                {

                    BuildingService.SaveBuilding(_buildingType, _buildingWindowsBool, _buildingIndustrialBool, Place_Id_Building);
                }

                if (_buildingType != buildingType)
                {
                    BuildingService.SaveBuilding(_buildingType, _buildingWindowsBool, _buildingIndustrialBool);
                    Place_Id_Building = BuildingService.GetBuilding().Select(x => x.Id).LastOrDefault();
                    if(_placeStreet == placeStreet && _placePopulation == Convert.ToInt32(placePopulation))
                    PlaceService.SavePlace(_placeStreet, _placePopulation, Id_City, Place_Id_Building, Place_Id);

                }

                if (_placeStreet == placeStreet && _placePopulation != Convert.ToInt32(placePopulation))
                    PlaceService.SavePlace(_placeStreet, _placePopulation, Id_City, Place_Id_Building, Place_Id);

                if (_placeStreet != placeStreet)
                    PlaceService.SavePlace(_placeStreet, _placePopulation, Id_City, Place_Id_Building);
            }
            else
            {
                CountryService.SaveCountry(_countryName, _countryContinent);
                int id_Country = CountryService.GetCountry().Select(x => x.Id).LastOrDefault();
                PresidentService.SavePresident(_presidentName, Convert.ToInt32(_presidentAge), id_Country);
                CityService.SaveCity(_cityName, Convert.ToInt32(_cityPopulation), id_Country);
                int id_City = CityService.GetCity().Select(x => x.Id).LastOrDefault();

                BuildingService.SaveBuilding(_buildingType, _buildingWindowsBool, _buildingIndustrialBool);
                Place_Id_Building = BuildingService.GetBuilding().Select(x => x.Id).LastOrDefault();
                PlaceService.SavePlace(_placeStreet, Convert.ToInt32(_placePopulation), id_City, Place_Id_Building);

            }
            

            CountryComboBoxList();
            PresidentComboBoxList();
            CityComboBoxList();
            PlaceComboBoxList();
            BuildingComboBoxList();
            CountrySetName.Clear();
            CountrySetContinent.Clear();
            PresidentSetName.Clear();
            PresidentSetAge.Clear();
            CitySetName.Clear();
            CitySetPopulation.Clear();
            CitySetPopulation.Clear();
            PlaceSetStreet.Clear();
            PlaceSetPopulation.Clear();
            BuildingSetType.Clear();
            BuildingSetWindows.Clear();
            BuildingSetIsIndustrial.Clear();
        }
    }
}
