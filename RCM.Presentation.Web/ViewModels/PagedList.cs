using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RCM.Presentation.Web.ViewModels
{
    public class PagedList<T> 
    {
        private IEnumerable<T> _list;
        public IEnumerable<T> List
        {
            get
            {
                return _list.Skip((PageNumber - 1) * PageSize).Take(PageSize);
            }
        }

        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((double)_list.Count() / PageSize);
            }
        }

        public bool IsLastPage
        {
            get
            {
                return PageNumber == TotalPages;
            }
        }

        public bool IsFirstPage
        {
            get
            {
                return PageNumber == 1;
            } 
        }

        public PagedList(IEnumerable<T> list, int pageNumber, int pageSize)
        {
            _list = list;
            PageNumber = pageNumber;
            PageSize = pageSize;

            if (PageNumber > TotalPages)
                PageNumber = TotalPages;
        }
    }
}
