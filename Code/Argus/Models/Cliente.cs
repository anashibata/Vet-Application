using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Argus.Models
{
    public class Cliente 
    {
        private Contexto db = new Contexto();

        [Key]
        public int CODIGO { get; set; }

        [ForeignKey("Pessoa")]
        [Required(ErrorMessage = "Por favor preencher a Pessoa")]
        [Display(Name = "Nome da Pessoa")]
        public int CODIGO_PESSOA { get; set; }

        [Display(Name = "Temperamento")]
        public Nullable<int> CODIGO_TEMPERAMENTO { get; set; }

        [Display(Name = "Quantidade de filhos")]
        [Range(0, 100, ErrorMessage = "Por favor preencher a quantidade de filhos corretamente. A quantidade maxima permitida é de 100 filhos.")]
        public Nullable<int> NFILHOS { get; set; }

        [Display(Name = "Quantidade de animais")]
        [Range(0, 200, ErrorMessage = "Por favor preencher a quantidade de animais corretamente. A quantidade maxima permitida é de 100 filhos.")]
        public Nullable<int> NANIMAIS { get; set; }
        
        public virtual Pessoa Pessoa { get; set; }

        public void Incluir(Cliente cliente)
        {
            db.Cliente.Add(cliente);
            db.SaveChanges();
        }

        public void Atualizar(Cliente cliente)
        {
            db.Entry(cliente).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Eliminar(Cliente cliente)
        {
            db.Entry(cliente).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public Cliente Busca(int id)
        {
            return db.Cliente.Find(id);
        }

        public List<Cliente> ListarCliente(String pesquisa)
        {
            var cliente = (from c in db.Cliente
                           join p in db.Pessoa on c.CODIGO_PESSOA equals p.CODIGO
                                where p.NOME.StartsWith(pesquisa)
                                  select c).Take(50).ToList();
            return cliente;
        }

        public List<Cliente> RelatorioCliente(String pesquisa)
        {
            var cliente = (from c in db.Cliente
                           join p in db.Pessoa on c.CODIGO_PESSOA equals p.CODIGO
                           where p.NOME.StartsWith(pesquisa)
                           select c).Take(50).ToList();
            return cliente;
        }
    }
}