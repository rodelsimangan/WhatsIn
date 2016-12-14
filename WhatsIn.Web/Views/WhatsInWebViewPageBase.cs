using Abp.Web.Mvc.Views;

namespace WhatsIn.Web.Views
{
    public abstract class WhatsInWebViewPageBase : WhatsInWebViewPageBase<dynamic>
    {

    }

    public abstract class WhatsInWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected WhatsInWebViewPageBase()
        {
            LocalizationSourceName = WhatsInConsts.LocalizationSourceName;
        }
    }
}