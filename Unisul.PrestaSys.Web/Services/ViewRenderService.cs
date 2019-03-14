using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;

namespace Unisul.PrestaSys.Web.Services
{
    public interface IViewRenderService
    {
        Task<string> RenderToStringAsync(string viewName, object model);
    }

    public class ViewRenderService : IViewRenderService
    {
        private readonly IRazorViewEngine _razorViewEngine;
        private readonly IServiceProvider _serviceProvider;
        private readonly ITempDataProvider _tempDataProvider;

        public ViewRenderService(
            IRazorViewEngine razorViewEngine,
            ITempDataProvider tempDataProvider,
            IServiceProvider serviceProvider)
        {
            _razorViewEngine = razorViewEngine;
            _tempDataProvider = tempDataProvider;
            _serviceProvider = serviceProvider;
        }

        public Task<string> RenderToStringAsync(string viewName, object model)
        {
            var httpContext = new DefaultHttpContext {RequestServices = _serviceProvider};
            var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

            var viewResult = _razorViewEngine.GetView(null, viewName, false);

            if (viewResult.View == null)
                throw new ArgumentNullException($"{viewName} não corresponde a nenhuma view existente");

            return RenderToStringAsync(actionContext, viewResult, model);
        }

        private async Task<string> RenderToStringAsync(ActionContext actionContext, ViewEngineResult viewResult,
            object model)
        {
            using (var sw = new StringWriter())
            {
                var viewDictionary =
                    new ViewDataDictionary(
                            new EmptyModelMetadataProvider(),
                            new ModelStateDictionary())
                        {Model = model};

                var viewContext = new ViewContext(
                    actionContext,
                    viewResult.View,
                    viewDictionary,
                    new TempDataDictionary(actionContext.HttpContext, _tempDataProvider),
                    sw,
                    new HtmlHelperOptions());

                await viewResult.View.RenderAsync(viewContext);
                return sw.ToString();
            }
        }
    }
}
