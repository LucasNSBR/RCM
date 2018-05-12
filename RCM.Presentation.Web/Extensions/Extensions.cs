using Microsoft.AspNetCore.Mvc;
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

        public static string GetControllerName(this IUrlHelper url)
        {
            return url.ActionContext.RouteData.Values["controller"].ToString().ToLower();
        }

        /// <summary>
        /// Load properties from Index PagedList<T> to a Dictionary that will be used in the Pagination sidebar.
        /// </summary>
        /// <param name="dict">The target dictionary to load properties</param>
        /// <param name="list">The list of properties to be loaded</param>
        /// <returns></returns>
        public static Dictionary<string, string> LoadPagination<T>(this Dictionary<string, string> dict, PagedList<T> list)
        {
            foreach (var property in list.GetType().GetProperties())
            {
                var name = property.Name;
                if (name == "List")
                {
                    continue;
                }

                var value = property.GetValue(list);
                dict.Add(name, value.ToString());
            };

            return dict;
        }
    }
}
