﻿using System.Web;
using System.Web.Mvc;

namespace LabBigSchool_NguyenHuuLuan
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
