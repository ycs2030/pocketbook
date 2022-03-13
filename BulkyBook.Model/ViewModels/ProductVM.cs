using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Model.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        // this for get all items on table category by using the class of _unitOfWork
        [ValidateNever]
        public IEnumerable<SelectListItem> CatagoryList { get; set; }

        // this for get all items on table CoverType by using the class of _unitOfWork
        [ValidateNever]
        public  IEnumerable<SelectListItem> CoverTypeList { get; set; }

    }
    // this was on productcontroller to use table category and table CoverType

    // get obj from product class
    //Product product = new();
    //// this for get all items on table category by using the class of _unitOfWork
    //IEnumerable<SelectListItem> CatagoryList = _unitOfWork.Category.GetAll().Select(
    //    u => new SelectListItem
    //    {
    //        Text = u.Name,
    //        Value =u.Id.ToString(),
    //    });
    //// this for get all items on table CoverType by using the class of _unitOfWork
    //IEnumerable<SelectListItem> CoverTypeList = _unitOfWork.CoverType.GetAll().Select(
    //    u => new SelectListItem
    //    {
    //        Text = u.Name,
    //        Value = u.Id.ToString(),
    //    });
}
