using System.Web;
using System.Web.Mvc;

namespace LeNguyenThaiKhang_5951071043
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
