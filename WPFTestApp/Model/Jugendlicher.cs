using System;
using WPFTestApp.Base;

namespace WPFTestApp.Model
{
    public class Jugendlicher : BindableBase
    {
        #region propertys

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set {SetProperty<string>(ref _firstName , value); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set {SetProperty<string>(ref _lastName , value); }
        }

        private DateTime? _geburtsDatum;
        public DateTime? GeburtsDatum
        {
            get { return _geburtsDatum; }
            set {SetProperty<DateTime?> (ref _geburtsDatum , value); }
        }

        private int _punkteFragebogen;
        public int PunkteFragebogen
        {
            get { return _punkteFragebogen; }
            set { _punkteFragebogen = value; }
        }

        private int _ageYears;
        public int AgeYears
        {
            get { return _ageYears; }
            set {SetProperty<int> (ref _ageYears , value); }
        }

        private DateTime? _ageInYears;
        public DateTime? dateTime
        {
            get { return _ageInYears; }
            set { SetProperty<DateTime?>(ref _ageInYears, value); }
        }

        #endregion

        public Jugendlicher(){ }
        public Jugendlicher(string firstName, string lastName, DateTime? date, int ageYears) 
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.GeburtsDatum = date;
            this.AgeYears = ageYears;
        }

        public int CalculateAgeInYears()
        {
            var _Geburtsdatum = GeburtsDatum.Value.Year;
            var _currentYear = DateTime.Now.Year;
            int _ageInYears = _currentYear - _Geburtsdatum;
            
            return _ageInYears;
        }
    }
}
