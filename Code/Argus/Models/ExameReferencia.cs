using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Argus.Models
{
    public class ExameReferencia
    {
        private Contexto db = new Contexto();
                
        [Key, Column(Order = 1)]
        [Display(Description = "Exame")]
        public int CODIGO_EXAME { get; set; }

        [Key, Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CODIGO_ITEM { get; set; }       
                       
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Por favor preencher o campo Descricao")]
        [StringLength(60)]
        public string DESCRICAO { get; set; }

        [Display(Name = "Unidades")]
        public string UNIDADES { get; set; }

        [Display(Name = "De")]
        public Nullable<int> DE { get; set; }

        [Display(Name = "Até")]
        public Nullable<int> ATE { get; set; }

        public void Incluir(ExameReferencia examereferencia)
        {
            db.ExameReferencia.Add(examereferencia);
            db.SaveChanges();
        }

        public void Atualizar(ExameReferencia examereferencia)
        {
            db.Entry(examereferencia).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Eliminar(ExameReferencia examereferencia)
        {
            db.Entry(examereferencia).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public ExameReferencia Busca(int id)
        {
            return db.ExameReferencia.Find(id);
        }

        public List<ExameReferencia> ListarExameReferencia(String pesquisa)
        {
            var examereferencia = (from a in db.ExameReferencia
                               where a.DESCRICAO.StartsWith(pesquisa)
                               select a).Take(50).ToList();
            return examereferencia;
        }
    }

}