using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetCommentsByTitle(int id)
        {
            var context = new Context();
            return context.Comments.Where(x=>x.TitleID== id).ToList();
        }

        public List<Comment> GetCommentsByTitleWithUser(int id)
        {
            var context = new Context();
            return context.Comments.Where(x=>x.TitleID== id).Include(y=>y.AppUser).Include(z=>z.Title.Category). ToList();
        }

        public List<Comment> GetCommentsByUserWithTitle(int id)
        {
            var context = new Context();
            return context.Comments.Where(x=>x.AppUserID==id & x.CommentStatus==true).Include(y=>y.Title).Include(x=>x.Category).ToList();
        }

        public List<Comment> GetCommentsWithCategory()
        {
            var context = new Context();
            return context.Comments.Include(x=>x.Category).ToList();
        }
    }
}
