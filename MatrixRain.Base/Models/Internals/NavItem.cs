namespace MatrixRain.Base.Models.Internals
{
    internal class NavItem
    {
        public NavItem(string itemName, string itemDisplayString)
        {
            ItemName = itemName;
            ItemDisplayString = itemDisplayString;
        }

        public string ItemName { get; set; }
        public string ItemDisplayString { get; set; }
    }
}
