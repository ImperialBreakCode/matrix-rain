using MatrixRain.Base.Interfaces;
using MatrixRain.BaseModels;
using MatrixRain.Models;
using MatrixRain.Services.Interfaces;

namespace MatrixRain
{
    public class MatrixRainApp : AppBase
    {
        private readonly IModuleSignalConainer modules;
        private readonly INavigation navigation;
        private readonly ISettingsService settingsService;

        public MatrixRainApp(IModuleSignalConainer container, INavigation navigation, ISettingsService settingsService)
        {
            modules = container;
            this.navigation = navigation;
            this.settingsService = settingsService;
        }

        protected override void PreRun()
        {
            navigation.AddView("Home");

            settingsService.EnsureSettings();
            settingsService.SetRefreshAction(RestartSettings);
            settingsService.Refresh();

            CanRun = true;
            IsRunning = true;
        }

        protected override void AppLoop()
        {
            while (IsRunning)
            {
                Console.Clear();
                modules.Container[navigation.CurrentView()].Run();
            }
        }

        private void RestartSettings()
        {
            Settings settings = settingsService.GetSettings();

            foreach (var module in modules.Container)
            {
                module.Value.View.BaseColor = settings.InterfaceColor;
                module.Value.View.ChangeNavItemSelectionColor(settings.SelectionColor);
            }
        }
    }
}
