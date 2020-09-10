using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Argus.Models
{
    public class Pessoa
    {
        private Contexto db = new Contexto();
       
        [Key]
        public int CODIGO { get; set; }

        [ForeignKey("Cidade")]
        public int CODIGO_CIDADE { get; set; }
   
        [Display(Name = "Nome da pessoa")]
        [Required(ErrorMessage = "Por favor preencher o campo Nome")]
        [StringLength(60)]
        [MaxLength(60)]
        public string NOME { get; set; }

        [Display(Name = "Ativo")]
        [Required(ErrorMessage = "Por favor preencher o campo Ativo")]
        public bool ATIVO { get; set; }

        [Display(Name = "Endereço")]
        public string ENDERECO { get; set; }

        [Display(Name = "Email")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "E-mail com formato inválido")]
        public string EMAIL { get; set; }

        [Display(Name = "EnviarEmail")]      
        public Boolean ENVIAR_EMAIL { get; set; }

        [Display(Name = "Observações")]
        public string OBSERVACAO { get; set; }

        [Display(Name = "Data Nascimento")]
        [RegularExpression(@"^((0[1-9]|[12]\d)\/(0[1-9]|1[0-2])|30\/(0[13-9]|1[0-2])|31\/(0[13578]|1[02]))\/\d{4}$", ErrorMessage = "Data inválida")]  
        public Nullable<DateTime> DT_NASCIMENTO { get; set; }

        [Display(Name = "Data Cadastro")]
        public DateTime DT_CADASTRO { get; set; }
        
        
        public virtual Cidade Cidade { get; set; }
               
        
        public void Incluir(Pessoa pessoa)
        {
            db.Pessoa.Add(pessoa);
            db.SaveChanges();
        }

        public void Atualizar(Pessoa pessoa)
        {
            db.Entry(pessoa).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Eliminar(Pessoa pessoa)
        {
            db.Entry(pessoa).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public Pessoa Busca(int id)
        {
            return db.Pessoa.Find(id);
        }

        public List<Pessoa> ListarPessoa(String pesquisa)
        {
            var pessoa = (from a in db.Pessoa
                               where a.NOME.StartsWith(pesquisa)
                               select a).Take(50).ToList();
            return pessoa;
        }


        


        //[NotMapped]
        //public HttpPostedFileBase Foto { get; set; }
    }

}