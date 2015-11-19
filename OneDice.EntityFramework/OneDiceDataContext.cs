namespace OneDice.EntityFramework
{
    using OneDice.Core;
using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

    public class OneDiceDataContext : DbContext
    {
        // Your context has been configured to use a 'OneDiceDataContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'OneDice.EntityFramework.OneDiceDataContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'OneDiceDataContext' 
        // connection string in the application configuration file.
        public OneDiceDataContext()
            : base("name=OneDiceDataContext")
        {
        }

        public new IDbSet<T> Set<T>() where T : Entity
        {
            return base.Set<T>();
        }
        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes() //load maps
            .Where(type => type.Name.EndsWith("Map"));
           //.Where(type => !String.IsNullOrEmpty(type.Namespace))
           //.Where(type => type.BaseType != null && type.BaseType.IsGenericType
           //     && type.BaseType.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>)));//.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }
    
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}