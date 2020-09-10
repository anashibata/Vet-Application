using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Argus.Models
{
    public class Diagnostico
    {
        private Contexto db = new Contexto();

        [Key]
        public int CODIGO { get; set; }


        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Por favor preencher o campo Nome")]
        [StringLength(60)]
        public string NOME { get; set; }

        [Display(Name = "Ativo")]
        public bool ATIVO { get; set; }

        public void Incluir(Diagnostico diagnostico)
        {
            db.Diagnostico.Add(diagnostico);
            db.SaveChanges();
        }

        public void Atualizar(Diagnostico diagnostico)
        {
            db.Entry(diagnostico).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Eliminar(Diagnostico diagnostico)
        {
            db.Entry(diagnostico).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public Diagnostico Busca(int id)
        {
            return db.Diagnostico.Find(id);
        }

        public List<Diagnostico> ListarDiagnostico(String pesquisa)
        {
            var diagnostico = (from a in db.Diagnostico
                               where a.NOME.StartsWith(pesquisa)
                               select a).Take(50).ToList();
            return diagnostico;
        }
    }

}