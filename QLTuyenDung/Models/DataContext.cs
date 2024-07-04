
using Microsoft.EntityFrameworkCore;


namespace QLTuyenDung.Models
{
    public class DataContext : DbContext
    {

        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbSet<NguoiDung> DSNguoiDung { get; set; }
        public DbSet<TaiKhoan> DSTaiKhoan { get; set; }

        public DbSet<QuyenHan> DSQuyen {  get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                .UseLoggerFactory(loggerFactory);
        }
    }
}
