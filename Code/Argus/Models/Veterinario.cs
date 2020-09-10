using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Argus.Models
{
    public class Veterinario
    {
        private Contexto db = new Contexto();

        [Key]
        public int CODIGO { get; set; }

        [ForeignKey("Pessoa")]
        [Required(ErrorMessage = "Por favor preencher a Pessoa")]        
        public int CODIGO_PESSOA { get; set; }
        
        [Required(ErrorMessage = "Por favor preencher o CRMV  do veterinario")]        
        public string CRMV { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public void Incluir(Veterinario veterinario)
        {
            db.Veterinario.Add(veterinario);
            db.SaveChanges();
        }

        public void Atualizar(Veterinario veterinario)
        {
            db.Entry(veterinario).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Eliminar(Veterinario veterinario)
        {
            db.Entry(veterinario).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public Veterinario Busca(int id)
        {
            return db.Veterinario.Find(id);
        }

        public List<Veterinario> ListaVeterinarios(String pesquisa)
        {
            var veterinario = (from a in db.Veterinario
                          //where a.NOME.StartsWith(pesquisa)
                          select a).Take(50).ToList();
            return veterinario;
        }

    }
}