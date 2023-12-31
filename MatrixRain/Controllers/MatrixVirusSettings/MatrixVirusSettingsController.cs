﻿using MatrixRain.Base.Interfaces;
using MatrixRain.Base.Models;
using MatrixRain.Constants;
using MatrixRain.Services.Interfaces;
using MatrixRain.Views;
using ModuleGenerator.Tools.Attributes;

namespace MatrixRain.Controllers
{
    [SignalConnector("MatrixVirusSettingsView")]
    public class MatrixVirusSettingsController : Controller
    {
        private ISettingsService settingsService;

        public MatrixVirusSettingsController(INavigation navigation, ISettingsService settingsService) : base(navigation)
        {
            this.settingsService = settingsService;
        }

        public void ChangeText(string text)
        {
            var settings = settingsService.GetSettings();
            settings.Text = text;
            settingsService.UpdateSettings(settings);
        }

        public void ChangeSettings(string data)
        {
            string[] dataArr = data.Split('-');

            MatrixVirusSettings setting;
            ConsoleColor consoleColor;

            Enum.TryParse(dataArr[0], out setting);
            Enum.TryParse(dataArr[1], out consoleColor);

            var settings = settingsService.GetSettings();

            switch (setting)
            {
                case MatrixVirusSettings.TextColor:
                    settings.TextColor = consoleColor;
                    settingsService.UpdateSettings(settings);
                    break;
                case MatrixVirusSettings.SkullColor:
                    settings.SkullColor = consoleColor;
                    settingsService.UpdateSettings(settings);
                    break;
                default:
                    break;
            }
        }

        [ForSignal("nav")]
        public void Nav(string data)
        {
            MatrixVirusSettings setting;
            Enum.TryParse(data, out setting);

            switch (setting)
            {
                case MatrixVirusSettings.MatrixColor:
                    Navigation.AddView(Routes.RegularMatrixColorView);
                    break;

                case MatrixVirusSettings.BrokenMatrixColor:
                    Navigation.AddView(Routes.BrokenMatrixColorView);
                    break;

                default:
                    break;
            }
        }

        public void GoBack()
        {
            Navigation.GoBack();
        }
    }
}
