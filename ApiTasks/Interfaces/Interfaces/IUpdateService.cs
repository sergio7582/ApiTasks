using ApiTasks.DataBase;
using ApiTasks.DTOs.Tasks;

namespace ApiTasks.Interfaces.Interfaces
{
    public interface IUpdateService
    {
        public Task<TaskView> CompleteTask(int idTask, int idUser);
        public Task<CategoryView> UpdateCategory(CategoryDto category, int idUser);
        public Task<TTask> UpdateTask(TaskDto task, int idUser);
    }
}
