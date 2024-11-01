using GameClub.Infrastructure;
using System.Net;

namespace GameClub.API.Extentions
{
    public static class ErrorExtentions
    {
        public static HttpStatusCode ToHttpStatusCode(this ErrorType errorType)
        {
            switch (errorType)
            {
                case ErrorType.Conflict: return HttpStatusCode.Conflict;
                case ErrorType.NotFound:
                default: return HttpStatusCode.NotFound;
            }
        }
    }
}
