using DCS.Infra.Data.Context.Interfaces;
using System.Web;

namespace DCS.Infra.Data.Context
{
    public class ContextManager : IContextManager
    {
        private const string ContextKey = "ContextManager.Context";

        public DCSContext GetContext()
        {
            if (HttpContext.Current.Items[ContextKey] == null)
            {
                HttpContext.Current.Items[ContextKey] = new DCSContext();
            }

            return (DCSContext)HttpContext.Current.Items[ContextKey];
        }
    }
}
