using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;


namespace Argus.Models
{
    public class MedicinaPrev
    {

        private Contexto db = new Contexto();

        [Key]
        public int CODIGO { get; set; }

        [ForeignKey("Raca")]
        [Display(Name = "Raça")]
        [Required(ErrorMessage = "Por favor preencher a raça")]
        public int CODIGO_RACA { get; set; }

        [Display(Name = "Prevenção")]
        [Required(ErrorMessage = "Por favor preencher a Prevenção")]
        public string DESCRICAO { get; set; }

       

        public virtual Raca Raca { get; set; }

        public void Incluir(MedicinaPrev medicinaprev)
        {
            db.MedicinaPrev.Add(medicinaprev);
            db.SaveChanges();
        }

        public void Atualizar(MedicinaPrev medicinaprev)
        {
            db.Entry(medicinaprev).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Eliminar(MedicinaPrev medicinaprev)
        {
            db.Entry(medicinaprev).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public MedicinaPrev Busca(int id)
        {
            return db.MedicinaPrev.Find(id);
        }

        public List<MedicinaPrev> ListarMedicinaPrev(String pesquisa)
        {
            var medicinaprev = (from a in db.MedicinaPrev
                                  where a.DESCRICAO.StartsWith(pesquisa)
                                  select a).Take(50).ToList();
            return medicinaprev;
        }

    }
}