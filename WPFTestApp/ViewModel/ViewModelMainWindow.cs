using System.Collections.Generic;
using System.Collections.ObjectModel;
using WPFTestApp.Model;
using WPFTestApp.Base;
using WPFTestApp.Commands;
using System.Windows.Input;
using System.Windows;
using System;
using System.Linq;

namespace WPFTestApp.ViewModel
{
    public class ViewModelMainWindow : BindableBase        
    {
        public enum UebungsartEnum
        {
            offenesGewässer,
            Unterflurhydrant
        }
        public ViewModelMainWindow()
        {
            // Initialisierung des RelayCommands
            NeuerJugendlicherHinzu = new RelayCommands(NeuerJugendlicherHinzuExecute, NeuerJugendlicherHinzuCanExecute);
            NeueMannschaftHinzu = new RelayCommands(NeueMannschaftHinzuExecute, NeueMannschaftHinzuCanExecute);
            MannschaftEntfernen = new RelayCommands(MannschaftEntfernenExecute, MannschaftEntfernenCanExecute);
            JugendlicherEntfernen = new RelayCommands(JugendlicherEntfernenExecute, JugendlicherEntfernenCanExecute);
            DummyHinzufügen = new RelayCommands(DummyMannschaftExecute, DummyMannschaftCanExecute);
            FragebogenBerechnen = new RelayCommands(PunkteFragebogenBerechenenExecute, PunkteFragebogenBerechenenCanExecute);

            // Werte für die Combobox cmb_MannschaftsArt
            MannschaftsArt = new List<string>() { "Gruppe", "Staffel"};
            ListOfPoints = new List<int>() {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            
            var _list = Enum.GetValues(typeof(UebungsartEnum)).Cast<UebungsartEnum>();
            UebungsArten = new List<UebungsartEnum>(_list);
            //first time init
            NeueMannschaft = new Mannschaft();
            NeuerJugendlicher = new Jugendlicher();            
        }

        #region commands
        
        public ICommand NeuerJugendlicherHinzu { get; private set; }
        public ICommand NeueMannschaftHinzu { get; private set; }
        public ICommand MannschaftEntfernen { get; private set; }
        public ICommand JugendlicherEntfernen { get; private set; }
        public ICommand DummyHinzufügen { get; private set; }
        public ICommand FragebogenBerechnen { get; private set; }

        #endregion

        #region Properties
            #region Mannschaftsdaten

        private ObservableCollection<Mannschaft> _team;
        public ObservableCollection<Mannschaft> Team
        {
            get { return _team; }
            set { SetProperty<ObservableCollection<Mannschaft>>(ref _team, value); }
        }

        private List<string> _mannschaftsArt;   
        public List<string> MannschaftsArt
        {
            get { return _mannschaftsArt; }
            set {SetProperty<List<string>> (ref _mannschaftsArt , value); }
        }

        private Jugendlicher _neuerJugendlicher;
        public Jugendlicher NeuerJugendlicher
        {

            get { return _neuerJugendlicher; }
            set { SetProperty<Jugendlicher>(ref _neuerJugendlicher, value); }
        }

        private Mannschaft _neueMannschaft;
        public Mannschaft NeueMannschaft
        {
            get { return _neueMannschaft; }
            set { SetProperty<Mannschaft>(ref _neueMannschaft, value); }
        }

        private Mannschaft _selectedMannschaft;
        public Mannschaft SelectedMannschaft
        {
            get { return _selectedMannschaft; }
            set {SetProperty<Mannschaft> (ref _selectedMannschaft , value); }
        }

        private List<int> _listOfPoints;
        public List<int> ListOfPoints
        {
            get { return _listOfPoints; }
            set { _listOfPoints = value; }
        }
        #endregion

            #region Wettbewerbsdaten
        private string _austragungsOrt;

        public string AustragungsOrt
        {
            get { return _austragungsOrt; }
            set { SetProperty<string>(ref _austragungsOrt, value); }
        }

        private DateTime? _aktuellesDatum;

        public DateTime? AktuellesDatum
        {
            get { return _aktuellesDatum; }
            set { _aktuellesDatum = value; }
        }
        private List<UebungsartEnum> _uebungsArten;

        public List<UebungsartEnum> UebungsArten
        {
            get { return _uebungsArten; }
            set { SetProperty<List<UebungsartEnum>>(ref _uebungsArten, value); }
        }

        private UebungsartEnum _uebungsArt;

        public UebungsartEnum UebungsArt
        {
            get { return _uebungsArt; }
            set {SetProperty<UebungsartEnum> (ref _uebungsArt , value); }
        }

        #endregion

        #endregion

        #region Methoden

        private bool DummyMannschaftCanExecute(object sender) { return true; }
     
        private void DummyMannschaftExecute(object sender) 
        {
            if (Team == null)
                Team = new ObservableCollection<Mannschaft>();

            var _random = new Random();
            var _region = new List<string>() { "Lippstadt", "Hannover", "Berlin", "Esbeck", "Mantinghausen", "Ilsede" };
            var _type = new List<string>() { "Staffel", "Gruppe" };
            var _bool = new List<bool>() { true, false, true, false, true, false, true, false };

            Jugendlicher _jugendlicher1 = new Jugendlicher();
            _jugendlicher1.FirstName = "Andreas";
            _jugendlicher1.LastName = "Neumann";
            _jugendlicher1.GeburtsDatum = new System.DateTime(2010, 03, 16);
            _jugendlicher1.AgeYears = _jugendlicher1.CalculateAgeInYears();

            Jugendlicher _jugendlicher2 = new Jugendlicher();
            _jugendlicher2.FirstName = "Elisabeth";
            _jugendlicher2.LastName = "Neumann";
            _jugendlicher2.GeburtsDatum = new System.DateTime(2005, 08, 27);
            _jugendlicher2.AgeYears = _jugendlicher2.CalculateAgeInYears();

            Jugendlicher _jugendlicher3 = new Jugendlicher();
            _jugendlicher3.FirstName = "Steven";
            _jugendlicher3.LastName = "Henning";
            _jugendlicher3.GeburtsDatum = new System.DateTime(2008, 11, 07);
            _jugendlicher3.AgeYears = _jugendlicher3.CalculateAgeInYears();

            Jugendlicher _jugendlicher4 = new Jugendlicher();
            _jugendlicher4.FirstName = "Daniel";
            _jugendlicher4.LastName = "Fischer";
            _jugendlicher4.GeburtsDatum = new System.DateTime(2012, 02, 20);
            _jugendlicher4.AgeYears = _jugendlicher4.CalculateAgeInYears();

            Jugendlicher _jugendlicher5 = new Jugendlicher();
            _jugendlicher5.FirstName = "Michael";
            _jugendlicher5.LastName = "Fischer";
            _jugendlicher5.GeburtsDatum = new System.DateTime(2008, 06, 10);
            _jugendlicher5.AgeYears = _jugendlicher5.CalculateAgeInYears();

            Jugendlicher _jugendlicher6 = new Jugendlicher();
            _jugendlicher6.FirstName = "Maria";
            _jugendlicher6.LastName = "Gerhard";
            _jugendlicher6.GeburtsDatum = new System.DateTime(2009, 04, 01);
            _jugendlicher6.AgeYears = _jugendlicher6.CalculateAgeInYears();

            var _dummyMannschaft = new Mannschaft(_region[_random.Next(0,_region.Count-1)], _type[_random.Next(0, _type.Count)], _bool[_random.Next(0,_bool.Count)]);
            _dummyMannschaft.Add(_jugendlicher1);
            _dummyMannschaft.Add(_jugendlicher2);
            _dummyMannschaft.Add(_jugendlicher3);
            _dummyMannschaft.Add(_jugendlicher4);
            _dummyMannschaft.Add(_jugendlicher5);
            _dummyMannschaft.Add(_jugendlicher6);
            _dummyMannschaft.AverageAge = _dummyMannschaft.Get_AverageAge();
            _dummyMannschaft.VorgabePunkte = _dummyMannschaft.Get_Vorgabepunkte();
            Team.Add(_dummyMannschaft);
        }


        private bool NeuerJugendlicherHinzuCanExecute(object sender)
        {
            return true;
        }
       
        private void NeuerJugendlicherHinzuExecute(object sender)
        {
            #region safety

            if (sender == null)
                return;

            if (NeuerJugendlicher == null)
                NeuerJugendlicher = new Jugendlicher();

            #endregion

            var _mannschaft = sender as Mannschaft;
            if (_mannschaft == null)
                return;
            
            /* Manschafft hat jetzt eine Methode, welche die Anzahl an aktuellen Teilnehmern zurückgibt */
            if (_mannschaft.Get_CountOfTeens() >= 9 && NeueMannschaft.MannschaftsArt == "Gruppe")
            {
                MessageBox.Show("Gruppe ist bereits voll.", "Fehler bei der Eingabe",
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
                return;
            }
            if (_mannschaft.Get_CountOfTeens() >= 6 && NeueMannschaft.MannschaftsArt == "Staffel")
            {
                MessageBox.Show("Staffel ist bereits voll.", "Fehler bei der Eingabe",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            /* check valid data */
            if (NeuerJugendlicher.FirstName == null)
            {
                MessageBox.Show("Keinen Vornamen eingegeben", "Fehler bei der Eingabe",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (NeuerJugendlicher.LastName == null)
            {
                MessageBox.Show("Keinen Nachnamen eingegeben.", "Fehler bei der Eingabe",
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
                return;
            }
            if (NeuerJugendlicher.GeburtsDatum == null)
            {
                MessageBox.Show("Kein Geburtsdatum eingegeben.", "Fehler bei der Eingabe",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
           
            /* create teen */
            var _jugendlicher = new Jugendlicher(NeuerJugendlicher.FirstName, NeuerJugendlicher.LastName, NeuerJugendlicher.GeburtsDatum, NeuerJugendlicher.CalculateAgeInYears());
            
            /* add teen to team */
            _mannschaft.Add(_jugendlicher);

            /* reset dummy */
            NeuerJugendlicher = new Jugendlicher();            
        }
        

        private bool JugendlicherEntfernenCanExecute(object sender)
        {            
            return true;
        }
     
        private void JugendlicherEntfernenExecute(object sender)
        {
            #region safety

            if (sender == null)
                return;

            if (NeueMannschaft == null)
                return;

            #endregion

            var _jugendlicher = sender as TeenWrapper;
            
            if (_jugendlicher != null)
                NeueMannschaft.ListOfJugendliche.Remove(_jugendlicher);

            /* NeueMannschaft.ListOfJugendliche könnte null sein */
        }
      

        private bool NeueMannschaftHinzuCanExecute(object sender) 
        { 
            return true; 
        }
        
        private void NeueMannschaftHinzuExecute(object sender)
        {
            #region safety

            if (Team == null)
                Team = new ObservableCollection<Mannschaft>();

            if (NeueMannschaft == null)
                NeueMannschaft = new Mannschaft();

            if (NeueMannschaft.MannschaftName == null)
            {
                MessageBox.Show("Keinen Mannschaftsnamen eingegeben", "Fehler bei der Eingabe",
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
                return;
            }

            #endregion

            /* create team : neuer Konstruktor in Mannschaft übernimmt das Kopieren der Daten */
            var _mannschaft 
                = new Mannschaft(NeueMannschaft);
            
            /* add new team */
            
            _mannschaft.AverageAge = _mannschaft.Get_AverageAge();
            _mannschaft.VorgabePunkte = _mannschaft.Get_Vorgabepunkte();
            Team.Add(_mannschaft);

            /* reset dummy */
            NeueMannschaft = new Mannschaft();
        }


        private bool MannschaftEntfernenCanExecute(object sender) 
        {
            return true; 
        }
      
        private void MannschaftEntfernenExecute(object sender)
        {
            #region safety

            if (Team == null)
                return;

            if (sender == null)
                return;

            #endregion

            var _mannschaft = sender as Mannschaft;
            if (_mannschaft != null)
                Team.Remove(_mannschaft);
        }

        
        private bool PunkteFragebogenBerechenenCanExecute(object sender) { return true; }
       
        private void PunkteFragebogenBerechenenExecute(object sender)
        {
            SelectedMannschaft.TotalPointsFragebogen = SelectedMannschaft.Get_PointsOfFragebogen();
        }


        #endregion
    }
}
