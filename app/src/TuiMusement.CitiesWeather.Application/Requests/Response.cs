using System;

namespace TuiMusement.CitiesWeather.Application.Requests
{
    public class Response<T> where T : class
    {
        private Response(bool isSuccessful, T? value, Exception? exception)
        {
            IsSuccessful = isSuccessful;
            Value = value;
            Exception = exception;
        }

        public bool IsSuccessful { get; }
        public T? Value { get; }
        public Exception? Exception { get; }

        public static Response<T> NewSuccessfulResponse(T value) => new Response<T>(true, value, null);
        public static Response<T> NewFailedResponse(Exception exception) => new Response<T>(false, null, exception);


    }
}