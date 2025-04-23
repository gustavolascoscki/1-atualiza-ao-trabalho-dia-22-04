[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IClienteRepository _repo;
    private readonly ApplicationDbContext _context;

    public ClienteController(IClienteRepository repo, ApplicationDbContext context)
    {
        _repo = repo;
        _context = context;
    }

    [HttpGet]
    public IActionResult Get() => Ok(_repo.ListarTodos());

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var cliente = _repo.BuscarPorId(id);
        if (cliente == null) return NotFound();
        return Ok(cliente);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Cliente cliente)
    {
        _repo.Adicionar(cliente);
        _context.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Cliente cliente)
    {
        if (id != cliente.Id) return BadRequest();
        _repo.Atualizar(cliente);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _repo.Remover(id);
        _context.SaveChanges();
        return NoContent();
    }
}

[ApiController]
[Route("api/[controller]")]
public class VeiculoController : ControllerBase
{
    private readonly IVeiculoRepository _repo;
    private readonly ApplicationDbContext _context;

    public VeiculoController(IVeiculoRepository repo, ApplicationDbContext context)
    {
        _repo = repo;
        _context = context;
    }

    [HttpGet]
    public IActionResult Get() => Ok(_repo.ListarTodos());

    [HttpPost]
    public IActionResult Post([FromBody] Veiculo veiculo)
    {
        _repo.Adicionar(veiculo);
        _context.SaveChanges();
        return Ok();
    }
}

[ApiController]
[Route("api/[controller]")]
public class VendaController : ControllerBase
{
    private readonly IVendaRepository _repo;
    private readonly ApplicationDbContext _context;

    public VendaController(IVendaRepository repo, ApplicationDbContext context)
    {
        _repo = repo;
        _context = context;
    }

    [HttpGet]
    public IActionResult Get() => Ok(_repo.ListarTodos());

    [HttpPost]
    public IActionResult Post([FromBody] Venda venda)
    {
        _repo.Adicionar(venda);
        _context.SaveChanges();
        return Ok();
    }
}
