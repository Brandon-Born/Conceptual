using System.Web.Mvc;
using Domain.Abstractions;
using Domain.Entities;

namespace AdministrationArea.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        #region ctor

        public CategoryController(IUnitOfWork unitOfWork, ICategoryRepository repository)
        {
            _categoryRepository = repository;
            _unitOfWork = unitOfWork;
        }

        #endregion ctor

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var category = _categoryRepository.Find(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Update(category);
                _unitOfWork.Commit();
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}
