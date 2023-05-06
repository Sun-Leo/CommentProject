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
	public class CategoryManager : ICategoryService
	{
		private readonly ICategoryDal _categoryDal;

		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}

		public void TAdd(Category t)
		{
			_categoryDal.Add(t);
		}

		public void TDelete(Category t)
		{
			_categoryDal.Delete(t);
		}

		public Category TGetById(int id)
		{
			return _categoryDal.GetById(id);
		}

		public List<Category> TGetList()
		{
			return _categoryDal.GetList();
		}

		public List<Category> TGetListByFilter(Expression<Func<Category, bool>> filter)
		{
			return _categoryDal.GetListByFilter(filter);
		}

		public void TUpdate(Category t)
		{
			_categoryDal.Update(t);
		}
	}
}
