using Microsoft.AspNetCore.Http;
using TCLegisAPI.Models;

namespace TCLegisAPI.Extensions
{
    public static class ExtensionsMethods
    {
        public static void AddPagination(this HttpResponse response, PaginationHeader paginationHeader)
        {
            //var paginationHeader = new PaginationHeader(page, pageSize, totalItems, totalPages, order, sortOrder);

            response.Headers.Add("pagination",
                Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeader));
            // CORS
            response.Headers.Add("access-control-expose-headers", "Pagination");
        }

        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            // CORS
            response.Headers.Add("access-control-expose-headers", "Application-Error");
        }
    }
}
