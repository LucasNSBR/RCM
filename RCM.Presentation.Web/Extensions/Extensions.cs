using RCM.Presentation.Web.ViewModels;
using System.Collections.Generic;

namespace RCM.Presentation.Web.Extensions
{
    public static class Extensions
    {
        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> list, int pageNumber = 1, int pageSize = 20)
        {
            return new PagedList<T>(list, pageNumber, pageSize);
        }
    }
}
