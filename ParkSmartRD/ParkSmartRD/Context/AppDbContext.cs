using Microsoft.EntityFrameworkCore;
//Falta un Using para modelos

namespace ParkSmartRD.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        //Se necesita apregar las entidades de modelos
    }
}
