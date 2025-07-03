using ApiEmpresas.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Infra.Data.Interfaces
{
    /// <summary>
    /// Interface de repositorio para operações de funcionário
    /// </summary>
    public interface IFuncionarioRepository : IBaseRepository<Funcionario>
    {
        /// <summary>
        /// Método para retornar 1 funcionário baseado no CPF
        /// </summary>
        Funcionario ObterPorCpf(string cpf);

        /// <summary>
        /// Método para retornar 1 funcionário baseado na Matrícula
        /// </summary>
        Funcionario ObterPorMatricula(string matricula);

        /// <summary>
        /// Método para retornar funcionários baseado no nome
        /// </summary>
        List<Funcionario> ObterPorNome(string nome);
    }
}
