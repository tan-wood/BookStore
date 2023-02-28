using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_twoodru8.Model
{
	public interface IBookstoreRepo
	{
		IQueryable<Book> Books { get; }
	}
}
