namespace atividadeApi.Models
{
    public class atividade
    {
        public int Id { get; set; }
        public required string titulo { get; set; }

        public required string Descricao { get; set; }

        public DateTime dateAbertura { get; set; }

        public DateTime dataFechamento { get; set; }

        public string Status { get; set; } = "Aberto";
    }
}
