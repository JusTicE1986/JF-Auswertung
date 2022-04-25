using System.Collections.Generic;
using System.Collections.ObjectModel;
using WPFTestApp.Model;
using WPFTestApp.Base;
using WPFTestApp.Commands;
using System.Windows.Input;
using System.Windows;

namespace WPFTestApp.ViewModel
{
    public class ViewModelMainWindow : BindableBase        
    {      
        public ViewModelMainWindow()
        {
            // Initialisierung des RelayCommands
            NeuerJugendlicherHinzu = new RelayCommands(NeuerJugendlicherHinzuExecute, NeuerJugendlicherHinzuCanExecute);
            NeueMannschaftHinzu = new RelayCommands(NeueMannschaftHinzuExecute, NeueMannschaftHinzuCanExecute);
            MannschaftEntfernen = new RelayCommands(MannschaftEntfernenExecute, MannschaftEntfernenCanExecute);
            JugendlicherEntfernen = new RelayCommands(JugendlicherEntfernenExecute, JugendlicherEntfernenCanExecute);

            // Werte für die Combobox cmb_MannschaftsArt
            MannschaftsArt = new List<string>() { "Gruppe", "Staffel"};

            //first time init
            NeueMannschaft = new Mannschaft();
            NeuerJugendlicher = new Jugendlicher();            
        }

        #region commands
        
        public ICommand NeuerJugendlicherHinzu { get; private set; }
        public ICommand NeueMannschaftHinzu { get; private set; }
        public ICommand MannschaftEntfernen { get; private set; }
        public ICommand JugendlicherEntfernen { get; private set; }

        #endregion

        #region Properties

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

        #endregion

        #region Methoden

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

            var _jugendlicher = sender as Jugendlicher;
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
        
        #endregion
    }
}
