using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public static class ControllerExtensions
{
    public static IActionResult RedirectBack(this Controller controller)
    {
        return controller.RedirectBack("");
    }

    public static IActionResult RedirectBack(this Controller controller, string urlEnd)
    {
        var referer = controller.Request.Headers.Referer.ToString();
        if (string.IsNullOrEmpty(referer))
            referer = "/Index";
        else
            referer += urlEnd;

        return controller.Redirect(referer);
    }
}
