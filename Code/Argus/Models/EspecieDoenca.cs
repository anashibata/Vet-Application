using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Argus.Models
{
    public class EspecieDoenca
    {
        private Contexto db = new Contexto();

        [Key]
        public int CODIGO { get; set; }

        [ForeignKey("Especie")]
        [Display(Name = "Espécie do animal")]
        [Required(ErrorMessage = "Por favor preencher a espécie do animal")]
        public int CODIGO_ESPECIE { get; set; }

        [Display(Name = "Nome da Doença")]
        [Required(ErrorMessage = "Por favor preencher o campo Nome da Doença")]
        [StringLength(60)]
        [MaxLength(60)]
        public string NOME { get; set; }

        [Display(Name = "Ativo")]
        public bool ATIVO { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Por favor preencher a Descrição da Doença")]
        public string DESCRICAO { get; set; }               

        public virtual Especie Especie { get; set; }

        public void Incluir(EspecieDoenca especiedoenca)
        {
            db.EspecieDoenca.Add(especiedoenca);
            db.SaveChanges();
        }

        public void Atualizar(EspecieDoenca especiedoenca)
        {
            db.Entry(especiedoenca).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Eliminar(EspecieDoenca especiedoenca)
        {
            db.Entry(especiedoenca).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public EspecieDoenca Busca(int id)
        {
            return db.EspecieDoenca.Find(id);
        }

        public List<EspecieDoenca> ListarEspecieDoenca(String pesquisa)
        {
            var especiedoenca = (from a in db.EspecieDoenca
                          where a.NOME.StartsWith(pesquisa)
                          select a).Take(50).ToList();
            return especiedoenca;
        }


        public List<EspecieDoenca> RelatorioEspecieDoenca(String pesquisa)
        {
            var especiedoenca = (from a in db.EspecieDoenca
                                 where a.NOME.StartsWith(pesquisa)
                                 select a).Take(50).ToList();
            return especiedoenca;
        }

        //[NotMapped]
        //public HttpPostedFileBase Foto { get; set; }
    }

}