using _2_Biblioteca.Context;
using _2_Biblioteca.Models.Domain;
using _2_Biblioteca.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace _2_Biblioteca.Services.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly ApplicationDbContext _context;

        public UsuarioServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetTotalUsuarios()
        {
            return await _context.Usuarios.CountAsync();
        }

        public async Task<List<Usuario>> GetUsuarios()
        {
            try
            {
                return await _context.Usuarios
                    .Include(x => x.Roles)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error: " + ex.Message);
            }
        }

        public async Task<bool> AddUser(Usuario request)
        {
            try
            {
                Usuario usuario = new Usuario()
                {
                    Nombre = request.Nombre,
                    UserName = request.UserName,
                    Password = request.Password,
                    FkRol = request.FkRol
                };
                await _context.Usuarios.AddAsync(usuario);
                var result = await _context.SaveChangesAsync();

                return result > 0;

            }
            catch (Exception ex)
            {

                throw new Exception("Sucedio un error: " + ex.Message);
            }
        }




        public async Task<Usuario> GetbyId(int id)
        {
            try
            {
                return await _context.Usuarios
                    .FirstOrDefaultAsync(x => x.PkUsuario == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error: " + ex.Message);
            }
        }


        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                Usuario usuario = await GetbyId(id);

                if (usuario == null)
                    return false;

                _context.Usuarios.Remove(usuario);
                int result = await _context.SaveChangesAsync();

                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error: " + ex.Message);



            }
        }
    }
}
