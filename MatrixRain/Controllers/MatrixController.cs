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
        private readonly ISettingsService settingsService;

        public MatrixController(INavigation navigation, IMatrixService matrixService, ISettingsService settingsService) 
            : base(navigation)
        {
            this.matrixService = matrixService;
            this.settingsService = settingsService;
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
            matrixService.RunMatrixRain(settingsService.GetSettings());
        }
    }
}
