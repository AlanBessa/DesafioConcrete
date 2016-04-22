using DCS.Domain.Interfaces.Repositorios;
using System.Linq;
using DCS.Domain.Entidades;
using DCS.Infra.Data.Context;

namespace DCS.Infra.Data.Repositorios
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DCSContext context) 
            : base(context)
        {
            _context = context;
        }

        public Usuario ObterPorEmail(string email)
        {
            return Buscar(u => u.Email.Endereco == email).FirstOrDefault();
        }
    }
}
