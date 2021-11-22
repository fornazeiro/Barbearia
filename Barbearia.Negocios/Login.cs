using Barbearia.Dados.Repositorios;

namespace Barbearia.Negocios
{
    public class Login 
    {
        public Entidades.Usuario Logon(Entidades.Login login)
        {
            RepositorioLogin rLogin = new RepositorioLogin();

            return rLogin.Logon(login);
        }
    }
}
