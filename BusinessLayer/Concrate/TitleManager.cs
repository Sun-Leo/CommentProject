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
	public class TitleManager : ITitleService
	{
		private readonly ITitleDal _titleDal;

		public TitleManager(ITitleDal titleDal)
		{
			_titleDal = titleDal;
		}

		public void TAdd(Title t)
		{
			_titleDal.Add(t);
		}

		public void TDelete(Title t)
		{
			_titleDal.Delete(t);
		}

		public Title TGetById(int id)
		{
			return _titleDal.GetById(id);
		}

		public List<Title> TGetList()
		{
			return _titleDal.GetList();
		}

		public List<Title> TGetListByFilter(Expression<Func<Title, bool>> filter)
		{
			return _titleDal.GetListByFilter(filter);
		}

		public void TUpdate(Title t)
		{
			_titleDal.Update(t);
		}
	}
}
