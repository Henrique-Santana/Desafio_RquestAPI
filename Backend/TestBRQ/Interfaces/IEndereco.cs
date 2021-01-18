using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBRQ.Domains;
using TestBRQ.Senai;

namespace TestBRQ.Interfaces
{
    interface IEndereco
    {
        List<Endereco> Listar();

        TypeMessage CadastrarEndereco(Endereco novoEndereco);
    }
}
