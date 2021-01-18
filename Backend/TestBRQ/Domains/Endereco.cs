using System;
using System.Collections.Generic;

namespace TestBRQ.Domains
{
    public partial class Endereco
    {
        public Endereco()
        {
            DadosPessoais = new HashSet<DadosPessoais>();
        }

        public int IdEndereco { get; set; }
        public string Cep { get; set; }
        public string Endereco1 { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }

        public ICollection<DadosPessoais> DadosPessoais { get; set; }
    }
}
