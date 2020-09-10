using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions ;

namespace Argus.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<Veterinario> Veterinario { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Temperamento> Temperamento { get; set; }
        public DbSet<Pelagem> Pelagem { get; set; }
        public DbSet<Cor> Cor { get; set; }
        public DbSet<Raca> Raca { get; set; }
        public DbSet<Especie> Especie { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<MotivoBaixa> MotivoBaixa { get; set; }
        public DbSet<Diagnostico> Diagnostico { get; set; }
        public DbSet<ExameReferencia> ExameReferencia { get; set; }
        public DbSet<ProdutoServico> ProdutoServico { get; set; }
        public DbSet<EspecieCheckup> EspecieCheckup { get; set; }
        public DbSet<AnimalImagem> AnimalImagem { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<TipoVisita> TipoVisita { get; set; }
        public DbSet<ConsultaStatus> ConsultaStatus { get; set; }
        public DbSet<ExameFisico> ExameFisico { get; set; }
        public DbSet<ExameFisicoItem> ExameFisicoItem { get; set; }
        public DbSet<ConsultaProdServ> ConsultaProdServ { get; set; }
        public DbSet<EspecieDoenca> EspecieDoenca { get; set; }
        public DbSet<MedicinaPrev> MedicinaPrev { get; set; }
        public DbSet<Procedimento> Procedimento { get; set; }
        public DbSet<ConsultaExameFisico> ConsultaExameFisico { get; set; }
        public DbSet<ConsultaExameFisicoItem> ConsultaExameFisicoItem { get; set; }
        public DbSet<Exame> Exame { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {
             modelBuilder.Conventions.Remove <PluralizingTableNameConvention> ();
         }
    }

}