using ApiEmpresas.Infra.Data.Entities;
using ApiEmpresas.Infra.Data.Interfaces;
using ApiEmpresas.Messages.Services;
using ApiEmpresas.Services.Requests;
using ApiEmpresas.Services.Utils;
using Bogus;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiEmpresas.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordRecoverController : ControllerBase
    {
        //Atributos
        private readonly IUnitOfWork _unitOfWork;
        private readonly MailService _mailService;

        //constructor para injeção de dependência
        public PasswordRecoverController(IUnitOfWork unitOfWork, MailService mailService)
        {
            _unitOfWork = unitOfWork;
            _mailService = mailService;
        }

        [HttpPost]
        public IActionResult Post(PasswordRecoverPostRequest request)
        {
            try
            {
                //buscar usuario no banco de dados através do email
                var usuario = _unitOfWork.UsuarioRepository.Obter(request.Email);

                //verificar se o usuário foi encontrado
                if (usuario != null)
                {
                    #region
                    var novaSenha = new Faker().Internet.Password();
                    EnviarEmailDeRecuperacaoDeSenha(usuario, novaSenha);
                    #endregion

                    #region
                    usuario.Senha = Criptografia.GetMD5(novaSenha);
                    _unitOfWork.UsuarioRepository.Alterar(usuario);
                    #endregion



                    return StatusCode(200, new { message = "Recuperação de senha realizada com sucesso, por favor verifique seu email." });
                }
                else
                {
                    return StatusCode(422, new { message = "O email informado não foi encontrado, por favor verifique" });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        private void EnviarEmailDeRecuperacaoDeSenha(Usuario usuario, string novaSenha)
        {
            var assunto = "Recuperação de senha";
            var mensagem = $@"
                            <div style='text-align: center; margin: 40px; padding: 
                            60px; border: 2px solid #ccc; font-size: 16pt;'>
                                                 <img 
                            src='' />
                            <br/><br/>
                            Olá <strong>{usuario.Nome}</strong>,
                            <br/><br/>    
                            O sistema gerou uma nova senha para que você possa 
                            acessar sua conta.<br/>
                            Por favor utilize a senha: <strong>{novaSenha}</strong>
                            <br/><br/>
                            Não esqueça de, ao acessar o sistema, atualizar esta senha para outra
                            de sua preferência.
                            <br/><br/>              
                            Att<br/>   
                            Ryan Mamede
                            </div>

                            ";
            _mailService.SendMail(usuario.Email, assunto, mensagem);
        }
    }
}
