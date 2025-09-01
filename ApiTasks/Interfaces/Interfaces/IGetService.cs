
using ApiTasks.DataBase;
using ApiTasks.DTOs.Access;
using ApiTasks.DTOs.Tasks;

namespace ApiTasks.Interfaces.Interfaces
{
    public interface IGetService
    {
        public Task<CategoryView> GetCategoryById(int idCategory, int idUser);
        public Task<List<CategoryView>> GetCategorys(int idUser);
        public Task<List<TaskView>> GetTasks(int idUser);
        public Task<List<TaskView>> GetTasksByCategory(int idCategory, int idUser);
        public Task<int> GetUserByName(string UserName);
        public Task<UsuarioView> Login(LoginDto LoginData);
    }
}
