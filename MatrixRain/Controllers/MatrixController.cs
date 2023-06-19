using MatrixRain.Base.Interfaces;
using MatrixRain.Base.Models;
using MatrixRain.Constants;
using MatrixRain.Services.Interfaces;
using ModuleGenerator.Tools.Attributes;

namespace MatrixRain.Controllers
{
    [SignalConnector("MatrixView")]
    public class MatrixController : Controller
    {
        private readonly IMatrixService matrixService;

        public MatrixController(INavigation navigation, IMatrixService matrixService) : base(navigation)
        {
            this.matrixService = matrixService;
        }

        [ForSignal("nav")]
        public void Nav(string data)
        {
            if (data == Routes.Back)
            {
                Navigation.GoBack();
            }
        }

        public void StartMatrix()
        {
            matrixService.RunMatrixRain();
        }
    }
}
