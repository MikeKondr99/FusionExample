namespace Gateway
{
    public class ErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            var r = error.Exception;
            return error;
        }
    }
}
