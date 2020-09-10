using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Argus.Models
{
    public class ProdutoServico
    {
        private Contexto db = new Contexto();

        [Key]
        public int CODIGO { get; set; }
               
        [Display(Name = "Nome Produto/Serviço")]
        [Required(ErrorMessage = "Por favor preencher o campo Nome do Produto/Serviço")]
        [StringLength(60)]
        public string NOME { get; set; }

        [Display(Name = "Ativo")]
        public bool ATIVO { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "Por favor preencher o tipo do cadastro Produto/Serviço")]
        public string TIPO { get; set; }

        [Display(Name = "Data Validade")]
        public Nullable<DateTime> DT_VALIDADE { get; set; }
        
        public void Incluir(ProdutoServico produtoservico)
        {
            db.ProdutoServico.Add(produtoservico);
            db.SaveChanges();
        }

        public void Atualizar(ProdutoServico produtoservico)
        {
            db.Entry(produtoservico).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Eliminar(ProdutoServico produtoservico)
        {
            db.Entry(produtoservico).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public ProdutoServico Busca(int id)
        {
            return db.ProdutoServico.Find(id);
        }

        public List<ProdutoServico> ListarProdutoServico(String pesquisa)
        {
            var produtoservico = (from a in db.ProdutoServico
                          where a.NOME.StartsWith(pesquisa)
                          select a).Take(50).ToList();
            return produtoservico;
        }

        public List<ProdutoServico> RelatorioProdutoServico(String pesquisa)
        {
            var produtoservico = (from a in db.ProdutoServico
                                  where a.NOME.StartsWith(pesquisa)
                                  select a).ToList();
            return produtoservico;
        }

    }
}