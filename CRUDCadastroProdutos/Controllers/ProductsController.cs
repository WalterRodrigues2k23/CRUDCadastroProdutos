﻿using CRUDCadastroProdutos.Data;
using Microsoft.AspNetCore.Mvc;

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

        }
    }
}
