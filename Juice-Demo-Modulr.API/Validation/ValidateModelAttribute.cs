using System;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace API.Validation
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Occurs before the action method is invoked.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        /// <exception cref="CommonValidationException"></exception>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid && actionContext.Request.Method.Method != "GET")
            {
                var errorMessages = string.Join(" ", actionContext.ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)));

                throw new ApplicationException(errorMessages);
            }

            base.OnActionExecuting(actionContext);
        }
    }
}