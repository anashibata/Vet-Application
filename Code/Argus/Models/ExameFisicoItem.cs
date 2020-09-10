using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Argus.Models
{
    public class ExameFisicoItem
    {
        private Contexto db = new Contexto();

        [Key]        
        public int CODIGO { get; set; }

        [ForeignKey("ExameFisico")]
        public int CODIGO_EXAMEFIS { get; set; }

        public int CODIGO_ITEM { get; set; }

        [Display(Name = "Item do exame")]
        [Required(ErrorMessage = "Por favor preencher o item do exame")]
        public string NOME { get; set; }

        public virtual ExameFisico ExameFisico { get; set; } 

        public void Incluir(ExameFisicoItem examefisicoitem)
        {
            var item = (from e in db.ExameFisicoItem
                           where e.CODIGO_EXAMEFIS == examefisicoitem.CODIGO_EXAMEFIS
                           select e.CODIGO_ITEM) ;

            if (item.Count()>0)
            {

                examefisicoitem.CODIGO_ITEM = item.Max() + 1;
            }
            else
                examefisicoitem.CODIGO_ITEM = 1;

            db.ExameFisicoItem.Add(examefisicoitem);
            db.SaveChanges();
        }

        public void Atualizar(ExameFisicoItem examefisicoitem)
        {
            db.Entry(examefisicoitem).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Eliminar(ExameFisicoItem examefisicoitem)
        {
            db.Entry(examefisicoitem).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public ExameFisicoItem Busca(int id)
        {
            return db.ExameFisicoItem.Find(id);
        }

        public List<ExameFisicoItem> ListarExameFisicoItem(int codigo, String pesquisa)
        {
            var examefisicoitem = (from a in db.ExameFisicoItem
                               where a.CODIGO_EXAMEFIS==codigo && a.NOME.StartsWith(pesquisa)
                               select a).Take(50).ToList();
            return examefisicoitem;
        }
    }

}