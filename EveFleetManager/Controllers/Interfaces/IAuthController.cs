using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveFleetManager.Controllers.Interfaces
{
    public interface IAuthController
    {
        IActionResult Login();
        Task<IActionResult> Callback(string code);
        Task<IActionResult> Refresh(string refreshToken);
    }
}
