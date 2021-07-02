using System.Collections.Generic;
using InstaDev.Models;

namespace InstaDev.Interface
{
    public interface IUsuario
    {
        void Cadastrar(Usuario u);
        void Alterar(Usuario u);
        List<Usuario> Listar();
        void Deletar(Usuario u);
    }
}