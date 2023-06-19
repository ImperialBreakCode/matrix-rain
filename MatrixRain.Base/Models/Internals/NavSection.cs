using MatrixRain.Base.Interfaces;
using MatrixRain.Base.Constants;
using MatrixRain.Base.Models.Exceptions;

namespace MatrixRain.Base.Models.Internals
{
    internal class NavSection : INavSection
    {
        private readonly List<NavItem> navItems;
        private int currentItem;

        public NavSection()
        {
            navItems = new List<NavItem>();
            SelectedNavItemColor = ConsoleColors.BaseSelectionColor;
            currentItem = -1;
        }

        public ConsoleColor SelectedNavItemColor { get; set; }

        public void AddNavItem(string itemName, string displayString)
        {
            if (navItems.Any(i => i.ItemName == itemName))
            {
                throw new MatrixRainException(ExMessages.NavItemAlreadyAdded);
            }

            NavItem navItem = new NavItem(itemName, displayString);
            navItems.Add(navItem);

            if (navItems.Count == 1)
            {
                currentItem = 0;
            }
        }

        public void Up()
        {
            if (currentItem == -1)
            {
                throw new MatrixRainException(ExMessages.NoNavItemAdded);
            }
            else if (currentItem > 0)
            {
                currentItem--;
            }
        }

        public void Down()
        {
            if (currentItem == -1)
            {
                throw new MatrixRainException(ExMessages.NoNavItemAdded);
            }
            else if (currentItem < navItems.Count - 1)
            {
                currentItem++;
            }
        }

        public void PrintNav()
        {
            for (int i = 0; i < navItems.Count; i++)
            {
                if (i == currentItem)
                {
                    var currentColor = Console.ForegroundColor;

                    Console.ForegroundColor = SelectedNavItemColor;
                    Console.WriteLine($"\t  > {navItems[i].ItemDisplayString}");
                    Console.ForegroundColor = currentColor;
                }
                else
                {
                    Console.WriteLine($"\t{navItems[i].ItemDisplayString}");
                }
            }
        }

        public string CurrentItemName()
        {
            if (currentItem == -1)
            {
                throw new MatrixRainException(ExMessages.NoNavItemAdded);
            }

            return navItems.Where((item, index) => index == currentItem)
                .Select(i => i.ItemName)
                .First();
        }
    }
}
