using PayFx.Request;
using PayFx.Response;

namespace PayFx
{
    public interface IGateway
    {
        TResponse Execute<TModel, TResponse>(Request<TModel, TResponse> request) where TResponse : IResponse;
    }
}
