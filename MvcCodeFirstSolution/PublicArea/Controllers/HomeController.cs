using System.Linq;
using System.Web.Mvc;
using Common.Linq;
using Domain.Abstractions;
using Domain.Entities;

namespace PublicArea.Controllers
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
       
        #region Index

        public ActionResult Index()
        {
            var categories = _categoryRepository.FindAll();
            return View(categories);
        }

        #endregion Index

        #region Create

        public ActionResult Create()
        {
            return View(new Category());
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Create(category);
                _unitOfWork.Commit();

                return RedirectToAction("Index");
            }
            return View();
        }

        #endregion Create

        #region Edit

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

                return RedirectToAction("Index");
            }
            return View();
        }

        #endregion Edit

        #region Delete

        [HttpPost]
        public ActionResult DeleteViaAjax(int id)
        {
            _categoryRepository.Delete(id);
            _unitOfWork.Commit();

            // return the redirectUrl back to browser.  browser redirect to the Index view using this url
            return new JsonResult { Data = "/Category/Index" };
        }

        [HttpPost]
        public ActionResult DeleteViaPost(int id)
        {
            _categoryRepository.Delete(id);
            _unitOfWork.Commit();
 
            return RedirectToAction("Index");
        }

        #endregion Delete

        #region Browse Products

        public ActionResult Browse(int id)
        {
            var category = _categoryRepository.FindAll()
                                              .Include<Category, Product>("Products")
                                              .Single(c => c.Id == id);
            return View(category);
        }

        #endregion Browse Products
    }
}
