using System.Web.Mvc;
using Domain.Abstractions;
using Common.Linq;
using Domain.Entities.ShippingCalculation;

namespace PublicArea.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IShippingService _shippingService;

        public ProductController(IUnitOfWork unitOfWork, IProductRepository repository, IShippingService shippingService)
        {
            _unitOfWork = unitOfWork;
            _productRepository = repository;
            _shippingService = shippingService;
        }

        public ActionResult Index()
        {
            var products = _productRepository.FindAll()
                                             .Include(p => p.Category);
            return View(products);
        }

        public ActionResult Detail(int id)
        {
            var product = _productRepository.Find(id);
            var shippingPrice = _shippingService.CalculateShippingAmount(product, State.California);
            return View(product);
        }
    }
}
