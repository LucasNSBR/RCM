using Microsoft.AspNetCore.Mvc;
using RCM.Presentation.Web.ViewModels;
using System.Collections.Generic;

namespace RCM.Presentation.Web.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// Turn a IEnumerable<T> into a Paged IEnumerable<T>
        /// </summary>
        /// <typeparam name="T">Generic T</typeparam>
        /// <param name="list">List to convert</param>
        /// <param name="pageNumber">Number of the current page</param>
        /// <param name="pageSize">Number of pages before do a Take()</param>
        /// <returns></returns>
        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> list, int pageNumber = 1, int pageSize = 20)
        {
            return new PagedList<T>(list, pageNumber, pageSize);
        }

        /// <summary>
        /// Used in Views to get current Controller name
        /// </summary>
        /// <param name="url">Current URL</param>
        /// <returns></returns>
        public static string GetControllerName(this IUrlHelper url)
        {
            return url.ActionContext.RouteData.Values["controller"].ToString().ToLower();
        }

        /// <summary>
        /// Load properties from Index PagedList<T> to a Dictionary that will be used in the Pagination sidebar
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
