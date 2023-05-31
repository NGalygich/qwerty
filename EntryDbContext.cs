using Microsoft.EntityFrameworkCore;

public class rpt_InfProfitabilityOVLContext : DbContext
{
    public DbSet<rpt_InfProfitabilityOVL> rpt_InfProfitabilityOVL { get; set; } = null!;
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"data source=192.168.0.116;
		 Initial Catalog=cdt_go_te;
		 user id=sa;
		 password=compasdt;
		 Integrated Security=false;
		 Trusted_Connection=False;
		 Persist Security Info=True;
		 MultipleActiveResultSets=true;
         TrustServerCertificate=Yes");
    }
}