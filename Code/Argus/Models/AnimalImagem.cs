using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Argus.Models
{
    public class AnimalImagem
    {
        private Contexto db = new Contexto();

        [Key]
        public int CODIGO { get; set; }

        [ForeignKey("Animal")]                
        [Display(Name = "Codigo do animal")]
        [Required(ErrorMessage = "Por favor preencher o código do animal")]        
        public int CODIGO_ANIMAL { get; set; }

        [Display(Name = "Data Atualização")]              
        public DateTime DTHR_ATUALIZACAO { get; set; }

        [Display(Name = "Foto do animal")]          
        public string NOME_FOTO { get; set; }
        
        [Display(Name = "Observações")]
        public string OBSERVACAO { get; set; }
        
        public virtual Animal Animal { get; set; }

        public void Incluir(AnimalImagem animalimagem)
        {
            db.AnimalImagem.Add(animalimagem);            
            db.SaveChanges();
        }

        public void Atualizar(AnimalImagem animalimagem)
        {
            db.Entry(animalimagem).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Eliminar(AnimalImagem animal)
        {
            db.Entry(animal).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public AnimalImagem Busca(int id)
        {
            return db.AnimalImagem.Find(id);
        }

        public List<AnimalImagem> ListaAnimaisImagem(int codigo)
        {
            var animalimagem = (from a in db.AnimalImagem
                          where a.CODIGO_ANIMAL == codigo
                          select a).Take(50).ToList();
            return animalimagem;
        }        
    }
}