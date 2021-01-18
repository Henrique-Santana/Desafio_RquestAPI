using System;
using System.Collections.Generic;

namespace TestBRQ.Domains
{
    public partial class DadosPessoais
    {
        public int IdDadosPessoais { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public int? IdEndereco { get; set; }

        public Endereco IdEnderecoNavigation { get; set; }
    }
}
