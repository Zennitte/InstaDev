namespace InstaDev.Models
{
    public class Usuario
    {
        public string Nome { get; set; }
        public string UserName { get; set; }
        private string Email { get; set; }
        private string Senha { get; set; }
        private int IdUsuario { get; set; }
        
    }
}