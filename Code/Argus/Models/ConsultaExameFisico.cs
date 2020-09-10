using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Argus.Models
{
    public class ConsultaExameFisico
    {
        private Contexto db = new Contexto();

        [Key]
        public int CODIGO { get; set; }
        
        [ForeignKey("Consulta")]
        [Display(Name = "Consulta")]
        [Required(ErrorMessage = "Por favor preencher o campo Consulta")]
        public int CODIGO_CONSULTA { get; set; }
        
        [ForeignKey("ExameFisico")]
        [Display(Name = "Exame Físico:")]
        [Required(ErrorMessage = "Por favor preencher o Exame Físico")]
        public int CODIGO_EXAMEFIS { get; set; }

        public virtual ExameFisico ExameFisico { get; set; }
        public virtual Consulta Consulta { get; set; }

        public int Incluir(ConsultaExameFisico consultaexamefisico)
        {
            db.ConsultaExameFisico.Add(consultaexamefisico);
            db.SaveChanges();
            return consultaexamefisico.CODIGO ;

        }

        public void Atualizar(ConsultaExameFisico consultaExameFisico)
        {
            db.Entry(consultaExameFisico).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Eliminar(ConsultaExameFisico consultaExameFisico)
        {
            db.Entry(consultaExameFisico).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public ConsultaExameFisico Busca(int id)
        {
            return db.ConsultaExameFisico.Find(id);
        }

        public List<ConsultaExameFisico> ListarConsultaExameFisico(int codigoconsulta)
        {
            var consultaExameFisico = (from a in db.ConsultaExameFisico
                                       where a.CODIGO_CONSULTA == codigoconsulta
                                       select a).Take(50).ToList();
            return consultaExameFisico;
        }

        public void IncluirConsultaExameItem(int codigo, int codigoexamefis) {

            var consultaExameFisico = (from a in db.ExameFisicoItem
                                       where a.CODIGO_EXAMEFIS == codigoexamefis
                                       select a).Take(50).ToList();

            foreach (ExameFisicoItem exame in consultaExameFisico)
            {
                 ConsultaExameFisicoItem conexafisitem = new ConsultaExameFisicoItem();
                 conexafisitem.CODIGO_CONEXAFIS = codigo ;
                 conexafisitem.CODIGO_EXAMEFISITEM = exame.CODIGO;                
                 conexafisitem.Incluir(conexafisitem);
            }

        }

    }
}