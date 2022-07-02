using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Barbearia.Entidades
{
    public class Cliente: Base
    {
        [Required(ErrorMessage = "O campo Cliente é obrigatório")]
        [DisplayName("Cliente")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Data Nascimento é obrigatório")]
        [DisplayName("Data Nascimento")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "O campo E-mail é obrigatório")]
        [DisplayName("E-Mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo Telefone é obrigatório")]
        [DisplayName("Telefone")]
        public string Telefone { get; set; }
        [DisplayName("Status")]
        public bool Situacao { get; set; }
        public bool IsPcd { get; set; }
        public string Necessidade { get; set; }
    }
}