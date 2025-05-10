using System;
using System.Collections.Generic;

public class TestVinho
{
    public static void Main(string[] args)
    {
        // Criar uma instância de Vinho
        Vinho meuVinho = new Vinho(
            sku: "VN001",
            nomeProduto: "Vinho Tinto Reserva Especial",
            safra: 2020,
            regiao: "Vale dos Vinhedos",
            tipo: "Tinto Seco",
            preco: 150.75m,
            quantidadeEmEstoque: 50,
            descricao: "Um vinho tinto encorpado com notas de frutas vermelhas e carvalho.",
            imagePath: "/img/vinho_reserva.png",
            tags: new List<string> { "Reserva", "Premium", "Tinto" }
        );

        Console.WriteLine($"--- Detalhes Iniciais do Vinho ---");
        ExibirDetalhesVinho(meuVinho);

        // Testar AdicionarEstoque
        Console.WriteLine("\n--- Testando AdicionarEstoque ---");
        Console.WriteLine($"Adicionando 20 unidades...");
        meuVinho.AdicionarEstoque(20);
        Console.WriteLine($"Nova quantidade em estoque: {meuVinho.QuantidadeEmEstoque}"); // Esperado: 70

        try
        {
            Console.WriteLine("\nTentando adicionar -5 unidades (deve falhar)...");
            meuVinho.AdicionarEstoque(-5);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Exceção capturada (esperado): {ex.Message}");
        }
        ExibirDetalhesVinho(meuVinho);

        // Testar RemoverEstoque
        Console.WriteLine("\n--- Testando RemoverEstoque ---");
        Console.WriteLine($"Removendo 15 unidades...");
        bool sucessoRemocao = meuVinho.RemoverEstoque(15);
        Console.WriteLine($"Remoção bem-sucedida: {sucessoRemocao}"); // Esperado: true
        Console.WriteLine($"Nova quantidade em estoque: {meuVinho.QuantidadeEmEstoque}"); // Esperado: 55

        Console.WriteLine("\nTentando remover 100 unidades (mais do que o estoque)...");
        sucessoRemocao = meuVinho.RemoverEstoque(100);
        Console.WriteLine($"Remoção bem-sucedida: {sucessoRemocao}"); // Esperado: false
        Console.WriteLine($"Quantidade em estoque: {meuVinho.QuantidadeEmEstoque}"); // Esperado: 55
        ExibirDetalhesVinho(meuVinho);

        // Testar VerificarDisponibilidade
        Console.WriteLine("\n--- Testando VerificarDisponibilidade ---");
        Console.WriteLine($"Verificando disponibilidade para 30 unidades: {meuVinho.VerificarDisponibilidade(30)}"); // Esperado: true
        Console.WriteLine($"Verificando disponibilidade para 60 unidades: {meuVinho.VerificarDisponibilidade(60)}"); // Esperado: false
    }

    public static void ExibirDetalhesVinho(Vinho vinho)
    {
        Console.WriteLine($"SKU: {vinho.SKU}");
        Console.WriteLine($"Nome: {vinho.NomeProduto}");
        Console.WriteLine($"Safra: {vinho.Safra}");
        Console.WriteLine($"Região: {vinho.Regiao}");
        Console.WriteLine($"Tipo: {vinho.Tipo}");
        Console.WriteLine($"Preço: {vinho.Preco:C}");
        Console.WriteLine($"Estoque: {vinho.QuantidadeEmEstoque}");
        Console.WriteLine($"Descrição: {vinho.Descricao}");
        Console.WriteLine($"Caminho Imagem: {vinho.ImagePath}");
        Console.WriteLine($"Tags: {string.Join(", ", vinho.Tags)}");
    }
}