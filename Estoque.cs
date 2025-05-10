public class Vinho
{
    public string SKU { get; set; }
    public string NomeProduto { get; set; }
    public int Safra { get; set; }
    public string Regiao { get; set; }
    public string Tipo { get; set; } // Ex: Tinto, Branco, Rosé, Espumante
    public decimal Preco { get; set; }
    public int QuantidadeEmEstoque { get; set; }
    public string Descricao { get; set; }
    public string ImagePath { get; set; }
    public List<string> Tags { get; set; }

    public Vinho(string sku, string nomeProduto, int safra, string regiao, string tipo, decimal preco, int quantidadeEmEstoque, string descricao, string imagePath, List<string> tags)
    {
        SKU = sku;
        NomeProduto = nomeProduto;
        Safra = safra;
        Regiao = regiao;
        Tipo = tipo;
        Preco = preco;
        QuantidadeEmEstoque = quantidadeEmEstoque;
        Descricao = descricao;
        ImagePath = imagePath;
        Tags = tags ?? new List<string>();
    }

    // Método para adicionar itens ao estoque
    public void AdicionarEstoque(int quantidade)
    {
        if (quantidade > 0)
        {
            QuantidadeEmEstoque += quantidade;
        }
        else
        {
            throw new System.ArgumentOutOfRangeException(nameof(quantidade), "A quantidade para adicionar ao estoque deve ser positiva.");
        }
    }

    // Método para remover itens do estoque
    public bool RemoverEstoque(int quantidade)
    {
        if (quantidade > 0 && QuantidadeEmEstoque >= quantidade)
        {
            QuantidadeEmEstoque -= quantidade;
            return true;
        }
        return false; // Não há estoque suficiente ou quantidade inválida
    }

    // Método para verificar a disponibilidade
    public bool VerificarDisponibilidade(int quantidadeDesejada)
    {
        return QuantidadeEmEstoque >= quantidadeDesejada;
    }
}
