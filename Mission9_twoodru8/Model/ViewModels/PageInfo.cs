using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_twoodru8.Model.ViewModels
{
	public class PageInfo
	{
		public int TotalNumBooks { get; set; }
		public int BooksPerPage { get; set; }
		public int CurrentPage { get; set; }
		//figure out how many pages we need
		//this is casting
		//ceiling will take this number and put it to the next highest number you can.
		public int TotalPages => (int) Math.Ceiling((double)TotalNumBooks / BooksPerPage);
	}
}
