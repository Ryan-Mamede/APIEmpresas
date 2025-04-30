using ApiEmpresas.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Infra.Data.Interfaces
{
    /// <summary>
    /// Interface de repositorio para operações de empresa
    /// </summary>
    public interface IEmpresaRepository : IBaseRepository<Empresa>
    {
        /// <summary>
        /// Método para consultar 1 Empresa através do Cnpj
        /// </summary>
        Empresa ObterPorCnpj(string cnpj);
    }
}
