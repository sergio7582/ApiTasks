using ApiTasks.DataBase;
using ApiTasks.DTOs.Tasks;
using ApiTasks.Interfaces.Interfaces;

namespace ApiTasks.Interfaces
{
    public class UpdateService : IUpdateService
    {
        private readonly DbAa6e7eTasksContext _context;
        public UpdateService(DbAa6e7eTasksContext context)
        {
            _context = context;
        }

        public async Task<TaskView> CompleteTask(int idTask, int idUser)
        {
            TTask? task = await _context.TTasks.FindAsync(idTask);
            if (task != null && task.IdUser == idUser)
            {
                task.IdStatus = 2;
                await _context.SaveChangesAsync();
                return new TaskView
                {
                    Id = task.Id,
                    Title = task.Title!,
                    Description = task.Details!,
                    DateLimit = task.Limitdate,
                    Category = task.IdGroupNavigation!.Title!,
                    Status = task.IdStatusNavigation!.Name!,

                };
            }
            return null!;
        }

        public async Task<CategoryView> UpdateCategory(CategoryDto category, int idUser)
        {
            TGroup? group = await _context.TGroups.FindAsync(category.Id);
            if (group != null && group.IdUser == idUser)
            {
                group.Title = category.Title;
                group.Icon = category.Icon;
                await _context.SaveChangesAsync();
                return new CategoryView
                {
                    Id = group.Id,
                    Title = group.Title!,
                    Icon = group.Icon!
                };
            }

            return null!;
        }

        public async Task<TTask> UpdateTask(TaskDto task, int idUser)
        {
            TTask? tTask = await _context.TTasks.FindAsync(task.Id);
            if (tTask != null && tTask.IdUser == idUser)
            {
                tTask.Title = task.Title;
                tTask.Details = task.Description;
                tTask.IdGroup = task.IdCategory;
                tTask.Limitdate = task.DateLimit;
                await _context.SaveChangesAsync();
                return tTask;
            }
            return null!;
        }
    }
}
