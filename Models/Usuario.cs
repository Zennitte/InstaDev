using System;
using System.Collections.Generic;
using System.IO;
using InstaDev.Interface;

namespace InstaDev.Models
{
    public class Usuario : InstaDevBase, IUsuario
    {
        public string Nome { get; set; }
        public string UserName { get; set; }
        private string Email { get; set; }
        private string Senha { get; set; }
        private int IdUsuario { get; set; }
        private const string PATH = "Database/usuario.csv";
        public Usuario()
        {
            CriarPastaEArquivo(PATH);
        }
        private string Preparar(Usuario u)
        {
            return $"{u.Nome};{u.UserName};{u.Email};{u.Senha};{u.IdUsuario}";
        }
        public void Alterar(Usuario u)
        {
            List<string> linhas = LerTodasLinhasCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[4] == u.IdUsuario.ToString());
            linhas.Add(Preparar(u));
            ReescreverCSV(PATH, linhas);
        }

        public void Cadastrar(Usuario u)
        {
            string[] linha = { Preparar(u) };
            File.AppendAllLines(PATH, linha);
        }
        public void Deletar(Usuario u)
        {
            List<string> linhas = LerTodasLinhasCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[4] == u.IdUsuario.ToString());
            ReescreverCSV(PATH, linhas);
        }

        public List<Usuario> Listar()
        {
            List<Usuario> usuarios = new List<Usuario>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Usuario usuario = new Usuario();

                usuario.Nome = linha[0];
                usuario.UserName = linha[1];
                usuario.Email = linha[2];
                usuario.Senha = linha[3];
                usuario.IdUsuario = Int32.Parse(linha[4]);

                usuarios.Add(usuario);
            }

            return usuarios;
        }
        public List<int> RetornarId()
        {
            List<int> Ids = new List<int>();
            foreach (var item in Listar())
            {
                Ids.Add(item.IdUsuario);
            }

            return Ids;
        }
        public void AtribuirEmail(string _email)
        {
            Email = _email;
        }

        public void AtribuirSenha(string _senha)
        {
            Senha = _senha;
        }
        public void AtribuirId()
        {
            IdUsuario = GerarId(RetornarId());
        }

        
    }
}