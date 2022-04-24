using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            // Werte für die Combobox cmb_MannschaftsArt
            MannschaftsArt = new List<string>();
            MannschaftsArt.Add("Gruppe");
            MannschaftsArt.Add("Staffel");

            NeueMannschaft = new Mannschaft();

            // Initialisierung des RelayCommands
            NeuerJugendlicherHinzu = new RelayCommands(NeuerJugendlicherHinzuExecute, NeuerJugendlicherHinzuCanExecute);
            NeueMannschaftHinzu = new RelayCommands(NeueMannschaftHinzuExecute, NeueMannschaftHinzuCanExecute);
            MannschaftEntfernen = new RelayCommands(MannschaftEntfernenExecute, MannschaftEntfernenCanExecute);
            JugendlicherEntfernen = new RelayCommands(JugendlicherEntfernenExecute, JugendlicherEntfernenCanExecute);
        }
        #region commands
        
        public ICommand NeuerJugendlicherHinzu { get; private set; }
        public ICommand NeueMannschaftHinzu { get; private set; }
        public ICommand MannschaftEntfernen { get; private set; }
        public ICommand JugendlicherEntfernen { get; private set; }

        #endregion
        #region Properties
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
        #region Fields
        private ObservableCollection<Jugendlicher> _listJugendlicher;
        public ObservableCollection<Jugendlicher> ListJugendlicher
        {
            get { return _listJugendlicher; }
            set {SetProperty<ObservableCollection<Jugendlicher>> (ref _listJugendlicher, value); }
        }

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

        #endregion
        #region Methoden

        private bool NeuerJugendlicherHinzuCanExecute(object sender)
        {
            return true;
        }
        private void NeuerJugendlicherHinzuExecute(object sender)
        {
            if (sender == null) return;
            Mannschaft _mannschaft = sender as Mannschaft;
            if (NeuerJugendlicher == null) return;
            if (_mannschaft.ListOfJugendliche.Count >= 9 && NeueMannschaft.MannschaftsArt == "Gruppe")
            {
                MessageBox.Show("Gruppe ist bereits voll.", "Fehler bei der Eingabe",
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
                return;
            }
            if (_mannschaft.ListOfJugendliche.Count >= 6 && NeueMannschaft.MannschaftsArt == "Staffel")
            {
                MessageBox.Show("Staffel ist bereits voll.", "Fehler bei der Eingabe",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

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
            var _jugendlicher = new Jugendlicher(NeuerJugendlicher.FirstName,
                NeuerJugendlicher.LastName, NeuerJugendlicher.GeburtsDatum, NeuerJugendlicher.CalculateAgeInYears());
            
            _mannschaft.ListOfJugendliche.Add(_jugendlicher);
            NeuerJugendlicher = new Jugendlicher();
            
        }
        private bool JugendlicherEntfernenCanExecute(object sender)
        {
            if (sender == null) return false;
            return true;
        }
        private void JugendlicherEntfernenExecute(object sender)
        {
            Jugendlicher jugendlicher = sender as Jugendlicher;
            NeueMannschaft.ListOfJugendliche.Remove(jugendlicher);
        }
        private bool NeueMannschaftHinzuCanExecute(object sender) { return true; }
        private void NeueMannschaftHinzuExecute(object sender)
        {
            if(Team == null)
            {
                Team = new ObservableCollection<Mannschaft> ();
            };
            //if (sender == null) return;
            //Mannschaft NeueMannschaft = sender as Mannschaft;
            if (NeueMannschaft == null)
            {
                NeueMannschaft = new Mannschaft();
            }

            if (NeueMannschaft.MannschaftName == null)
            {
                MessageBox.Show("Keinen Mannschaftsnamen eingegeben", "Fehler bei der Eingabe",
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
                return;
            }
            var _mannschaft = new Mannschaft(NeueMannschaft.MannschaftName, new ObservableCollection<Jugendlicher>(), NeueMannschaft.MannschaftsArt, NeueMannschaft.IsOutOfCompetition);
            Team.Add(_mannschaft);
            NeueMannschaft = new Mannschaft();
        }
        private bool MannschaftEntfernenCanExecute(object sender) 
        {
            if (sender == null) return false;
            return true; 
        }
        private void MannschaftEntfernenExecute(object sender)
        {
            Mannschaft _mannschaft = sender as Mannschaft;
            Team.Remove(_mannschaft);
        }
        
        #endregion
    }
}
