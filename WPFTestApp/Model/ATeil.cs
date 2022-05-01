using System;
using WPFTestApp.ViewModel;

namespace WPFTestApp.Model
{
    public class ATeil : Base.BindableBase
    {
        #region Properties


        private DateTime? _vorgabeZeit;
        public DateTime? VorgabeZeit
        {
            get { return _vorgabeZeit; }
            set {SetProperty<DateTime?> (ref _vorgabeZeit , value); }
        }

        private DateTime? _knotenZeit;
        public DateTime? KnotenZeit
        {
            get { return _knotenZeit; }
            set {SetProperty<DateTime?> (ref _knotenZeit , value); }
        }

        private DateTime? _benoetigteZeit;  
        public DateTime? BenoetigteZeit
        {
            get { return _benoetigteZeit; }
            set {SetProperty<DateTime?> (ref _benoetigteZeit , value); }
        }

        private int _eindruck;
        public int Eindruck
        {
            get { return _eindruck; }
            set {SetProperty<int> (ref _eindruck , value); }
        }
        private double _fehlerPunkte;

        public double FehlerPunkte
        {
            get { return _fehlerPunkte; }
            set {SetProperty<double> (ref _fehlerPunkte , value); }
        }



        #endregion

        public int 
            Get_PunkteKnotenzeit()
        {
            int PunkteKnotenZeit = KnotenZeit.Value.Second;

            return PunkteKnotenZeit;
        }

    }

    enum MannschaftFunktionEnum
    {
        EinheitsführerMelder,
        Maschinist,
        Angriffstrupp,
        Wassertrupp,
        Schlauchtrupp
    }
}
