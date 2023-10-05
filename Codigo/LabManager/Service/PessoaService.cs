using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PessoaService : IPessoaService
    {
        private readonly LabManagerContext _context;

        public PessoaService(LabManagerContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Cria uma nova pessoa na base de dados
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public uint Create(Pessoa pessoa)
        {
            _context.Add(pessoa);
            _context.SaveChanges();
            return pessoa.Id;
        }

        /// <summary>
        /// Remove pessoa da base de dados
        /// </summary>
        /// <param name="id"></param>
        public void Delete(uint id)
        {
            var pessoa = _context.Pessoas.Find(id);
            if (pessoa != null)
            {
                _context.Remove(pessoa);
                _context.SaveChanges();
            }        
        }
        /// <summary>
        /// Edita os dados de uma pessoa da base de dados
        /// </summary>
        /// <param name="pessoa"></param>
        public void Edit(Pessoa pessoa)
        {
            _context.Update(pessoa);
            _context.SaveChanges();
        }
        /// <summary>
        /// Retorna pessoa pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Pessoa Get(uint id)
        {
            return _context.Pessoas.Find(id);
        }

        /// <summary>
        /// REtorna todas as pessoas da base de dados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Pessoa> GetAll()
        {
            return _context.Pessoas.AsNoTracking();
        }
    }
}
