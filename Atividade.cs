namespace atividadeApi
{
    public class Atividade
    {

        public int Id { get; set; }
        public string Descricao { get; set; }

        public DateTime DataAbertura { get; set; }

        public DateTime DataFechamento { get; set; }

        public string Status { get; set; } = "Aberto";
    }
}
