namespace C_Projeto3.Model.Dtos
{
    public class ProdutoEstoqueDto
    {
        public Guid ProdutoId { get; set; }  
        public string Nome { get; set; }     
        public double QuantidadeEmEstoque { get; set; }  
    }
}