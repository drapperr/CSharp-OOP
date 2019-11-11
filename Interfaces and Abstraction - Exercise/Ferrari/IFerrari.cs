namespace Ferrari
{
    public interface IFerrari
    {
        public string Model { get; set; }

        public string Driver { get; set; }

        string UseBrakes();

        string PushTheGasPedal();
    }
}
