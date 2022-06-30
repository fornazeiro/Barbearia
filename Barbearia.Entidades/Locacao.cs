using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Barbearia.Entidades
{
    public class Locacao: Base
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [DisplayName("Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo CPF é obrigatório")]
        [DisplayName("CPF")]
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public int Cadeiras { get; set; }
        public decimal ValorUnitario { get; set; }
        public bool? Situacao { get; set; }
    }
}
