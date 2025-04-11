using ApiEmpresas.Services.Requests;
using ApiEmpresas.Services.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiEmpresas.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(EmpresaPostRequest request)
        {
            var response = new EmpresaResponse
            {
                Id = Guid.NewGuid(),
                NomeFantasia = request.NomeFantasia,
                RazaoSocial = request.RazaoSocial,
                Cnpj = request.Cnpj,
                DataInclusao = DateTime.Now,
                DataUltimaAlteracao = DateTime.Now,
            };

            return StatusCode(201, response);
        }

        [HttpPut]
        public IActionResult Put(EmpresaPutRequest request)
        {
            var response = new EmpresaResponse
            {
                Id = request.IdEmpresa,
                NomeFantasia = request.NomeFantasia,
                RazaoSocial = request.RazaoSocial,
                Cnpj = request.Cnpj,
                DataInclusao = DateTime.Now,
                DataUltimaAlteracao = DateTime.Now,
            };

            return StatusCode(200, response);
        }

        [HttpDelete("{idEmpresa}")]
        public IActionResult Delete(Guid idEmpresa)
        {
            var response = new EmpresaResponse
            {
                Id = idEmpresa,
                NomeFantasia = "Empresa teste",
                RazaoSocial = "Empresa Teste LTDA",
                Cnpj = "44.424.467/0001-34",
                DataInclusao = DateTime.Now,
                DataUltimaAlteracao = DateTime.Now,
            };

            return StatusCode(200, response);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var lista = new List<EmpresaResponse>();

            lista.Add(new EmpresaResponse
            {
                Id = Guid.NewGuid(),
                NomeFantasia = "Empresa teste",
                RazaoSocial = "Empresa Teste LTDA",
                Cnpj = "44.424.467/0001-34",
                DataInclusao = DateTime.Now,
                DataUltimaAlteracao = DateTime.Now,

            });

            lista.Add(new EmpresaResponse
            {
                Id = Guid.NewGuid(),
                NomeFantasia = "Empresa teste",
                RazaoSocial = "Empresa Teste LTDA",
                Cnpj = "44.424.467/0001-34",
                DataInclusao = DateTime.Now,
                DataUltimaAlteracao = DateTime.Now,
            });

            return StatusCode(200, lista);
        }

        [HttpGet("{idEmpresa}")]
        public IActionResult GetById(Guid idEmpresa)
        {
            var response = new EmpresaResponse
            {
                Id = Guid.NewGuid(),
                NomeFantasia = "Empresa Teste",
                RazaoSocial = "Empresa Teste LTDA",
                Cnpj = "44.424.467/0001-34",
                DataInclusao = DateTime.Now,
                DataUltimaAlteracao = DateTime.Now,
            };

            return StatusCode(200, response);
        }


    }
}
