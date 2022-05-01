using System;
using System.Collections.Generic;
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

        private ObservableCollection<TeenWrapper> _listOfJugendliche;
        public ObservableCollection<TeenWrapper> ListOfJugendliche
        {
            get { return _listOfJugendliche; }
            set { SetProperty<ObservableCollection<TeenWrapper>> (ref _listOfJugendliche , value); }
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

        private double _averageAge;
        public double AverageAge
        {
            get { return _averageAge; }
            set {SetProperty<double> (ref _averageAge , value); }
        }

        private int _vorgabePunkte;
        public int VorgabePunkte
        {
            get { return _vorgabePunkte; }
            set {SetProperty<int> (ref _vorgabePunkte , value); }
        }


        private double _totalPointsFragebogen;

        public double TotalPointsFragebogen
        {
            get { return _totalPointsFragebogen; }
            set {SetProperty<double> (ref _totalPointsFragebogen , value); }
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
                ListOfJugendliche = new ObservableCollection<TeenWrapper>();

            #endregion

            TeenWrapper wrapper = new TeenWrapper();
            wrapper.Teen = _jugendlicher;
            ListOfJugendliche.Add(wrapper);

            return true;
        }

        public bool
            Remove(TeenWrapper _jugendlicher)
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

        public double 
            Get_PointsOfFragebogen()
        {
            int TotalPoints = 0;
            if (ListOfJugendliche != null)
            {
                foreach (var item in ListOfJugendliche)
                {
                    TotalPoints += item.PunkteFragebogen;
                }
            }
            switch (MannschaftsArt)
            {
                case "Gruppe": return TotalPoints * 5;
                case "Staffel": return TotalPoints * 7.5;
                default:
                    break;
            }
            return TotalPoints * 5;
        }

        public double 
            Get_AverageAge()
        {
            AverageAge = 0;
            if (ListOfJugendliche == null) return 0;
            foreach (var item in ListOfJugendliche)
            {
                AverageAge += item.Teen.AgeYears;
            }

            switch (MannschaftsArt)
            {
                case "Gruppe":
                    return Math.Round(AverageAge / 9,0);
                case "Staffel": 
                    return Math.Round(AverageAge / 6,0);
                default: return 0;
            }
        }

        public int
            Get_Vorgabepunkte()
        {
            VorgabePunkte = 1010;
            switch (AverageAge)
            {
                case 10: return VorgabePunkte;
                case 11: return VorgabePunkte - 5;
                case 12: return VorgabePunkte - 10;
                case 13: return VorgabePunkte - 15;
                case 14: return VorgabePunkte - 20;
                case 15: return VorgabePunkte - 25;
                case 16: return VorgabePunkte - 30;
                case 17: return VorgabePunkte - 35;
                case 18: return VorgabePunkte - 40;
                default:
                    return 0;
            }
        }
        

        #endregion
    }
}
