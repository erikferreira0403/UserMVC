using System.Collections.Generic;
using UserMVC.Models;

namespace UserMVC.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel ListarPorId(int Id);
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);

        bool Apagar (int Id);
    }


}
