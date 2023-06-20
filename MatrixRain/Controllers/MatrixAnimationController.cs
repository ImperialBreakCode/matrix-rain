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
        private readonly ISettingsService settingsService;

        public MatrixAnimationController(INavigation navigation, IMatrixService matrixService, ISettingsService settingsService) 
            : base(navigation)
        {
            this.matrixService = matrixService;
            this.settingsService = settingsService;
        }

        public void StartMatrix()
        {
            matrixService.RunMatrixAnimation(settingsService.GetSettings());
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
