using Refit;
using SistemaDeTarefas.Integration.Response;

namespace SistemaDeTarefas.Integration.Refit
{
    public interface IViaCepIntegracaoRefit
    {
        [Get("/ws/{cep}/json")]
        Task<ApiResponse<ViaCepResponse>> ObterDadosViaCep(string cep);
    }
}
