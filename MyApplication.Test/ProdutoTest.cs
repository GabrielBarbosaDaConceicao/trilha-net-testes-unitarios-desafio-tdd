using MyApplication.Web.Domain.Entities;

namespace MyApplication.Test
{
    public class ProdutoTest
    {
        Produto produto = new Produto();

        [Theory]
        [InlineData(1, "Nome", "Descrição")]
        public void ValidarObjetoProduto(int id, string nome, string descricao)
        {
            var p1 = new List<Produto>()
            {
                new Produto(id, nome, descricao)
            };

            Assert.NotEmpty(p1);
            Assert.NotNull(p1);
            Assert.True(p1.Any());
            Assert.False(p1.Count < 0);

        }

        [Fact]
        public void TastarId()
        {
            produto.Id = 2;

            var resultado = produto.IdEPar();

            Assert.True(resultado);
        }

        [Theory]
        [InlineData(1)]
        public void TestarSeIdEMaiorIualAZero_RetornoValido(int id1)
        {
            produto.Id = id1;

            var resltado = produto.IdEMenorOuIgualAZero();

            Assert.Equal(1, resltado);
        }


        [Theory]
        [InlineData("Carlos")]
        public void TesteNome(string nome)
        {
            produto.Nome = nome;

            var resltado = produto.TestarNome();

            Assert.Equal(nome, resltado);
        }

        [Fact]
        public void NomeNaoPodeSerNulo()
        {
            produto.Nome = "notNull";

            Assert.NotNull(produto.Nome);
        }

        [Fact]
        public void TesteTamnhoNome()
        {
            produto.Nome = "123456789";

            var resultado = produto.TamnhoDoNome();

            Assert.Equal(9, resultado);
        }

        [Fact]
        public void TesteDescricao()
        {
            produto.Descricao = "Descricao";

            var resultado = produto.TestarDescricao();

            Assert.Equal("Descricao", resultado);
            Assert.NotEmpty(produto.Descricao);
            Assert.NotNull(produto.Descricao);
            Assert.Equal(9, resultado.Length);
        }

        [Fact]
        public void DescricaoENullo()
        {
            produto.Descricao = "Minha Descrição";

            var resultado = produto.DescricaoENull();

            Assert.False(resultado);
        }

        [Fact]
        public void DescricaoENullo_RetornoNullo()
        {
            produto.Descricao = null;

            var resultado = produto.DescricaoENull();

            Assert.True(resultado);
        }

        [Fact]
        public void DescricaoNotEmpty_RetornoNotEmpty()
        {
            produto.Descricao = "Not Empty";

            var resultado = produto.DescricaoEVazio();

            Assert.False(resultado);
        }

        [Fact]
        public void DescricaoIsEmpty_RetornoEmpty()
        {
            produto.Descricao = string.Empty;

            var resultado = produto.DescricaoEVazio();

            Assert.True(resultado);
        }

        [Fact]
        public void TesteListaProdutos()
        {
            produto.AddProduto(new Produto(1, "Teste 1", "Descrição 1"));
            produto.AddProduto(new Produto(2, "Teste 2", "Descrição 2"));
            produto.AddProduto(new Produto(3, "Teste 3", "Descrição 3"));

            Assert.NotEmpty(produto.produtos);
            Assert.NotNull(produto.produtos);
            Assert.Equal(3, produto.produtos.Count());
        }

        [Fact]
        public void VerificarLista_QuantosItensNaLista_RetornaQuanidade()
        {
            List<Produto> produtos = new List<Produto>();
            produtos.Add(new Produto(1, "Teste 1", "Descrição 1"));
            produtos.Add(new Produto(2, "Teste 2", "Descrição 2"));
            produtos.Add(new Produto(3, "Teste 3", "Descrição 3"));

            var resultado = produto.QuantidadeDeProdutosNaLista(produtos);

            Assert.Equal(3, resultado);
            Assert.True(resultado > 0);
        }

        [Fact]
        public void VerificarLista_TemItensNaLista_RetornoValido()
        {
            
            produto.AddProduto(new Produto(1, "Teste 1", "Descrição 1"));

            var resultado = produto.ListaTemAlgunItem();

            Assert.True(resultado);
        }
                      
        [Fact]
        public void Validation_NomeNulo_DeveLancarExcecao()
        {
            string nome = null;
            string descricao = "Descrição válida";
            var produto = new Produto();

            Assert.Throws<ArgumentNullException>(() => produto.Validation(nome, descricao));
        }

        [Fact]
        public void Validation_DescricaoNula_DeveLancarExcecao()
        {
            string nome = "Nome válido";
            string descricao = null;
            var produto = new Produto();

            Assert.Throws<ArgumentNullException>(() => produto.Validation(nome, descricao));
        }

    }
}