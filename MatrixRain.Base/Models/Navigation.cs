using MatrixRain.Base.Interfaces;
using MatrixRain.Base.Constants;
using MatrixRain.Base.Models.Exceptions;

namespace MatrixRain.Base.Models
{
    public class Navigation : INavigation
    {
        private readonly Stack<string> route;

        public Navigation()
        {
            route = new Stack<string>();
        }

        public void AddView(string viewName)
        {
            route.Push(viewName);
        }

        public string CurrentView()
        {
            return route.Peek();
        }

        public void GoBack()
        {
            if (route.Count == 0)
            {
                throw new MatrixRainException(ExMessages.NoParentView);
            }

            route.Pop();
        }
    }
}
