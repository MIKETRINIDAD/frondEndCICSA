using app_frontEnd.Helpers;
using app_frontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace app_frontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration,ILogger<HomeController> logger)
        {
            _logger = logger;
            _configuration = configuration; 
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<PartialViewResult> Listado()
        {
            //[FromBody] IConfiguration configuration
            var apiModel = new ApiModel<List<listTaskModel>>(_configuration);
            var res =  await apiModel.GetAllAsync();
            List<TaskModels> models = new List<TaskModels>();
            return PartialView(res);
        }

        #region Modal
        #region NewDate
        public ActionResult DateTask()
        {
            TaskModels task = new TaskModels();
            return View(task);
        }
        public PartialViewResult NewTask()
        {
            return PartialView();
        }
        #endregion NewDate

        #region EditDate
        public ActionResult DateEdit(string Id)
        {
            var apiModel = new ApiModel<TaskModels>(_configuration);
            var res = apiModel.GetByIdAsync(Id).Result;
            return PartialView(res);
        }
        public PartialViewResult EditTask(TaskModels task)
        {
            return PartialView(task);
        }
        #endregion EditDate

        #region DeleteDate
        public ActionResult DateDelete(string Id)
        {
            var apiModel = new ApiModel<TaskModels>(_configuration);
            var res = apiModel.GetByIdAsync(Id).Result;
            return PartialView(res);
        }
        public PartialViewResult TaskDelete(TaskModels task)
        {
            return PartialView(task);
        }
        #endregion DeleteDate
        #endregion Modal

        #region CRUD

        #region Send
        [HttpPost]
        public async Task<IActionResult> SendTask(taskCreate taskRequest)
        {
            List<string> message = new List<string>();
            var apiModel = new ApiModel<taskCreate>(_configuration);
            if (taskRequest != null)
            {
                var res = await apiModel.PostAsync(taskRequest);
                return Content("<script>closeModal('Nuevo');Lists();</script>");
            }
            else
            {
                return Content("<script>closeModal('Nuevo');Lists();</script>");
            }
        }
        #endregion Send

        #region Update
        [HttpPut]
        public async Task<IActionResult> UpdateTask(TaskModels taskRequest)
        {
            List<string> message = new List<string>();
            var apiModel = new ApiModel<TaskModels>(_configuration);
            if (taskRequest != null)
            {
                var res = await apiModel.PutAsync(taskRequest, taskRequest._id);
                return Content("<script>closeModal('Editar');Lists();</script>");
            }
            else
            {
                return Content("<script>closeModal('Editar');Lists();</script>");
            }
        }
        #endregion Update

        #region Delete
        [HttpDelete]
        public async Task<IActionResult> DeleteTask(TaskModels taskRequest)
        {
            List<string> message = new List<string>();
            var apiModel = new ApiModel<TaskModels>(_configuration);
            if (taskRequest != null)
            {
                var res = await apiModel.DeleteAsync(taskRequest._id);
                return Content("<script>closeModal('Eliminar');Lists();</script>");
            }
            else
            {
                return Content("<script>closeModal('Eliminar');Lists();</script>");
            }
        }
        #endregion Delete

        #endregion CRUD

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
