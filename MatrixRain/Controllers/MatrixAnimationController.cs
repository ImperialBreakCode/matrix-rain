using MatrixRain.Base.Interfaces;
using MatrixRain.Base.Models;
using MatrixRain.Constants;
using MatrixRain.Services.Interfaces;
using ModuleGenerator.Tools.Attributes;

namespace MatrixRain.Controllers
{
    [SignalConnector("MatrixAnimationView")]
    public class MatrixAnimationController : Controller
    {
        private readonly IMatrixService matrixService;

        public MatrixAnimationController(INavigation navigation, IMatrixService matrixService) : base(navigation)
        {
            this.matrixService = matrixService;
        }

        public void StartMatrix()
        {
            matrixService.RunMatrixAnimation();
        }

        [ForSignal("nav")]
        public void GoBack(string data)
        {
            if (data == Routes.Back)
            {
                Navigation.GoBack();
            }
        }
    }
}
