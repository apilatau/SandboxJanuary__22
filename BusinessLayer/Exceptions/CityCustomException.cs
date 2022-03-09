namespace BusinessLayer.Exceptions
{
    public class CityCustomException : Exception
    {
        public CityCustomException() { }
        public CityCustomException(string message) : base(message) { }
    }
}