using System.Web.Mvc;
using Domain.Abstractions;

namespace AdministrationArea.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        #region ctor

        public HomeController(IUnitOfWork unitOfWork, ICategoryRepository repository)
        {
            _categoryRepository = repository;
            _unitOfWork = unitOfWork;
        }

        #endregion ctor

        public ActionResult Index()
        {
            var categories = _categoryRepository.FindAll();
            return View(categories);
        }
    }
}
