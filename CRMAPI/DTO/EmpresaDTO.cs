namespace CRMAPI.DTO
{
    public class EmpresaDTO
    {
        public int Id_empresa { get; set; }

        public string Razao { get; set; }
        public string Nome_fantasia { get; set; }

        public string CNPJ { get; set; }
        public string CPF { get; set; }

        public bool Ativo { get; set; }

    }
}
