
using System;
using System.Collections.Generic;
using System.IO;
using InstaDev.Interfaces;

namespace InstaDev.Models
{
    public class Post : InstaDevBase, IPost
    {
        public int IdUsuario { get; set; }

        private int IdPost { get; set; }

        public string UserName { get; set; }

        public string Texto { get; set; }

        public string Imagem { get; set; }

        private const string PATH = "Database/post.csv";


        public Post()
        {
            CriarPastaEArquivo(PATH);
        }


        private string Preparar(Post post)
        {

            return $"{post.IdUsuario};{post.IdPost};{post.Texto};{post.Imagem};{post.UserName}";
        }

        public void Criar(Post post)
        {
            string[] linha = { Preparar(post) };

            File.AppendAllLines(PATH, linha);
        }

        public void Deletar(Post post)
        {
            List<string> linhas = LerTodasLinhasCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] != post.IdUsuario.ToString());
            ReescreverCSV(PATH, linhas);
        }

        public void Alterar(Post post)
        {
            List<string> linhas = LerTodasLinhasCSV(PATH);
            linhas.Find(x => x.Split(";")[0] == post.IdUsuario.ToString());
            linhas.Add(Preparar(post));
            ReescreverCSV(PATH, linhas);
        }

        public List<Post> Listar()
        {
            List<Post> posts = new List<Post>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Post p = new Post();
                p.IdUsuario = Int32.Parse(linha[0]);
                p.IdPost = Int32.Parse(linha[1]);
                p.Texto = linha[2];
                p.Imagem = linha[3];
                p.UserName = linha[4];

                posts.Add(p);
            }

            return posts;
        }


        public List<Post> ListarPosts(int id)
        {
            List<Post> posts = new List<Post>();
            
           foreach (var item in Listar())
            {
                if (item.IdUsuario == id)
                {
                    posts.Add(item);
                }
            }

            return posts;
        }

        public List<int> RetornarId()
        {
            List<int> IdsPost = new List<int>();
            foreach (var item in Listar())
            {
                IdsPost.Add(item.IdPost);
            }

            return IdsPost;
        }

        public void AtrubuirIdPost()
        {

            IdPost = GerarId(RetornarId());
        }

        // CLASSE 
    }
}