using System.Collections.Generic;
using System.Linq;
using UserMVC.Data;
using UserMVC.Models;


namespace UserMVC.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            //gravar no DB
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;

        }

        public bool Apagar(int Id)
        {
            ContatoModel ContatoDB = ListarPorId(Id);
            if (ContatoDB == null)
                throw new System.Exception("Houve um erro na deleção do contato");
            _bancoContext.Contatos.Remove(ContatoDB);
            _bancoContext.SaveChanges();
            return true;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel ContatoDB = ListarPorId(contato.Id);
            if (ContatoDB == null)
                throw new System.Exception("Houve um erro na atualização do contato");

            ContatoDB.Nome = contato.Nome;
            ContatoDB.Email = contato.Email;
            ContatoDB.Celular = contato.Celular;

            _bancoContext.Contatos.Update(ContatoDB);
            _bancoContext.SaveChanges();
            return ContatoDB;
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel ListarPorId(int Id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == Id);
        }
    }
}
