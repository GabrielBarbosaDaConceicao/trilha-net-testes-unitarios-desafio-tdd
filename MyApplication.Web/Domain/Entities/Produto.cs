namespace MyApplication.Web.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;

        public Produto()
        { 
        }

        public Produto(int id, string nome, string descricao)
        {
            Id = id;
            Validation(nome, descricao);
        }

        public List<Produto> produtos { get; set; } = new List<Produto>();

        public bool IdEPar()
        {
            var resultado = Id % 2 == 0;
            return resultado;
        }

        public int IdEMenorOuIgualAZero()
        {
            if (Id <= 0)
                return Id + 1;
            return Id;
        }

        public int TamnhoDoNome()
        {
            int resultado = Nome.Length;

            return resultado;
        }

        public string TestarNome()
        {
            string resultado = Nome;

            return resultado;
        }

        public string TestarDescricao()
        {
            string resultado = Descricao;

            return resultado;
        }

        public bool DescricaoENull()
        {
            var resultado = Descricao;

            if (resultado is null)
                return true;

            return false;
        }

        public bool DescricaoEVazio()
        {
            var resultado = Descricao;

            if (resultado == string.Empty)
                return true;

            return false;
        }

        public void AddProduto(Produto produto)
        {
            produtos.Add(produto);
        }

        public int QuantidadeDeProdutosNaLista(List<Produto> produtos)
        {
            return produtos.Count;
        }

        public bool ListaTemAlgunItem()
        {
            return produtos.Any();
        }

        public void Validation(string nome, string descricao)
        {
            if (nome == null)
                throw new ArgumentNullException("O nome é obrigatório");

            if(descricao == null)
                throw new ArgumentNullException("A descrição é obrigatório");

            Nome = nome;
            Descricao = descricao;
        }
    }
}
