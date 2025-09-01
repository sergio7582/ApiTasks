using ApiTasks.Common;
using ApiTasks.DataBase;
using ApiTasks.DTOs.Access;
using ApiTasks.DTOs.Tasks;
using ApiTasks.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiTasks.Interfaces
{
    public class PostService : IPostService
    {
        private Utilitys _utilitys;
        private DbAa6e7eTasksContext _contextDb;
        public PostService(Utilitys utilitys, DbAa6e7eTasksContext context) 
        {
            _utilitys = utilitys;
            _contextDb = context;
        }
        public async Task<TUser> CheckIn(UsuarioDTO usuario)
        {
            TUser modelUser = new()
            {
                Username = usuario.Username,
                Name = usuario.Name,
                Lastname = usuario.Lastname,
                Email = usuario.Email,
                Password = _utilitys.EncrypthSHA256(usuario.Password),
                Idstatus = 1,
                Createat = DateTime.Now,
                Verified = 0
            };

            await _contextDb.TUsers.AddAsync(modelUser);
            await _contextDb.SaveChangesAsync();

            return modelUser;
        }

        public async Task<CategoryView> CreateCategory(CategoryDto category, int idUser)
        {
            TGroup group = new()
            {
                Title = category.Title,
                Icon = category.Icon,
                Createat = DateTime.Now,
                IdStatus = 1,
                IdUser = idUser
            };

            await _contextDb.TGroups.AddAsync(group);
            await _contextDb.SaveChangesAsync();

            CategoryView categoryView = new()
            {
                Id = group.Id,
                Title = group.Title,
                Icon = group.Icon!
            };

            return categoryView;
        }

        public async Task<TTask> CreateTask(TaskDto task, int IdUser)
        {
            TTask Ttask = new()
            {
                Title = task.Title,
                Details = task.Description,
                IdGroup = task.IdCategory,
                IdUser = IdUser,
                Createat = DateTime.Now,
                IdStatus = 1,
                Limitdate = task.DateLimit
            };

            await _contextDb.TTasks.AddAsync(Ttask);
            await _contextDb.SaveChangesAsync();
            return Ttask;
        }
    }
}
