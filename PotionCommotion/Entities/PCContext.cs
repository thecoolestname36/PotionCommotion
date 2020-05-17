using System.Data.Entity;
using SQLite.CodeFirst;

namespace PotionCommotion.Entities {
	public class PCContext : DbContext {

		public DbSet<Potion> Potions { get; set; }
		public PCContext() : base("PCContextConnection") {
		}
		
		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			var sqliteConnectionInitializer = new SqliteDropCreateDatabaseAlways<PCContext>(modelBuilder);
			Database.SetInitializer(sqliteConnectionInitializer);
		}

	}

}
