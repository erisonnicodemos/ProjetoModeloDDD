using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
   public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
       public ClienteConfiguration()
       {
           HasKey(c => c.ClienteId);
           Property(c => c.Nome)
                  .IsRequired()
                  .HasMaxLength(150);

           Property(c => c.SobreNome)
                  .IsRequired()
                  .HasMaxLength(150);

           Property(c => c.Email)
                  .IsRequired();


       }
    }
}
