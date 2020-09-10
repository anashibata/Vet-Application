using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;


namespace Argus.Models
{
    public class EspecieCheckup
    {
        private Contexto db = new Contexto();

        [Key]
        public int CODIGO { get; set; }
                       
        [ForeignKey("Especie")]             
        public int CODIGO_ESPECIE { get; set; }
                
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Por favor preencher a Descrição")]        
        public string DESCRICAO { get; set; }

        [Display(Name = "Ativo")]
        public bool ATIVO { get; set; }

        [Display(Name = "De")]
        [Required(ErrorMessage = "Por favor preencher a idade. A faixa de idade válida é de 0 a 300 anos.")]   
        [Range(0, 300, ErrorMessage = "Por favor preencher uma idade válida. A faixa de idade válida é de 0 a 300 anos.")]
        public int DE { get; set; }
         
        [Display(Name = "Até")]
        [Required(ErrorMessage = "Por favor preencher a idade. A faixa de idade válida é de 0 a 300 anos.")]
        [Range(0, 300, ErrorMessage = "Por favor preencher uma idade válida. A faixa de idade válida é de 0 a 300 anos.")]
        public int ATE { get; set; }

        public virtual Especie Especie { get; set; }
        
        public void Incluir(EspecieCheckup especiecheckup)
        {
            db.EspecieCheckup.Add(especiecheckup);
            db.SaveChanges();
        }

        public void Atualizar(EspecieCheckup especiecheckup)
        {
            db.Entry(especiecheckup).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Eliminar(EspecieCheckup especiecheckup)
        {
            db.Entry(especiecheckup).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public EspecieCheckup Busca(int id)
        {
            return db.EspecieCheckup.Find(id);
        }

        public List<EspecieCheckup> ListarEspecieCheckup(String pesquisa)
        {
            var especiecheckup = (from a in db.EspecieCheckup
                          where a.DESCRICAO.StartsWith(pesquisa)
                          select a).Take(50).ToList();
            return especiecheckup;
        }
    
    }
}