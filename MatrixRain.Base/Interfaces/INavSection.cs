namespace MatrixRain.Base.Interfaces
{
    public interface INavSection
    {
        public ConsoleColor SelectedNavItemColor { get; set; }
        public string CurrentItemName();
        public void AddNavItem(string itemName, string displayString);
        public void Up();
        public void Down();
        public string NavSectionString();
    }
}
