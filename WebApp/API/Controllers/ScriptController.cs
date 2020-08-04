using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.ManagerContracts;
using DataContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScriptController : ControllerBase
    {
        private readonly ILogger<ScriptController> _logger;
        private IScriptManager _scriptManager;

        public ScriptController(ILogger<ScriptController> logger, IScriptManager scriptManager)
        {
            _logger = logger;
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

        [HttpGet]
        public ActionResult<List<RunOnOpenScriptConfigurationModel>> Test()
        {
            var result = new List<RunOnOpenScriptConfigurationModel>();
            var thing = new RunOnOpenScriptConfigurationModel();
            thing.EffectName = "Carl Warl";

            result.Add(thing);
    

            return Ok(result);
        }
    }
}