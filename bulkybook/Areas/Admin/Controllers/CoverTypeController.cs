using BulkyBook.DataAcces;
using BulkyBook.DataAcces.Repository.IRepository;
using BulkyBook.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace bulkybook.Controllers
{[Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<CoverType> objCoverTypeList = _unitOfWork.CoverType.GetAll();
            return View(objCoverTypeList);
        }

        //Get
        public IActionResult Create()
        {
             return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken] // منع من الاختراق عدم وجدو اكثر من طلب 
        public IActionResult Create(CoverType obj)
        {    // if find name and dispaly is same data 
           
            if (ModelState.IsValid) // to in valid all felid is write 
            {
                _unitOfWork.CoverType.Add(obj);
                _unitOfWork.save();
                // to do massage on view made it work 
                TempData["success"] = "Catagory Create successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //Get
        public IActionResult Edit(int? id)
        {
            if(id == null || id ==0)
            {
                return NotFound();
            }
            // sreach on table by id with 3 way
            //var  categoryFromDb=_db.categories.Find(id);
            var CoverTypeFirstDb = _unitOfWork.CoverType.GetFirstorDefault(u=>u.Id==id);
            //var categorySingleDb = _db.categories.SingleOrDefault(u => u.Id == id);
            if(CoverTypeFirstDb == null)
            {
                return NotFound();
            }
            return View(CoverTypeFirstDb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken] // منع من الاختراق عدم وجدو اكثر من طلب 
        public IActionResult Edit(CoverType obj)
        {    // if find name and dispaly is same data 
           
            if (ModelState.IsValid) // to in valid all felid is write 
            {
                _unitOfWork.CoverType.update(obj);
                _unitOfWork.save();
                // to do massage on view made it work update
                TempData["success"] = "Catagory update successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
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
    }
}
