using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBRQ.Domains;
using TestBRQ.Interfaces;
using TestBRQ.Senai;
using TestBRQ.Utilities;

namespace TestBRQ.Repositories
{
    public class EnderecoRepository : IEndereco
    {

        private readonly Functions _functions;
        private readonly string table;

        public EnderecoRepository()
        {
            _functions = new Functions();
            table = "Endereco";
        }

        public List<Endereco> Listar()
        {
            using (TestBrqContext ctx = new TestBrqContext())
            {
                return ctx.Endereco.ToList();
                //.Select(a => new Endereco
                //{
                //    IdEndereco = a.IdEndereco,
                //    Cep = a.Cep,
                //    Endereco1 = a.Endereco1,
                //    Cidade = a.Cidade,
                //    Estado = a.Estado,
                //    Numero = a.Numero,
                //    Complemento = a.Complemento
                //})

            }
        }

        public TypeMessage CadastrarEndereco(Endereco novoEndereco)
        {
            using (TestBrqContext ctx = new TestBrqContext())
            {
                if (novoEndereco != null)
                {
                    try
                    {
                        ctx.Endereco.Add(novoEndereco);
                        ctx.SaveChanges();

                        string okMessage = _functions.defaultMessage(table, "ok");
                        return _functions.replyObject(okMessage, true);
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine(error);
                        string errorMessage = _functions.defaultMessage(table, "error");
                        return _functions.replyObject(errorMessage, false);
                    }
                }
                else
                {
                    string errorMessage = _functions.defaultMessage(table, "exists");
                    return _functions.replyObject(errorMessage, false);
                }
            }

        }
    }
}
