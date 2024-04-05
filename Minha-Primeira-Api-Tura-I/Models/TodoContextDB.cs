using Microsoft.EntityFrameworkCore;

namespace Minha_Primeira_Api_Tura_I.Models
{
    public class TodoContextDB : DbContext
    {
        public TodoContextDB(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TodoItemModel> TodoItemModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItemModel>()
                 .Property(p => p.Cadastro)
                 .HasDefaultValueSql("GETDATE()");

#if DEBUG

            modelBuilder.Entity<TodoItemModel>().
                HasData(new TodoItemModel
                {
                    Id = 1,
                    Nome = "Teste UM",
                    Apelido = "UM",
                    Ativo = true,
                    Cadastro = DateTime.Now
                },
                new TodoItemModel
                {
                    Id = 2,
                    Nome = "Teste DOIS",
                    Ativo = false,
                    Cadastro = DateTime.Now
                });
#endif

            base.OnModelCreating(modelBuilder);
        }
    }
}
