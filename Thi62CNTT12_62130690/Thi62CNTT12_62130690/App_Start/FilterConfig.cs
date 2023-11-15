using System.Web;
using System.Web.Mvc;

namespace Thi62CNTT12_62130690
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
