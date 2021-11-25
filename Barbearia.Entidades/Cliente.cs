using System;
using System.ComponentModel.DataAnnotations;

namespace Barbearia.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Data Nascimento é obrigatório.")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
        [DataType("Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        public string Telefone { get; set; }
        public bool Situacao { get; set; }
    }
}