using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Argus.Models
{
    public class Raca
    {
        private Contexto db = new Contexto();

        [Key]
        public int CODIGO { get; set; }

        [ForeignKey("Especie")]
        [Display(Name = "Espécie do animal")]
        public Nullable<int> CODIGO_ESPECIE { get; set; }

        [Display(Name = "Nome da Raça")]
        [Required(ErrorMessage = "Por favor preencher o campo Nome da Raça")]
        [StringLength(60)]
        [MaxLength(60)]
        public string NOME { get; set; }

        [Display(Name = "Ativo")]
        public bool ATIVO { get; set; }


        public virtual Especie Especie { get; set; }    

        public void Incluir(Raca raca)
        {
            db.Raca.Add(raca);
            db.SaveChanges();
        }

        public void Atualizar(Raca raca)
        {
            db.Entry(raca).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Eliminar(Raca raca)
        {
            db.Entry(raca).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public Raca Busca(int id)
        {
            return db.Raca.Find(id);
        }

        public List<Raca> ListarRaca(String pesquisa)
        {
            var raca = (from a in db.Raca
                                 where a.NOME.StartsWith(pesquisa)
                                 select a).Take(50).ToList();
            return raca;
        }

        public List<Raca> RelatorioRaca(String pesquisa)
        {
            var raca = (from a in db.Raca
                        where a.NOME.StartsWith(pesquisa)
                        select a).Take(50).ToList();
            return raca;
        }



        //[NotMapped]
        //public HttpPostedFileBase Foto { get; set; }
    }

}