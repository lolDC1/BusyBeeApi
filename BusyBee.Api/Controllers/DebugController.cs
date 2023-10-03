using BusyBee.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusyBee.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DebugController : ControllerBase
{
    private readonly DatabaseContext _context;

    public DebugController(DatabaseContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    [Route("migrations")]
    public IEnumerable<string> GetMigrations()
    {
        return _context.Database.GetMigrations();
    }
}