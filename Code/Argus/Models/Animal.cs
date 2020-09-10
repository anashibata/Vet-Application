using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Argus.Models
{    
    public class Animal
    {
        private Contexto db = new Contexto();

        [Key]
        public int CODIGO { get; set; }
                       
        [ForeignKey("Cliente")]
        [Required(ErrorMessage = "Por favor preencher o Nome do proprietário do animal")]        
        [Display(Name = "Nome do proprietário do animal")]
        public int CODIGO_CLIENTE { get; set; }

        [ForeignKey("Veterinario")]
        [Display(Name = "Nome do veterinário do animal")]
        public Nullable<int> CODIGO_VETERINARIO { get; set; }

        [ForeignKey("Temperamento")]
        public Nullable<int> CODIGO_TEMPERAMENTO { get; set; }

        [ForeignKey("Pelagem")]
        public Nullable<int> CODIGO_PELAGEM { get; set; } //testar int?

        [ForeignKey("Cor")]
        public Nullable<int> CODIGO_COR { get; set; }
                
        [ForeignKey("Raca")]
        public Nullable<int> CODIGO_RACA { get; set; }

        [ForeignKey("Porte")]
        [Display(Name = "Porte do animal")]
        public Nullable<int> CODIGO_PORTE { get; set; }

        [ForeignKey("Especie")]
        [Display(Name = "Espécie do animal")]
        public Nullable<int> CODIGO_ESPECIE { get; set; }

        [Display(Name = "Nome do animal")]
        [Required(ErrorMessage = "Por favor preencher o campo Nome do animal")]        
        public string NOME { get; set; }

        [Display(Name = "Ativo")]
        public bool ATIVO { get; set; }

        [Display(Name = "Observações")]
        public string OBSERVACAO { get; set; }

        [Display(Name = "Data Nascimento")]        
        [RegularExpression(@"^((0[1-9]|[12]\d)\/(0[1-9]|1[0-2])|30\/(0[13-9]|1[0-2])|31\/(0[13578]|1[02]))\/\d{4}$", ErrorMessage = "Data inválida")]  
        public Nullable<DateTime> DT_NASCIMENTO { get; set; }

        [Display(Name = "Sexo")]
        [StringLength(60)]
        public string SEXO { get; set; }

        [Display(Name = "Foto do animal")]
        [StringLength(512)]
        public string CAMINHO_FOTO { get; set; }

        public virtual Cliente Cliente { get; set; }        
        public virtual Veterinario Veterinario { get; set; }
        public virtual Temperamento Temperamento { get; set; }
        public virtual Pelagem Pelagem { get; set; }
        public virtual Cor Cor { get; set; }
        public virtual Raca Raca { get; set; }
        public virtual Porte Porte { get; set; }
        public virtual Especie Especie { get; set; }        

        public void Incluir(Animal animal)
        {
            db.Animal.Add(animal);
            db.SaveChanges();

            Console.WriteLine(animal.CODIGO);
        }

        public void Atualizar(Animal animal)
        {
            db.Entry(animal).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Eliminar(Animal animal)
        {
            db.Entry(animal).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public Animal Busca(int id)
        {
            return db.Animal.Find(id);
        }

        public List<Animal> ListaAnimais(String pesquisa)
        {
            var animal = (from a in db.Animal
                          where a.NOME.StartsWith(pesquisa)
                          select a).Take(50).ToList();
            return animal;
        }


        public List<Animal> ListaAnimaisClientes()
        {
            var animal = (from a in db.Animal
                          join c in db.Cliente on a.CODIGO_CLIENTE equals c.CODIGO_PESSOA
                          join p in db.Pessoa on c.CODIGO_PESSOA equals p.CODIGO                          
                          select a).Take(50).ToList();
            return animal;

        }
        

        //[NotMapped]
        //public HttpPostedFileBase Foto { get; set; }
    }

}