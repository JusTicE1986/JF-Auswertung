using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTestApp.Model
{
    public class Fragebogen : Base.BindableBase
    {
        public Fragebogen(bool _isGruppe, bool _isStaffel)
        {
            if (_isGruppe) Generate(9);
            if (_isStaffel) Generate(6);
                    
        }

        private List<ErgebnisseClass> _ergebnisse;

        public List<ErgebnisseClass> Ergebnisse
        {
            get { return _ergebnisse; }
            set {SetProperty<List<ErgebnisseClass>> (ref _ergebnisse , value); }
        }

        private void Generate(int _anzahl)
        {
            Ergebnisse = new List<ErgebnisseClass> ();

            for (int i = 1; i < _anzahl; i++)
            {
                Ergebnisse.Add(new ErgebnisseClass() { IDFragebogen = i });
            }
        }

    public class ErgebnisseClass
    {
        public int IDFragebogen { get; set; }
        public int Ergebnis { get; set; }
    }
    }
}
