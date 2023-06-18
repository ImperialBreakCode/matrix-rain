namespace ModuleGenerator.Models
{
    internal class ActionItem
    {
        public ActionItem(string actionName, string forSignal, bool hasData)
        {
            ActionName = actionName;
            ForSignal = forSignal;
            HasData = hasData;
        }

        public string ActionName { get; set; }
        public string ForSignal { get; set; }
        public bool HasData { get; set; }
    }
}
