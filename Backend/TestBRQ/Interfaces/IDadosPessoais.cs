using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBRQ.Domains;
using TestBRQ.Senai;

namespace TestBRQ.Interfaces
{
    interface IDadosPessoais
    {
        List<DadosPessoais> Listar();

        TypeMessage Cadastrar(DadosPessoais data);
    }
}
