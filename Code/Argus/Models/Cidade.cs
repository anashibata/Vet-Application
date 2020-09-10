using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Argus.Models
{
    public class Cidade
    {
        private Contexto db = new Contexto();

        [Key]
        public int CODIGO { get; set; }

        [ForeignKey("Estado")]
        public int CODIGO_ESTADO { get; set; }

       
        [Display(Name = "Nome da Cidade")]
        [Required(ErrorMessage = "Por favor preencher o campo Cidade")]
        [StringLength(60)]
        [MaxLength(60)]
        public string NOME { get; set; }

        [Display(Name = "Ativo")]
        public bool ATIVO { get; set; }       

        public virtual Estado Estado { get; set; }
 

        public void Incluir(Cidade cidade)
        {
            db.Cidade.Add(cidade);
            db.SaveChanges();
        }

        public void Atualizar(Cidade cidade)
        {
            db.Entry(cidade).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Eliminar(Cidade cidade)
        {
            db.Entry(cidade).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public Cidade Busca(int id)
        {
            return db.Cidade.Find(id);
        }

        public List<Cidade> ListarCidade(String pesquisa)
        {
            var cidade = (from a in db.Cidade
                          where a.NOME.StartsWith(pesquisa)
                          select a).Take(50).ToList();
            return cidade;
        }


       


        //[NotMapped]
        //public HttpPostedFileBase Foto { get; set; }
    }

}