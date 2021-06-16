using System.Threading.Tasks;
using GHPRS.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace GHPRS.Core.Interfaces
{
    public interface IMetabaseService
    {
        Task<string> GetSessionToken();
        Task<IActionResult> CreateUser(MetabaseUser user);
        Task<IActionResult> GetCurrentUser();
    }
}