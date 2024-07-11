namespace Compila.AspNetCore.Utils.Application.ServiceResponses
{
    public static class ServiceBaseResponseExtensions
    {
        public static TResultType GetResult<TResultType>(this ServiceBaseResponse response)
        {
            if (response is ServiceOkResponse<TResultType> okResponse)
            {
                return okResponse.Result;
            }

            throw new InvalidOperationException($"Response is not of type ServiceOkResponse<{nameof(TResultType)}>");
        }
    }
}
