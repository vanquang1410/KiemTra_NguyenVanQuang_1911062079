using System.Web;
using System.Web.Mvc;

namespace KiemTra_NguyenVanQuang_1911062079
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
