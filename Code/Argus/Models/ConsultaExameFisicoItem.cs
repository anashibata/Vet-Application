using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Argus.Models
{
    public class ConsultaExameFisicoItem
    {
        private Contexto db = new Contexto();

        [ForeignKey("ConsultaExameFisico")]
        [Key, Column(Order = 1)]
        public int CODIGO_CONEXAFIS { get; set; }

        [ForeignKey("ExameFisicoItem")]
        [Key, Column(Order = 2)]
        public int CODIGO_EXAMEFISITEM { get; set; }

        [Display(Name = "Resultado: ")]        
        [StringLength(60)]
        [MaxLength(60)]
        public string RESULTADO { get; set; }

        public virtual ConsultaExameFisico ConsultaExameFisico { get; set; }
        public virtual ExameFisicoItem ExameFisicoItem { get; set; }

        public void Incluir(ConsultaExameFisicoItem consultaexamefisicoitem)
        {
            db.ConsultaExameFisicoItem.Add(consultaexamefisicoitem);
            db.SaveChanges();            
        }

        public void Atualizar(ConsultaExameFisicoItem consultaexamefisicoitem)
        {
            db.Entry(consultaexamefisicoitem).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Eliminar(ConsultaExameFisicoItem consultaexamefisicoitem)
        {
            db.Entry(consultaexamefisicoitem).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public ConsultaExameFisicoItem Busca(int id)
        {
            return db.ConsultaExameFisicoItem.Find(id);
        }

        public List<ConsultaExameFisicoItem> ListarConsultaExameFisicoItem(int codigoexame)
        {
            var consultaExameFisicoItem = (from a in db.ConsultaExameFisicoItem
                                       where a.CODIGO_CONEXAFIS == codigoexame
                                       select a).Take(50).ToList();
            return consultaExameFisicoItem ;
        }
    }
}