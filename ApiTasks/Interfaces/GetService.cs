using ApiTasks.Common;
using ApiTasks.DataBase;
using ApiTasks.DTOs.Access;
using ApiTasks.DTOs.Tasks;
using ApiTasks.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiTasks.Interfaces
{
    public class GetService : IGetService
    {
        private readonly DbAa6e7eTasksContext _contextDb;
        private readonly Utilitys _utilitys;
        public GetService(DbAa6e7eTasksContext context, Utilitys utilitys) 
        {
            _contextDb = context;
            _utilitys = utilitys;
        }

        public async Task<CategoryView> GetCategoryById(int idCategory, int idUser)
        {
            CategoryView? categoryView = await _contextDb.TGroups.Where(x => x.Id == idCategory && x.IdUser == idUser).Select(x => new CategoryView()
            {
                Id = x.Id,
                Title = x.Title!,
                Icon = x.Icon!
            }).FirstOrDefaultAsync();
            if (categoryView == null)
                return null!;
            
            return categoryView;
        }

        public async Task<List<CategoryView>> GetCategorys(int idUser)
        {
            List<CategoryView> categorys = await _contextDb.TGroups.Where(x => x.IdUser == idUser).Select(x => new CategoryView()
            {
                Id = x.Id,
                Title = x.Title!,
                Icon = x.Icon!
            }).ToListAsync();

            return categorys;
        }

        public async Task<List<TaskView>> GetTasks(int idUser)
        {
            List<TaskView> tasks = await _contextDb.TTasks.Where(x => x.IdUser == idUser).Select(x => new TaskView()
            {
                Id = x.Id,
                Title = x.Title!,
                Description = x.Details!,
                Category = x.IdGroupNavigation!.Title!,
                DateLimit = x.Limitdate,
                CreateAt = x.Createat,
                Status = x.IdStatusNavigation!.Name!
            }).ToListAsync();
            return tasks;
        }

        public async Task<List<TaskView>> GetTasksByCategory(int idCategory, int idUser)
        {
            List<TaskView> tasks = await _contextDb.TTasks.Where(x => x.IdGroup == idCategory && x.IdUser == idUser).Select(x => new TaskView()
            {
                Id = x.Id,
                Title = x.Title!,
                Description = x.Details!,
                Category = x.IdGroupNavigation!.Title!,
                DateLimit = x.Limitdate,
                CreateAt = x.Createat,
                Status = x.IdStatusNavigation!.Name!
            }).ToListAsync();

            return tasks;
        }

        public async Task<int> GetUserByName(string UserName)
        {
            int IdUser = await _contextDb.TUsers.Where(x => x.Username!.Trim().Equals(UserName.Trim(), StringComparison.CurrentCultureIgnoreCase)).Select(x => x.Id).FirstOrDefaultAsync();
            return IdUser;
        }

        public async Task<UsuarioView> Login(LoginDto LoginData)
        {
            var user = await _contextDb.TUsers.FirstOrDefaultAsync(x => x.Username == LoginData.Username && x.Password == _utilitys.EncrypthSHA256(LoginData.Password));
            if (user != null)
            {
                user.Lastlogindate = DateTime.Now;
                await _contextDb.SaveChangesAsync();
                UsuarioView userView = new()
                {
                    Id = user.Id,
                    Username = user.Username!,
                    Name = user.Name!,
                    Lastname = user.Lastname!,
                    Email = user.Email!,
                    LastLogin = user.Lastlogindate!.Value
                };

                return userView;
            }
            return null!;
        }
    }
}
