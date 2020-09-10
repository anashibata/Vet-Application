using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Argus.Models
{
    public class Temperamento
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


        public void Incluir(Temperamento temperamento)
        {
            db.Temperamento.Add(temperamento);
            db.SaveChanges();
        }

        public void Atualizar(Temperamento temperamento)
        {
            db.Entry(temperamento).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Eliminar(Temperamento temperamento)
        {
            db.Entry(temperamento).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public Temperamento Busca(int id)
        {
            return db.Temperamento.Find(id);
        }

        public List<Temperamento> ListarTemperamento(String pesquisa)
        {
            var temperamento = (from a in db.Temperamento
                               where a.NOME.StartsWith(pesquisa)
                               select a).Take(50).ToList();
            return temperamento;
        }
    }

}