using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataContracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ScriptController : Controller
    {
        public IActionResult CreatePresetScript(PresetScriptConfigurationModel model)
        {
            return View();
        }
    }
}