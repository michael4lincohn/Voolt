namespace Voolt.Test.Blazor.Services.Extensions
{
    public static class HttpObjectsExtensions
    {
        public static bool TryReadFromJsonAsync<TResult>(this HttpContent content, out TResult result)
            where TResult : class, new()
        {
            try
            {
                result = content.ReadFromJsonAsync<TResult>().Result;
                return true;
            }
            catch (Exception)
            {
                result = new TResult();
                return false;
            }
        }
    }
}