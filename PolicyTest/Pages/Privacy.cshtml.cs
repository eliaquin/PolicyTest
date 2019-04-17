using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PolicyTest.Pages
{
    [Authorize(Policy = "AdultsOnly")]
    public class PrivacyModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}