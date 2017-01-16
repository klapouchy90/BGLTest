using System.Net;
using System.Web.Mvc;
using BGL.KSzlachetka.Models;
using System.Web;
using BGL.KSzlachetka.Utils;
using System.Threading.Tasks;
using System.Linq;

namespace BGL.KSzlachetka.Controllers
{
    [AllowAnonymous]
    public class GitHubUserController : Controller
    {
        protected IGitHubDataProvider Provider { get; }

        public GitHubUserController(IGitHubDataProvider provider)
        {
            Provider = provider;
        }

        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(SearchViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            return RedirectToAction("Display", new { userName = viewModel.UserName });
        }

        [HttpGet]
        public async Task<ActionResult> Display(string userName)
        {
            if(string.IsNullOrEmpty(userName))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "User name is required");
            }
            try
            {
                var user = await Provider.GetUserByName(userName);
                user.Repos = user.Repos.OrderByDescending(r => r.StargazersCount).Take(5).ToArray();
                return View(user);
            }
            catch(HttpException ex)
            {
                return new HttpStatusCodeResult(ex.ErrorCode, ex.Message);
            }
        }
    }
}