using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission9_twoodru8.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Mission9_twoodru8.Model;

namespace Mission9_twoodru8.Controllers
{
	public class HomeController : Controller
	{
		private IBookstoreRepo repo;
		public HomeController(IBookstoreRepo temp)
		{
			repo = temp;
		}
		public IActionResult Index(int pageNum = 1)
		{
			int pageSize = 10;

			var model = new BooksViewModel
			{
				Books = repo.Books
				.OrderBy(b => b.Title)
				//means that we can skip this many records
				//This will get the pageNum and then skip the pagesize
				.Skip((pageNum - 1) * pageSize)
				//take means how many results to return
				.Take(pageSize),

				PageInfo = new PageInfo
				{
					TotalNumBooks = repo.Books.Count(),
					BooksPerPage = pageSize,
					CurrentPage = pageNum,
				}
			};

			return View(model);
		}

	}
}
