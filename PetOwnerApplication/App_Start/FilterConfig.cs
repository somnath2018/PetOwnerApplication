using PetOwnerApplication.Filters;
using System.Web;
using System.Web.Mvc;

namespace PetOwnerApplication
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //Exception Filter
            filters.Add(new AppErrorHandler());
        }
    }
}
