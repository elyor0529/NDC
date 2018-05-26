
namespace NDC.UI
{
    using System.Web.Mvc;

    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //error filter
            filters.Add(new HandleErrorAttribute());
        }
    }
}
