using Microsoft.EntityFrameworkCore;

namespace ApiRest.Database.Context;

public class CustomContext : DatabaseContext
{
    public CustomContext(DbContextOptions<CustomContext> options) : base(options)
    {
    }
}