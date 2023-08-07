using CRUDCadastroProdutos.Data;
using CRUDCadastroProdutos.Models;
using CRUDCadastroProdutos.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDCadastroProdutos.Controllers
{
    public class ProductsController : Controller
    {
        private readonly MVCDbContext mVCDbContext;
        public ProductsController(MVCDbContext mVCDbContext)
        {
            this.mVCDbContext = mVCDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await mVCDbContext.Products.ToListAsync();
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel addProductRequest)
        {
            var Products = new Products()
            {
                Id = Guid.NewGuid(),
                Name = addProductRequest.Name,
                Price = addProductRequest.Price,
                ValidDate = addProductRequest.ValidDate,
            };

            mVCDbContext.Products.Add(Products);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid Id)
        {
            var product = await mVCDbContext.Products.FirstOrDefaultAsync(x => x.Id == Id);

            if (product != null)
            {
                var viewmodel = new UpdateProductViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    ValidDate = product.ValidDate,
                };

                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateProductViewModel model)
        {
            var product = await mVCDbContext.Products.FindAsync(model.Id);

            if (product != null)
            {
                product.Name = model.Name;
                product.Price = model.Price;                
                product.ValidDate = model.ValidDate;
                
                await mVCDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateProductViewModel model)
        {
            var product = await mVCDbContext.Products.FindAsync(model.Id);

            if (product != null)
            {
                mVCDbContext.Products.Remove(product);
                await mVCDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
