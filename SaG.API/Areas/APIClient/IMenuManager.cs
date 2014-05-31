using SaG.API.Areas.APIClient.Models;

namespace SaG.API.Areas.APIClient
{
    public interface IMenuManager
    {
        SiteMenu GetMenu(string path);

        MethodList GetMethodList(string path);
    }
}