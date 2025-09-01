using ApiTasks.Common;
using ApiTasks.DataBase;
using ApiTasks.DTOs.Tasks;
using ApiTasks.Interfaces.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiTasks.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TasksController(Utilitys utilitys, IPostService postService, IGetService getService, IUpdateService updateService) : ControllerBase
    {
        private readonly Utilitys _utility = utilitys;
        private readonly IPostService _postService = postService;
        private readonly IGetService _getService = getService;
        private readonly IUpdateService _updateService = updateService;

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateTask(TaskDto Task)
        {
            if(!ModelState.IsValid)
                return Ok(_utility.GetResponse(Message: "Invalid data", Success: false, StatusCode: 400, Errors: ModelState));

            //Get Id user from token
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null)
                return Ok(_utility.GetResponse(Message: "Invalid token", Success: false, StatusCode: 400));
            int IdUser = int.Parse(identity!.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            TTask TaskModel = await _postService.CreateTask(Task, IdUser);
            if (TaskModel.Id == 0)
                return Ok(_utility.GetResponse(Message: "A ocurred error to create", Success: false, StatusCode: 400));

            return Ok(_utility.GetResponse(Message: "Task created succesfuly", Success: true, StatusCode: 201, Data: TaskModel));
        }

        [HttpPut]
        [Route("complete")]
        public async Task<IActionResult> CompleteTask(int IdTask)
        {
            //Get Id user from token
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null)
                return Ok(_utility.GetResponse(Message: "Invalid token", Success: false, StatusCode: 400));
            int IdUser = int.Parse(identity!.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            TaskView TaskModel = await _updateService.CompleteTask(IdTask, IdUser);
            if(TaskModel is null)
                return Ok(_utility.GetResponse(Message: "Task not found", Success: false, StatusCode: 404));
            
            if (TaskModel.Id == 0)
                return Ok(_utility.GetResponse(Message: "A ocurred error to complete", Success: false, StatusCode: 400));

            return Ok(_utility.GetResponse(Message: "Task completed succesfuly", Success: true, StatusCode: 200, Data: TaskModel));
        }


        [HttpGet]
        [Route("gettasksbycaetgory")]
        public async Task<IActionResult> GetTasksByCategory(int IdCategory)
        {
            //Get Id user from token
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null)
                return Ok(_utility.GetResponse(Message: "Invalid token", Success: false, StatusCode: 400));
            int IdUser = int.Parse(identity!.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            List<TaskView> Tasks = await _getService.GetTasksByCategory(IdCategory, IdUser);
            return Ok(_utility.GetResponse(Message: "Tasks found", Success: true, StatusCode: 200, Data: Tasks));
        }


        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateTask(TaskDto Task)
        {
            if(!ModelState.IsValid)
                return Ok(_utility.GetResponse(Message: "Invalid data", Success: false, StatusCode: 400, Errors: ModelState));

            //Get Id user from token
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null)
                return Ok(_utility.GetResponse(Message: "Invalid token", Success: false, StatusCode: 400));
            int IdUser = int.Parse(identity!.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            TTask TaskModel = await _updateService.UpdateTask(Task, IdUser);
            if (TaskModel.Id == 0)
                return Ok(_utility.GetResponse(Message: "A ocurred error to update", Success: false, StatusCode: 400));

            return Ok(_utility.GetResponse(Message: "Task updated succesfuly", Success: true, StatusCode: 200, Data: TaskModel));
        }

        [HttpGet]
        [Route("getTasks")]
        public async Task<IActionResult> GetTasks()
        {
            //Get Id user from token
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null)
                return Ok(_utility.GetResponse(Message: "Invalid token", Success: false, StatusCode: 400));
            int IdUser = int.Parse(identity!.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            List<TaskView> Tasks = await _getService.GetTasks(IdUser);
            return Ok(_utility.GetResponse(Message: "Tasks found", Success: true, StatusCode: 200, Data: Tasks));
        }

        #region Categorys
        [HttpPost]
        [Route("createCategory")]
        public async Task<IActionResult> CreateCategory(CategoryDto Category)
        {
            if(!ModelState.IsValid)
                return Ok(_utility.GetResponse(Message: "Invalid data", Success: false, StatusCode: 400, Errors: ModelState));

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null)
                return Ok(_utility.GetResponse(Message: "Invalid token", Success: false, StatusCode: 400));
            int IdUser = int.Parse(identity!.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            CategoryView Group = await _postService.CreateCategory(Category,IdUser);
            if (Group.Id == 0)
                return Ok(_utility.GetResponse(Message: "A ocurred error to create", Success: false, StatusCode: 400));

            return Ok(_utility.GetResponse(Message: "Category created succesfuly", Success: true, StatusCode: 201, Data: Group));
        }

        [HttpGet]
        [Route("getCategorys")]
        public async Task<IActionResult> GetCategorys()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null)
                return Ok(_utility.GetResponse(Message: "Invalid token", Success: false, StatusCode: 400));
            int IdUser = int.Parse(identity!.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            List<CategoryView> Categorys = await _getService.GetCategorys(IdUser);
            return Ok(_utility.GetResponse(Message: "Categorys found", Success: true, StatusCode: 200, Data: Categorys));
        }

        [HttpPut]
        [Route("updateCategory")]
        public async Task<IActionResult> UpdateCategory(CategoryDto Category)
        {
            if(!ModelState.IsValid)
                return Ok(_utility.GetResponse(Message: "Invalid data", Success: false, StatusCode: 400, Errors: ModelState));

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null)
                return Ok(_utility.GetResponse(Message: "Invalid token", Success: false, StatusCode: 400));
            int IdUser = int.Parse(identity!.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            CategoryView Group = await _updateService.UpdateCategory(Category, IdUser);
            if(Group is null)
                return Ok(_utility.GetResponse(Message: "Category not found", Success: false, StatusCode: 404));

            if (Group.Id == 0)
                return Ok(_utility.GetResponse(Message: "A ocurred error to update", Success: false, StatusCode: 400));

            return Ok(_utility.GetResponse(Message: "Category updated succesfuly", Success: true, StatusCode: 200, Data: Group));
        }

        [HttpGet]
        [Route("getcategorybyid")]
        public async Task<IActionResult> GetCategoryById(int IdCategory)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null)
                return Ok(_utility.GetResponse(Message: "Invalid token", Success: false, StatusCode: 400));
            int IdUser = int.Parse(identity!.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            CategoryView Group = await _getService.GetCategoryById(IdCategory, IdUser);
            if(Group is null)
                return Ok(_utility.GetResponse(Message: "Category not found", Success: false, StatusCode: 404));

            return Ok(_utility.GetResponse(Message: "Category found", Success: true, StatusCode: 200, Data: Group));
        }

        #endregion

    }
}
