using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission9_twoodru8.Model;

namespace Mission9_twoodru8.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private IBookstoreRepo repo { get; set; }

        public CategoriesViewComponent(IBookstoreRepo temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["bookCategory"];

            var categories = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return View(categories);
        }
    }
}
