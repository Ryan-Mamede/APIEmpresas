using ApiEmpresas.Messages.Services;
using ApiEmpresas.Messages.Settings;
using ApiEmpresas.Services.Authorization;

namespace ApiEmpresas.Services.Configurations
{
    /// <summary>
    /// Classe de configuração para serviço de email
    /// </summary>
    public class MailConfiguration
    {
        public static void AddMail(WebApplicationBuilder builder)
        {
            #region Capturar as configurações do appsettings.json

            var settings = builder.Configuration.GetSection("MailSettings");
            builder.Services.Configure<MailSettings>(settings);
            var mailSettings = settings.Get<MailSettings>();

            #endregion

            #region injeção de dependência do serviço de email
            builder.Services.AddTransient<MailService>(map => new MailService(mailSettings));            
            #endregion
        }
    }
}
