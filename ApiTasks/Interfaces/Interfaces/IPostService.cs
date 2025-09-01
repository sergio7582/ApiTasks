using ApiTasks.DataBase;
using ApiTasks.DTOs.Access;
using ApiTasks.DTOs.Tasks;

namespace ApiTasks.Interfaces.Interfaces
{
    public interface IPostService
    {
        public Task<TUser> CheckIn(UsuarioDTO usuario);
        public Task<CategoryView> CreateCategory(CategoryDto category, int idUser);
        public Task<TTask> CreateTask(TaskDto task, int IdUser);
    }
}
