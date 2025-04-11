using Microsoft.OpenApi.Models;

namespace ApiEmpresas.Services.Configurations
{

    /// <summary>
    /// Classe para configuração da documentação do Swagger
    /// </summary>
    public static class SwaggerConfiguration
    {
        /// <summary>
        /// Configurar o conteúdo da documentação do swagger
        /// </summary>
        public static void AddSwagger(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(s => {
            s.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "API para controle de empresas",
                Description = "Projeto desenvolvido em NET8 API com EntityFramework SqlServer",
                Contact = new OpenApiContact
                {
                    Name = "SES-RJ",
                    Url = new Uri("https://extranet.saude.rj.gov.br/"),
                    Email = "ryan.freires@saude.rj.gov.br"
                }
            });
        });  
        }

        /// <summary>
        /// Configuração a exportação desta documentação
        /// </summary>
        public static void UseSwagger(WebApplicationBuilder builder)
        {

        }
    }
}
