namespace C_Projeto3.Model;

public class ProdutoEstoqueDto
{
    public Guid ProdutoId { get; set; }
    public string Nome { get; set; }
    public int QuantidadeEmEstoque { get; set; }
}