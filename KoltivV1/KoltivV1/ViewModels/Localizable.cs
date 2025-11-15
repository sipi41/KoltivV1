namespace KoltivV1.ViewModels
{
    public class Localizable : ILocalizable
    {
        public float lat { get; set; }
        public float lng { get; set; }
        public int zoom { get; set; } = 4;
    }
}
