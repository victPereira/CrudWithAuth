using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudWithAuth.Models
{
    public class Student
    {

        // Esse Key indica que o campo ID na tabela vai ser uma chave primaria
        [Key]
        [DisplayName("Id")]
        public int Id { get; set;}


        // Validacaçoes
        [Required(ErrorMessage = "Informe o nome")]
        [StringLength(80, ErrorMessage = "O nome deve conter ate 80 caracteres")]
        [MinLength(5, ErrorMessage ="O nome deve conter pelo menos 5 caracteres")]
        [DisplayName("Nome Completo")]
        public string Name {get;set;} = string.Empty;


        // Validaçoes
        [Required(ErrorMessage = "Informe o E-mail")]
        [EmailAddress(ErrorMessage = " E-mail Invalido")]
        [DisplayName("E-mail")]
        public string Email {get; set; } = string.Empty;

        public List<Premium> Premiuns { get; set;} = new();

    }
}