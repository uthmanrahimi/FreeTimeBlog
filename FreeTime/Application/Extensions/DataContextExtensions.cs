using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace FreeTime.Web.Application.Extensions
{
    public static class DataContextExtensions
    {
        public static int TotalCount<T>(this DbSet<T> dbSet, Expression<Func<T, bool>> expression) where T : class
        {
            return dbSet.Where(expression).Count();
        }
    }
}
