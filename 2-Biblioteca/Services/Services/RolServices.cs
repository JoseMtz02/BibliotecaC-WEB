using _2_Biblioteca.Context;
using _2_Biblioteca.Models.Domain;
using _2_Biblioteca.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace _2_Biblioteca.Services.Services
{
    public class RolServices : IRolServices
    {
        private readonly ApplicationDbContext _context;

        public RolServices(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<int> GetTotalRoles()
        {
            return await _context.Roles.CountAsync();
        }

        public async Task<List<Rol>> GetAll()
        {
            try
            {
                return await _context.Roles.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error: " + ex.Message);
            }
        }

        public async Task<bool> AddRol(Rol request)
        {
            try
            {
                await _context.Roles.AddAsync(request);
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error: " + ex.Message);
            }
        }

        public async Task<Rol> GetbyId(int id)
        {
            try
            {
                return await _context.Roles.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error: " + ex.Message);
            }
        }

        public async Task<bool> UpdateRol(Rol request)
        {
            try
            {
                _context.Roles.Update(request);
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error: " + ex.Message);
            }
        }

        public async Task<bool> DeleteRol(int id)
        {
            try
            {
                var rol = await _context.Roles.FindAsync(id);
                if (rol == null)
                    return false;

                _context.Roles.Remove(rol);
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error: " + ex.Message);
            }
        }
    }
}