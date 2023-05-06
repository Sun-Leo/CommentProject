﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ICommentService: IGenericService<Comment>
	{
		List<Comment> TGetCommentsByTitle(int id);
		List<Comment> TGetCommentsByTitleWithUser(int id);
        List<Comment> TGetCommentsByUserWithTitle(int id);
        List<Comment> TGetCommentsWithCategory();


    }
}