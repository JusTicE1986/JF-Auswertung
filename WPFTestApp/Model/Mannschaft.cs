using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTestApp.Base;

namespace WPFTestApp.Model
{
    public class Mannschaft : BindableBase
    {
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
        public Mannschaft() { }
        public Mannschaft(string teamName, ObservableCollection<Jugendlicher> jugendlichers, string mannschaftsart, bool competition) 
        {
            this.MannschaftName = teamName;
            this.ListOfJugendliche = jugendlichers;
            this.MannschaftsArt = mannschaftsart;
            this.IsOutOfCompetition = competition;
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


    }
}
