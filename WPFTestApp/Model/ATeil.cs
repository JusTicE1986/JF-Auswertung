using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTestApp.Model
{
    public class ATeil : Base.BindableBase
    {
        enum MannschaftFunktion
        {
            GruppenführerMelder,
            Maschinist,
            Angriffstrupp,
            Wassertrupp,
            Schlauchtrupp
        }
        #region Properties

        private int _vorgabePunkte;

        public int VorgabePunkte
        {
            get { return _vorgabePunkte; }
            set { SetProperty<int>(ref _vorgabePunkte, value); }
        }

        private DateTime? _vorgabeZeit;

        public DateTime? VorgabeZeit
        {
            get { return _vorgabeZeit; }
            set {SetProperty<DateTime?> (ref _vorgabeZeit , value); }
        }





        #endregion

    }
}
