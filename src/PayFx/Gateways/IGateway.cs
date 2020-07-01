using System.Threading.Tasks;
using PayFx.Http;

namespace PayFx
{
    public interface IGateway
    {
        TResponse Execute<TModel, TResponse>(Request<TModel, TResponse> request) where TResponse : IResponse;

        Task<TResponse> ExecuteAsync<TModel, TResponse>(Request<TModel, TResponse> request) where TResponse : IResponse;
    }
}
