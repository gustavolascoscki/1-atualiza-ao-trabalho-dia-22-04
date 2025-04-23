public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Telefone { get; set; }
}

public class Veiculo
{
    public int Id { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public decimal Preco { get; set; }
}

public class Venda
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }
    public int VeiculoId { get; set; }
    public Veiculo Veiculo { get; set; }
    public DateTime DataVenda { get; set; }
    public decimal ValorFinal { get; set; }
}