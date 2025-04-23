public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Veiculo> Veiculos { get; set; }
    public DbSet<Venda> Vendas { get; set; }
}

public interface IClienteRepository
{
    IEnumerable<Cliente> ListarTodos();
    Cliente BuscarPorId(int id);
    void Adicionar(Cliente cliente);
    void Atualizar(Cliente cliente);
    void Remover(int id);
}

public interface IVeiculoRepository
{
    IEnumerable<Veiculo> ListarTodos();
    Veiculo BuscarPorId(int id);
    void Adicionar(Veiculo veiculo);
    void Atualizar(Veiculo veiculo);
    void Remover(int id);
}

public interface IVendaRepository
{
    IEnumerable<Venda> ListarTodos();
    Venda BuscarPorId(int id);
    void Adicionar(Venda venda);
}

public class ClienteRepository : IClienteRepository
{
    private readonly ApplicationDbContext _context;

    public ClienteRepository(ApplicationDbContext context) => _context = context;

    public void Adicionar(Cliente cliente) => _context.Clientes.Add(cliente);
    public Cliente BuscarPorId(int id) => _context.Clientes.Find(id);
    public IEnumerable<Cliente> ListarTodos() => _context.Clientes.ToList();
    public void Remover(int id)
    {
        var cliente = BuscarPorId(id);
        if (cliente != null)
            _context.Clientes.Remove(cliente);
    }
    public void Atualizar(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
    }
}

public class VeiculoRepository : IVeiculoRepository
{
    private readonly ApplicationDbContext _context;

    public VeiculoRepository(ApplicationDbContext context) => _context = context;

    public void Adicionar(Veiculo veiculo) => _context.Veiculos.Add(veiculo);
    public Veiculo BuscarPorId(int id) => _context.Veiculos.Find(id);
    public IEnumerable<Veiculo> ListarTodos() => _context.Veiculos.ToList();
    public void Remover(int id)
    {
        var veiculo = BuscarPorId(id);
        if (veiculo != null)
            _context.Veiculos.Remove(veiculo);
    }
    public void Atualizar(Veiculo veiculo)
    {
        _context.Veiculos.Update(veiculo);
    }
}

public class VendaRepository : IVendaRepository
{
    private readonly ApplicationDbContext _context;

    public VendaRepository(ApplicationDbContext context) => _context = context;

    public void Adicionar(Venda venda) => _context.Vendas.Add(venda);
    public Venda BuscarPorId(int id) => _context.Vendas.Find(id);
    public IEnumerable<Venda> ListarTodos() => _context.Vendas
        .Include(v => v.Cliente)
        .Include(v => v.Veiculo)
        .ToList();
}