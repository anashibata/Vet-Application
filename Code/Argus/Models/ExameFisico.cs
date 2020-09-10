using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Argus.Models
{
    public class ExameFisico
    {
        private Contexto db = new Contexto();

        [Key]
        public int CODIGO { get; set; }

        [Display(Name = "Exame")]
        [Required(ErrorMessage = "Por favor preencher o exame Físico a ser realizado")]
        public string NOME { get; set; }

        [Display(Name = "Ativo")]
        public bool ATIVO { get; set; }


        public void Incluir(ExameFisico examefisico)
        {
            db.ExameFisico.Add(examefisico);
            db.SaveChanges();
        }

        public void Atualizar(ExameFisico examefisico)
        {
            db.Entry(examefisico).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Eliminar(ExameFisico examefisico)
        {
            db.Entry(examefisico).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public ExameFisico Busca(int id)
        {
            return db.ExameFisico.Find(id);
        }

        public List<ExameFisico> ListarExameFisico(String pesquisa)
        {
            var examefisico = (from a in db.ExameFisico
                                   where a.NOME.StartsWith(pesquisa)
                                   select a).Take(50).ToList();
            return examefisico;
        }
    }

}