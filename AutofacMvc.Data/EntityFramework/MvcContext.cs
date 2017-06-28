using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Cp.Core.Domain.TestModels;

namespace CpMvc.Data.EntityFramework
{
    public class MvcContext:NopObjectContext
    {
        public MvcContext(string nameOrConnectionString) : 
            base(nameOrConnectionString)
        {

        }

        public MvcContext() : base("name=connectionstring")
        {

        }



        public virtual IDbSet<Student> Students { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}