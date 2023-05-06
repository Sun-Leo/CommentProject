using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface ICommentDal: IGenericDal<Comment>
	{
		List<Comment> GetCommentsByTitle(int id);
		List<Comment> GetCommentsByTitleWithUser(int id);
		List<Comment> GetCommentsByUserWithTitle(int id);
		List<Comment> GetCommentsWithCategory();


	}
}
