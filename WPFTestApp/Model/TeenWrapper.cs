namespace WPFTestApp.Model
{
    public class TeenWrapper : Base.BindableBase
    {
        public Jugendlicher Teen { get; set; }

        private int _punkteFragebogen;
        public int PunkteFragebogen
        {
            get { return _punkteFragebogen; }
            set 
            { 
                SetProperty<int>(ref _punkteFragebogen , value);
                CalculatedFragebogen = _punkteFragebogen * 5;
            }
        }
       
        private int _calculatedFragebogen;
        public int CalculatedFragebogen
        {
            get { return _calculatedFragebogen; }
            set {SetProperty<int> (ref _calculatedFragebogen , value); }
        }

    }
}
