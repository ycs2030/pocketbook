using BulkyBook.DataAcces;
using BulkyBook.DataAcces.Repository.IRepository;
using BulkyBook.Model;
using BulkyBook.Model.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace bulkybook.Controllers;
   [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
           return View();
        }
                      
        //Get
        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new()
            { // this from class is ProductVM to get this on view page
                Product = new(),
                CatagoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString(),
                }),
                CoverTypeList = _unitOfWork.CoverType.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString(),
                }),

            };
            //create product
            if (id == null || id ==0)
            { //// this for get data from class and put in view page by ViewBag
              // ViewBag.CatagoryList= CatagoryList;
            //// this for get data from class and put in view page by ViewData
               // ViewData["CoverTypeList"] = CoverTypeList;
                return View(productVM);
            }
            else
            {// update product

            }

            return View(productVM);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken] // منع من الاختراق عدم وجدو اكثر من طلب 
        public IActionResult Upsert(ProductVM obj,IFormFile? file)
        {    // if find name and dispaly is same data 
        //    obj.Product.ImageUrl = file.FileName;
           
            if (ModelState.IsValid) // to in valid all felid is write 
            {
                // this fore get images file from wwwroot 
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if(file!=null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath,@"images\Products");
                    var extension = Path.GetExtension(file.FileName);

                    using (var fileStreams = new FileStream(Path.Combine(uploads,fileName+extension), FileMode.Create)) 
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.Product.ImageUrl= @"\images\Products\" + fileName +extension;
                }
                _unitOfWork.product.Add(obj.Product);
                _unitOfWork.save();
                // to do massage on view made it work update
                TempData["success"] = "product Create successfully";
                return RedirectToAction("Index");
            }
            return View(obj.Product);
        }
        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            // sreach on table by id with 3 way
            //var categoryFromDb = _db.categories.Find(id);
            var CoverTypeFirstDb = _unitOfWork.CoverType.GetFirstorDefault(u=>u.Id==id);
            //var categorySingleDb = _db.categories.SingleOrDefault(u => u.Id == id);
            if (CoverTypeFirstDb == null)
            {
                return NotFound();
            }
            return View(CoverTypeFirstDb);
        }
        //Post
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken] // منع من الاختراق عدم وجدو اكثر من طلب 
        public IActionResult DeletePost(int? id)
        {    //how to delete data from table
            var obj = _unitOfWork.CoverType.GetFirstorDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.CoverType.Remove(obj);
            _unitOfWork.save();
            // to do massage on view made it work Delete
            TempData["success"] = "Catagory Delete successfully";
            return RedirectToAction("Index");
            
        }

        #region API CALLS
       [HttpGet]
        public IActionResult GetAll()
        {
        var productList = _unitOfWork.product.GetAll();
        return Json(new { data = productList });
        }
         #endregion

}



