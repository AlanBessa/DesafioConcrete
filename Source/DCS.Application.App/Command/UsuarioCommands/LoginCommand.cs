namespace DCS.Application.App.Command.UsuarioCommands
{
    public class LoginCommand
    {
        public LoginCommand(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public string Senha { get; private set; }

        public string Email { get; private set; }
    }
}
