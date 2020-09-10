using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Argus.Models
{
    public class Procedimento
    {
        private Contexto db = new Contexto();

        [Key]
        public int CODIGO { get; set; }

        [Display(Name = "Nome do procedimento")]
        [Required(ErrorMessage = "Por favor preencher o Nome do Procedimento")]
        [StringLength(60)]
        [MaxLength(60)]
        public string NOME { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Por favor preencher a Descrição do Procedimento")]        
        public string DESCRICAO { get; set; }

        public void Incluir(Procedimento procedimento)
        {
            db.Procedimento.Add(procedimento);
            db.SaveChanges();
        }

        public void Atualizar(Procedimento procedimento)
        {
            db.Entry(procedimento).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Eliminar(Procedimento procedimento)
        {
            db.Entry(procedimento).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public Procedimento Busca(int id)
        {
            return db.Procedimento.Find(id);
        }

        public List<Procedimento> ListaProcedimentos(String pesquisa)
        {
            var procedimento = (from a in db.Procedimento
                          where a.DESCRICAO.StartsWith(pesquisa)
                          select a).Take(50).ToList();
            return procedimento;
        }
    }
}