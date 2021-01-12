using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FreeTime.Application.Common.ExtensionMethods
{
    public static class DataContextExtensions
    {
        public static int TotalCount<T>(this DbSet<T> dbSet, Expression<Func<T, bool>> expression) where T : class
        {
            return dbSet.Where(expression).Count();
        }
        public static async Task<int> TotalCountAsync<T>(this DbSet<T> dbSet, Expression<Func<T, bool>> expression) where T : class
        {
            return await dbSet.CountAsync(expression);
        }
    }
}
