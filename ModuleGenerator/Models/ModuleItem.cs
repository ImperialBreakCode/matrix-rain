using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleGenerator.Models
{
    internal class ModuleItem
    {
        private readonly List<ActionItem> actionList;

        public ModuleItem()
        {
            actionList = new List<ActionItem>();
        }

        public List<ActionItem> ActionList => actionList;
        public string ViewName { get; set; }
        public string ViewNameSpace { get; set; }
        public string Controller { get; set; }
        public string ControllerNameSpace { get; set; }
    }
}
