namespace MatrixRain.Base.Interfaces
{
    public interface INavigation
    {
        public string CurrentView();
        public void AddView(string viewName);
        public void GoBack();
    }
}
