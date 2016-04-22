namespace DCS.Application.App.Command.UsuarioCommands
{
    public class RegistrarUsuarioCommand
    {
        public RegistrarUsuarioCommand(string email, string senha, string confirmarSenha)
        {
            Email = email;
            Senha = senha;
            ConfirmarSenha = confirmarSenha;
        }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string ConfirmarSenha { get; set; }
    }
}
