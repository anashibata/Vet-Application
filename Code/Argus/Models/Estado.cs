using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Argus.Models
{
    public class Estado
    {
        private Contexto db = new Contexto();

        [Key]
        public int CODIGO { get; set; }        

        [Display(Name = "Nome do Estado")]
        [Required(ErrorMessage = "Por favor preencher o campo Nome do Estado")]
        [StringLength(60)]
        [MaxLength(60)]
        public string NOME { get; set; }

        [Display(Name = "Ativo")]
        public bool ATIVO { get; set; }

        [Display(Name = "Sigla")]
        [Required(ErrorMessage = "Por favor preencher o campo Sigla")]
        public string UF { get; set; }
      
        public void Incluir(Estado estado)
        {
            db.Estado.Add(estado);
            db.SaveChanges();
        }

        public void Atualizar(Estado estado)
        {
            db.Entry(estado).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Eliminar(Estado estado)
        {
            db.Entry(estado).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public Estado Busca(int id)
        {
            return db.Estado.Find(id);
        }

        public List<Estado> ListarEstado(String pesquisa)
        {
            var estado = (from a in db.Estado
                          where a.NOME.StartsWith(pesquisa)
                          select a).Take(50).ToList();
            return estado;
        }


       
        //[NotMapped]
        //public HttpPostedFileBase Foto { get; set; }
    }

}