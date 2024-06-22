namespace Compila.AspNetCore.Utils.Application.ServiceResponses
{
    public class ServiceOkResponse<TResult> : ServiceBaseResponse
    {
        public TResult Result { get; set; }

        public ServiceOkResponse(TResult result) : base(true) => Result = result;

    }

    public class ServiceOkResponse : ServiceBaseResponse
    {
        public ServiceOkResponse() : base(true) { }
    }

    public class ServiceCreatedResponse : ServiceBaseResponse
    {
        public ServiceCreatedResponse() : base(true) { }
    }

    public class ServiceCreatedResponse<TResult> : ServiceBaseResponse
    {
        public TResult Result { get; set; }
        public ServiceCreatedResponse(TResult result) : base(true) => Result = result;
    }

    public class ServiceNoContentResponse : ServiceBaseResponse
    {
        public ServiceNoContentResponse() : base(true) { }
    }
}
