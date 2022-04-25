using System.Collections.Generic;

namespace WPFTestApp.Model
{
    public class Fragebogen : Base.BindableBase
    {
        public Fragebogen(bool _isGruppe, bool _isStaffel)
        {
            if (_isGruppe) Generate(9);
            if (_isStaffel) Generate(6);

        }

        #region propertys 

        private List<ErgebnisClass> _ergebnisse;
        public List<ErgebnisClass> Ergebnisse
        {
            get { return _ergebnisse; }
            set { SetProperty<List<ErgebnisClass>>(ref _ergebnisse, value); }
        }

        #endregion

        #region methods

        private void Generate(int _anzahl)
        {
            Ergebnisse = new List<ErgebnisClass>();

            for (int i = 1; i < _anzahl; i++)
            {
                Ergebnisse.Add(new ErgebnisClass() { IDFragebogen = i });
            }
        }

        #endregion

    }

    public class ErgebnisClass
    {
        public int IDFragebogen { get; set; }
        public int Ergebnis { get; set; }
    }
}
