﻿using MatrixRain.Base.Interfaces;
using MatrixRain.Base.Models;
using ModuleGenerator.Tools.Attributes;

namespace MatrixRain.Controllers
{
    [SignalConnector("TestView")]
    internal class TestController : Controller
    {
        public TestController(INavigation navigation) : base(navigation)
        {
        }

        [ForSignal("smth")]
        public void Action()
        {
            Console.WriteLine("this is a console action");
        }

        public void ActionOne()
        {
            Console.WriteLine("this is action one");
        }
    }
}
