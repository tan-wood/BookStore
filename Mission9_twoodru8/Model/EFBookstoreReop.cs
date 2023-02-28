using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_twoodru8.Model
{
	public class EFBookstoreReop:IBookstoreRepo
	{
		//this replaces the controller doing this
		private BookstoreContext context { get; set; }
		public EFBookstoreReop(BookstoreContext temp)
		{
			context = temp;
		}
		//This is acting in place of the dbcontext so that we decouple the project
		public IQueryable<Book> Books => context.Books;
	}
}
