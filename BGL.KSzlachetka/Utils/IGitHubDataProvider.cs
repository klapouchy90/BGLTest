using BGL.KSzlachetka.Models;
using System.Threading.Tasks;

namespace BGL.KSzlachetka.Utils
{
    public interface IGitHubDataProvider
    {
        Task<GitHubUser> GetUserByName(string userName);
    }
}