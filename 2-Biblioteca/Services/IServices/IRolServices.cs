using _2_Biblioteca.Models.Domain;

namespace _2_Biblioteca.Services.IServices
{
    public interface IRolServices
    {
        Task<int> GetTotalRoles();
        Task<List<Rol>> GetAll();
        Task<bool> AddRol(Rol request);
        Task<Rol> GetbyId(int id);
        Task<bool> UpdateRol(Rol request);
        Task<bool> DeleteRol(int id);
    }
}