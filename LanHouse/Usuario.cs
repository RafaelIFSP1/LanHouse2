using System;

namespace LanHouseSystem
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string TipoUsuario { get; set; }
        public bool IsAdmin { get { return TipoUsuario == "Admin"; } }

        public Usuario()
        {
        }

        public Usuario(int id, string nome, string email, string tipoUsuario)
        {
            Id = id;
            Nome = nome;
            Email = email;
            TipoUsuario = tipoUsuario;
        }
    }
}