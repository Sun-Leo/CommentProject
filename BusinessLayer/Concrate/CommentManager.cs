using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
	public class CommentManager : ICommentService
	{
		private readonly ICommentDal _commentDal;

		public CommentManager(ICommentDal commentDal)
		{
			_commentDal = commentDal;
		}

		public void TAdd(Comment t)
		{
			_commentDal.Add(t);
		}

		public void TDelete(Comment t)
		{
			_commentDal.Delete(t);
		}

		public Comment TGetById(int id)
		{
			return _commentDal.GetById(id);
		}

        public List<Comment> TGetCommentsByTitle(int id)
        {
			return _commentDal.GetCommentsByTitle(id);
        }

        public List<Comment> TGetCommentsByTitleWithUser(int id)
        {
			return _commentDal.GetCommentsByTitleWithUser(id);
        }

        public List<Comment> TGetCommentsByUserWithTitle(int id)
        {
            return _commentDal.GetCommentsByUserWithTitle(id);
        }

        public List<Comment> TGetCommentsWithCategory()
        {
			return _commentDal.GetCommentsWithCategory();
        }

        public List<Comment> TGetList()
		{
			return _commentDal.GetList();
		}

		public List<Comment> TGetListByFilter(Expression<Func<Comment, bool>> filter)
		{
			return _commentDal.GetListByFilter(filter);
		}

		public void TUpdate(Comment t)
		{
			_commentDal.Update(t);
		}
	}
}
