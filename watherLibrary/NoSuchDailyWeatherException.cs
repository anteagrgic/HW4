using System;
using System.Runtime.Serialization;

[Serializable]
public class NoSuchDailyWeatherException : Exception
{
    public NoSuchDailyWeatherException() { }
    public NoSuchDailyWeatherException(string message) : base(message) { }
    public NoSuchDailyWeatherException(string message, Exception innerException) : base(message, innerException) { }
    protected NoSuchDailyWeatherException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}