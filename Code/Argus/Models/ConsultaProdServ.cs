using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Argus.Models
{
    public class ConsultaProdServ
    {
        private Contexto db = new Contexto();

        [Key]
        public int CODIGO { get; set; }
        
        [ForeignKey("Consulta")]
        [Display(Name = "Consulta")]
        [Required(ErrorMessage = "Por favor preencher o campo Consulta")]
        public int CODIGO_CONSULTA { get; set; }
        
        [ForeignKey("ProdutoServico")]
        [Display(Name = "Informe o Produto ou Serviço")]
        [Required(ErrorMessage = "Por favor preencher o Produto ou Serviço")]
        public int CODIGO_PRODSERV { get; set; }

        public virtual Consulta Consulta { get; set; }
        public virtual ProdutoServico ProdutoServico { get; set; }

        public void Incluir(ConsultaProdServ consultaprodserv)
        {
            db.ConsultaProdServ.Add(consultaprodserv);
            db.SaveChanges();
        }

        public void Atualizar(ConsultaProdServ consultaprodserv)
        {
            db.Entry(consultaprodserv).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Eliminar(ConsultaProdServ consultaprodserv)
        {
            db.Entry(consultaprodserv).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public ConsultaProdServ Busca(int id)
        {
            return db.ConsultaProdServ.Find(id);
        }

        public List<ConsultaProdServ> ListaConsultas(int codigoconsulta)
        {
            var consultaprodserv = (from a in db.ConsultaProdServ    
                                    where a.CODIGO_CONSULTA == codigoconsulta
                          select a).Take(50).ToList();
            return consultaprodserv;
        }

        public List<ConsultaProdServ> Relatorio()
        {
            var consultaprodserv = (from a in db.ConsultaProdServ                                    
                                    select a).Take(50).ToList();
            return consultaprodserv;
        }


    }
}