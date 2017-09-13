using Concesionarios.DAL.Repository.Common;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Concesionarios.WebApi.Helpers
{
    //TODO: QUITAR SI NO SE USA UnitOfWorkActionFilter
    public class UnitOfWorkActionFilter : ActionFilterAttribute
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            UnitOfWork = actionContext.Request.GetDependencyScope().GetService(typeof(IUnitOfWork)) as IUnitOfWork;
            //UnitOfWork.BeginTransaction();
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            UnitOfWork = actionExecutedContext.Request.GetDependencyScope().GetService(typeof(IUnitOfWork)) as IUnitOfWork;
            if (actionExecutedContext.Exception == null)
            {
                // commit if no exceptions
                UnitOfWork.Commit();
            }
            //else
            //{
            //    // rollback if exception
            //    UnitOfWork.Rollback();
            //}
        }
    }
}