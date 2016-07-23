namespace CleanCode
{
    internal interface IWebApiService
    {
        void Error(string error);
        void Info(string error);
        void Warning(string error);
        void Trace(string error);
    }
}