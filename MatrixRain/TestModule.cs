﻿using MatrixRain.Base.Interfaces;
using MatrixRain.Base.Models;
using MatrixRain.Base.Models.Views;
using MatrixRain.Controllers;
using MatrixRain.Views;

namespace MatrixRain
{
    internal class TestModule : SignalModuleBase
    {
        private readonly TestController controller;

        public TestModule(TestView view, TestController testController) : base(view)
        {
            controller = testController;
        }

        protected override void SignalHandler(object? sender, SignalArgs args)
        {
            if (args.SignalMessage == "yes")
            {
                controller.Action();
            }
        }
    }
}
