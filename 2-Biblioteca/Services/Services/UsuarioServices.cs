using _2_Biblioteca.Context;
using _2_Biblioteca.Models.Domain;
using _2_Biblioteca.Services.IServices;

namespace _2_Biblioteca.Services.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly ApplicationDbContext _context;

        public UsuarioServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Usuario> GetUsuarios()
        {
            try
            {
                List<Usuario> result = _context.Usuarios.ToList();
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception("Sucedio un error: " +ex.Message);
            }
               
        
        }
        

        
    }
}
