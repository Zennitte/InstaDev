
using System;
using System.Collections.Generic;
using System.IO;
using InstaDev.Interfaces;

namespace InstaDev.Models
{
    public class Post : InstaDevBase ,IPost
    {
        private int IdUsuario { get; set; }
        
        private int IdPost { get; set; }
        
        public string Titulo { get; set; }
        
        public string Texto { get; set; }
        
        public string Imagem { get; set; }
        
        private const string PATH = "Database/post.csv";

        public Post(){

            CriarPastaEArquivo(PATH);
        }


        private string Preparar(Post post){

            return $"{post.IdUsuario};{post.IdPost};{post.Titulo};{post.Texto};{post.Imagem}";
        }

        public void Criar(Post post)
        {
            string [] linha = {Preparar (post)};

            File.AppendAllLines (PATH, linha);
        }

        public void Deletar(Post post)
        {
            List<string> linhas = LerTodasLinhasCSV (PATH);
            linhas.RemoveAll(x => x.Split(";")[1] == post.IdPost.ToString());
            ReescreverCSV(PATH, linhas);
        }

        public void Alterar(Post post)
        {
            List<string> linhas = LerTodasLinhasCSV (PATH);
            linhas.RemoveAll(x => x.Split(";")[1] == post.IdPost.ToString());
            linhas.Add(Preparar(post));
            ReescreverCSV(PATH, linhas);
        }

        public List<Post> Listar(Post post)
        {
           List<Post> posts = new List<Post>();

           string [] linhas = File.ReadAllLines(PATH);

           foreach (var item in linhas)
           {
               string [] linha = item.Split(";");

               Post p = new Post();

               p.IdPost = Int32.Parse(linha[0]);
               p.IdUsuario = Int32.Parse(linha[1]);
               p.Titulo = linha[2];
               p.Texto = linha[3];
               p.Imagem = linha[4];

               posts.Add(p);
           }

           return posts;

        }

        // CLASSE 
    }
}