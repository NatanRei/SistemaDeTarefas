using SistemaDeTarefas.Integration.Response;

namespace SistemaDeTarefas.Integration.Interfaces
{
    public interface IViaCepIntegracao
    {
        Task<ViaCepResponse> ObterDadosViaCep(string cep);
    }
}
