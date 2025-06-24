using Microsoft.OpenApi.Models;

namespace ApiEmpresas.Services.Configurations
{
    /// <summary>
    /// Classe para configuração da documentação do Swagger
    /// </summary>
    public static class SwaggerConfiguration
    {
        /// <summary>
        /// Configurar o conteudo da documentação do swagger
        /// </summary>
        public static void AddSwagger(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API para controle de empresas",
                    Description = "Projeto desenvolvido em NET6 API com EntityFramework SqlServer",
                    Contact = new OpenApiContact
                    {
                        Name = "Ryan Mamede",
                        Url = new Uri("https://www.linkedin.com/in/ryan-mamede-799b141aa/"),
<<<<<<< HEAD
                        Email = "ryan.mamede193@gmail.com"
=======
                        Email = "contato@cotiinformatica.com.br"
>>>>>>> 5f279bfd79d33a945523697f3197c6b8029fc887
                    }
                });
            });
        }
    }
}
