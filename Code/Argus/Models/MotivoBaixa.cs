using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Argus.Models
{
    public class MotivoBaixa
    {
        private Contexto db = new Contexto();

        [Key]
        public int CODIGO { get; set; }
                    
        
        [Display(Name = "Motivo da baixa")]
        [Required(ErrorMessage = "Por favor preencher o campo Nome")]
        [StringLength(60)]
        public string NOME { get; set; }

        [Display(Name = "Ativo")]
        public bool ATIVO { get; set; }


        public void Incluir(MotivoBaixa motivobaixa)
        {
            db.MotivoBaixa.Add(motivobaixa);
            db.SaveChanges();
        }

        public void Atualizar(MotivoBaixa motivobaixa)
        {
            db.Entry(motivobaixa).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Eliminar(MotivoBaixa motivobaixa)
        {
            db.Entry(motivobaixa).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public MotivoBaixa Busca(int id)
        {
            return db.MotivoBaixa.Find(id);
        }

        public List<MotivoBaixa> ListarMotivoBaixa(String pesquisa)
        {
            var motivobaixa = (from a in db.MotivoBaixa
                          where a.NOME.StartsWith(pesquisa)
                          select a).Take(50).ToList();
            return motivobaixa;
        }
    }
    
}