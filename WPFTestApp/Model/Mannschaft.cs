using System.Collections.ObjectModel;
using WPFTestApp.Base;

namespace WPFTestApp.Model
{
    public class Mannschaft : BindableBase
    {
        public Mannschaft() { }
        
        public Mannschaft(string teamName, string mannschaftsart, bool competition)
        {
            this.MannschaftName = teamName;
            this.MannschaftsArt = mannschaftsart;
            this.IsOutOfCompetition = competition;
        }

        public Mannschaft(Mannschaft _mannschaft)
        {
            this.MannschaftName = _mannschaft.MannschaftName;
            this.MannschaftsArt = _mannschaft.MannschaftsArt;
            this.IsOutOfCompetition= _mannschaft.IsOutOfCompetition;
        }

        #region propertys

        private string _mannschaftName;
        public string MannschaftName
        {
            get { return _mannschaftName; }
            set {SetProperty<string> (ref _mannschaftName , value); }
        }

        private ObservableCollection<Jugendlicher> _listOfJugendliche;
        public ObservableCollection<Jugendlicher> ListOfJugendliche
        {
            get { return _listOfJugendliche; }
            set { SetProperty<ObservableCollection<Jugendlicher>> (ref _listOfJugendliche , value); }
        }
        
        private string _mannschaftsArt;
        public string MannschaftsArt
        {
            get { return _mannschaftsArt; }
            set {SetProperty<string> (ref _mannschaftsArt , value); }
        }

        private bool _isOutOfCompetition;
        public bool IsOutOfCompetition
        {
            get { return _isOutOfCompetition; }
            set {SetProperty<bool> (ref _isOutOfCompetition , value); }
        }

        #endregion

        #region methods

        public bool 
            Add(Jugendlicher _jugendlicher)
        {
            #region safety

            if (_jugendlicher == null)
                return false;

            if (ListOfJugendliche == null)
                ListOfJugendliche = new ObservableCollection<Jugendlicher>();

            #endregion

            if (ListOfJugendliche.Contains(_jugendlicher) == false)
                ListOfJugendliche.Add(_jugendlicher);

            return true;
        }

        public bool
            Remove(Jugendlicher _jugendlicher)
        {
            #region safety

            if (_jugendlicher == null)
                return false;

            if (ListOfJugendliche == null)
                return false;

            #endregion

            return ListOfJugendliche.Remove(_jugendlicher);
        }

        public int
            Get_CountOfTeens()
        {
            if (ListOfJugendliche == null)
                return 0;
            else
                return ListOfJugendliche.Count;
        }

        #endregion
    }
}
