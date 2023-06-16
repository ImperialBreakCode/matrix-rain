namespace MatrixRain.Base.Models.Views
{
    public class SignalArgs : EventArgs
    {
        private readonly string signalMessage;
        private readonly string? data;

        public SignalArgs(string signalMessage, string? data)
        {
            this.signalMessage = signalMessage;
            this.data = data;
        }

        public string SignalMessage => signalMessage;
        public string? Data => data;
    }
}
