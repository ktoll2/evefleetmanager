using ESI.NET.Models.SSO;
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
        IActionResult Callback(string code);
        IActionResult Refresh(string refreshToken);
    }
}
