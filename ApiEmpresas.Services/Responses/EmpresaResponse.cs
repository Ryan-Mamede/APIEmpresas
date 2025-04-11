namespace ApiEmpresas.Services.Responses
{

    /// <summary>
    /// Modelagem de dados de retorno de empresa na API
    /// </summary>
    public class EmpresaResponse
    {
        public Guid Id { get; set; }
        public string? NomeFantasia { get; set; }
        public string? RazaoSocial {  get; set; }
        public string? Cnpj { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
    }
}
