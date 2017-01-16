using BGL.KSzlachetka.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace BGL.KSzlachetka.Utils
{
    public class GitHubDataProvider : RestService, IGitHubDataProvider
    {
        public GitHubDataProvider() : base("https://api.github.com/")
        {
        }

        public GitHubDataProvider(string baseUrl) : base(baseUrl)
        {
        }

        public GitHubDataProvider(Uri baseUrl) : base(baseUrl)
        {
        }

        /// <summary>
        /// Gets a GitHub user
        /// </summary>
        /// <param name="userName">Requested user name</param>
        /// <returns>GitHub user with a collection of repositories</returns>
        /// <exception cref="ArgumentNullException">Thrown when requested userName is null</exception>
        /// <exception cref="HttpException">Thrown when fetching data from GitHub was unsuccessful</exception>
        public async Task<GitHubUser> GetUserByName(string userName)
        {
            if (userName == null)
            {
                throw new ArgumentNullException(nameof(userName));
            }
            var user = await GetObjectFromJsonRequest<GitHubUser>($"/users/{HttpUtility.UrlEncode(userName)}");
            user.Repos = await GetObjectFromJsonRequest<GitHubRepo[]>(user.ReposUrl);
            return user;
        }
    }
}