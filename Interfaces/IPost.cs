using System.Collections.Generic;
using InstaDev.Models;

namespace InstaDev.Interfaces
{
    public interface IPost
    {
         void Criar(Post post);

         void Deletar(Post post);

         void Alterar(Post post);

         List<Post> Listar (Post post);
    }
}