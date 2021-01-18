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
    public class DadosPessoaisRepository : IDadosPessoais
    { 

    private readonly Functions _functions;
    private readonly string table;

    public DadosPessoaisRepository()
    {
        _functions = new Functions();
        table = "DadosPessoais";
    }
    
        public List<DadosPessoais> Listar()
        {
            using (TestBrqContext ctx = new TestBrqContext())
            {
                return ctx.DadosPessoais
                    .Select(a => new DadosPessoais
                    {
                        IdDadosPessoais = a.IdDadosPessoais,
                        Nome = a.Nome,
                        Sobrenome = a.Sobrenome,
                        Cpf = a.Cpf,
                        DataNascimento = a.DataNascimento,
                        IdEnderecoNavigation = a.IdEnderecoNavigation
                    })
                    .Include(a => a.IdEnderecoNavigation)
                    .ToList();

            }
        }

        public TypeMessage Cadastrar(DadosPessoais data)
        {
            using (TestBrqContext ctx = new TestBrqContext())
            {
                DadosPessoais dadoExistente = ctx.DadosPessoais.FirstOrDefault(a => a.Cpf == data.Cpf);

                if(dadoExistente == null)
                {
                    try
                    {
                        ctx.DadosPessoais.Add(data);
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
