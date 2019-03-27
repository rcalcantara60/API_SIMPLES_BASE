using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using TCLegisAPI.Extensions;
using TCLegisAPI.Models;

namespace TCLegisAPI.Controllers.Base
{
    public class BaseController : Controller
    {        
        protected PaginationHeader RequestPagination { get; set; }
        protected PaginationHeader ResponsePagination { get; set; }

        public BaseController(ILogger<BaseController> logger)
        {
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var paginationVlr = Request.Headers["pagination"];
            

            if (!string.IsNullOrEmpty(paginationVlr))
            {
                // PaginationHeader newEmployee = JsonConvert.DeserializeObject<PaginationHeader>(paginationVlr, new KeysJsonConverter(typeof(PaginationHeader)));
                RequestPagination = JsonConvert.DeserializeObject<PaginationHeader>(paginationVlr, new JsonSerializerSettings
                {        
                    MissingMemberHandling = MissingMemberHandling.Error
                });                
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Response.AddPagination(ResponsePagination);
        }
    }


 

}
