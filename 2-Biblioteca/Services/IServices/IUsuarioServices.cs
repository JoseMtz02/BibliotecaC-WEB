using _2_Biblioteca.Models.Domain;

namespace _2_Biblioteca.Services.IServices
{
    public interface IUsuarioServices
    {

        Task<int> GetTotalUsuarios();

        Task<List<Usuario>> GetUsuarios();
        Task<bool> AddUser(Usuario request);
        Task<Usuario> GetbyId(int id);
        Task<bool> DeleteUser(int id);




    }
}
