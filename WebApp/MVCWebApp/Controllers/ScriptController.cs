using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataContracts;
using Microsoft.AspNetCore.Mvc;
using MVCWebApp.Shared.Contracts.ManagerContracts;

namespace MVCWebApp.Controllers
{
    public class ScriptController : Controller
    {
        private IScriptManager _scriptManager;

        public ScriptController(IScriptManager scriptManager)
        {
            _scriptManager = scriptManager;
        }

        public FileContentResult CreateRunOnOpenPresetScript(RunOnOpenScriptConfigurationModel model)
        {
            var file = _scriptManager.BuildRunOnOpenPreset(model);

            return File(file.ToArray(), "text/plain", $"{model.FileName}.ahk");
        }

        public FileContentResult CreateRunOnOpenFavoriteScript(RunOnOpenScriptConfigurationModel model)
        {
            var file = _scriptManager.BuildRunOnOpenFavorite(model);

            return File(file.ToArray(), "text/plain", $"{model.FileName}.ahk");
        }
    }
}