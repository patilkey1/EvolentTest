using DBMapper.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DBMapper
{
    public class EFDBContext : DbContext, IDisposable
    {

        private static EFDBContext context = null;

        public static EFDBContext contextInstance
        {
            get
            {
                if (context == null)
                {
                    context = new EFDBContext();
                }
                return context;
            }
        }

        public EFDBContext()
            : base("name=ConString")
        {
            Database.CommandTimeout = 600;
        }

        ~EFDBContext()
        {
            context = null;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
           .Where(type => !String.IsNullOrEmpty(type.Namespace))
           .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<ContactInfo> ContactInfo { get; set; }
    }
}
