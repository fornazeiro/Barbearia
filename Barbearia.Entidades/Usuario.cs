using System;
using System.ComponentModel.DataAnnotations;

namespace Barbearia.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
        [DataType("Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        public string Senha { get; set; }
        public bool Situacao { get; set; }
    }
}