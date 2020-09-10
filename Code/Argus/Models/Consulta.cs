using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Objects;
using System.Data.Common;

namespace Argus.Models
{
    public class Consulta
    {
        private Contexto db = new Contexto();

        [Key]
        public int CODIGO { get; set; }
        
        [ForeignKey("Cliente")]
        [Display(Name = "Nome do cliente")]
        [Required(ErrorMessage = "Por favor informe o nome do cliente")]        
        public int CODIGO_CLIENTE { get; set; }

        [ForeignKey("Animal")]                
        [Display(Name = "Nome do animal")]
        [Required(ErrorMessage = "Por favor informe o nome do animal")]        
        public int CODIGO_ANIMAL { get; set; }

        [ForeignKey("Veterinario")]
        [Display(Name = "Nome do veterinário do animal")]
        [Required(ErrorMessage = "Por favor informe o nome do veterinário do animal")]        
        public int CODIGO_VETERINARIO { get; set; }
       
        [ForeignKey("TipoVisita")]
        [Required(ErrorMessage = "Por favor informe o tipo da visita de animal a clínica")]        
        [Display(Name = "Tipo da visita de animal a clínica")]
        public int CODIGOTP_VISITA { get; set; }

        [Display(Name = "Data da consulta")]        
        public Nullable<DateTime> DTHR_CONSULTA { get; set; }

        [Required(ErrorMessage = "Por favor informe a anamnese")]        
        [Display(Name = "Anamnese")]
        public string ANAMNESE { get; set; }

        [Display(Name = "Diagnóstico")]
        public string DIAGNOSTICO { get; set; }

        [Display(Name = "Tratamento")]
        public string TRATAMENTO { get; set; }

        [Required(ErrorMessage = "Por favor informe a data da alteração do status da consulta")]        
        [Display(Name = "Data da alteração do status")]        
        public DateTime DTHR_STATUS { get; set; }

        [ForeignKey("ConsultaStatus")]
        [Required(ErrorMessage = "Por favor informe o status da consulta")]        
        [Display(Name = "Status da Consulta")]
        public int CODIGO_STATUS { get; set; }
                        
        public virtual Cliente Cliente { get; set; }        
        public virtual Animal Animal { get; set; }
        public virtual Veterinario Veterinario { get; set; }
        public virtual TipoVisita TipoVisita { get; set; }
        public virtual ConsultaStatus ConsultaStatus { get; set; }

        public int Incluir(Consulta consulta)
        {
            db.Consulta.Add(consulta);
            db.SaveChanges();
            Console.WriteLine(consulta.CODIGO);
            return consulta.CODIGO;
        }

        public void Atualizar(Consulta consulta)
        {
            db.Entry(consulta).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Eliminar(Consulta consulta)
        {
            db.Entry(consulta).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public Consulta Busca(int id)
        {
            return db.Consulta.Find(id);
        }

        public List<Consulta> ListaConsultas(String pesquisa)
        {
            if (pesquisa == "")
            {
            var consulta = (from a in db.Consulta
                            join c in db.Animal on a.CODIGO_ANIMAL equals c.CODIGO
                            where a.CODIGO_STATUS != 2
                            select a).Take(50).ToList();
                return consulta;
            }else {
            var consulta = (from a in db.Consulta
                            join c in db.Animal on a.CODIGO_ANIMAL equals c.CODIGO
                            where a.CODIGO_STATUS != 2 &&  c.NOME == pesquisa
                            select a).Take(50).ToList();
            return consulta;
            }
            
        }

        public List<Consulta> ListaConsultasEncerrados(String pesquisa)
        {
            if (pesquisa == "")
            {
                var consulta = (from a in db.Consulta
                                join c in db.Animal on a.CODIGO_ANIMAL equals c.CODIGO
                                where a.CODIGO_STATUS == 2
                                select a).Take(50).ToList();
                return consulta;
            }
            else
            {
                var consulta = (from a in db.Consulta
                                join c in db.Animal on a.CODIGO_ANIMAL equals c.CODIGO
                                where a.CODIGO_STATUS == 2 && c.NOME == pesquisa
                                select a).Take(50).ToList();
                return consulta;
            }
        }

        public String RetornaUltimoCodigo()
        {
            IQueryable<Consulta> query;
            query = (from Consulta c in db.Consulta select c);
            foreach (Consulta c in query)
            {
                Console.WriteLine(c.DIAGNOSTICO);
            }

            int x ;
            Consulta e2 = null;
            e2 = (from emp in db.Consulta
                  where emp.CODIGO_CLIENTE == 1
                  select emp).Last();
            x = e2.CODIGO_CLIENTE;

            var ccc = from p in db.Consulta.Include("ConsultaProdServ")
                         select p;
            foreach (Consulta p in ccc)
            {
                Console.WriteLine(p.TRATAMENTO);
            }
            /*var consulta = (from a in db.Consulta
                            where a.CODIGO == 41  //substituir por identity
                            select a).
            */
            //SELECT CODIGO AS UltimoCodigo FROM COR WHERE CODIGO = @@Identity;
            return "41";
        }


    }    
}