using DataContracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Shared.Contracts.EngineContracts
{
    public interface IScriptEngine
    {
        MemoryStream BuildRunOnOpenPreset(RunOnOpenScriptConfigurationModel model);
        MemoryStream BuildRunOnOpenFavorite(RunOnOpenScriptConfigurationModel model);
        void ValidateRunOnOpenScriptConfigurationModel(RunOnOpenScriptConfigurationModel model);
        RunOnOpenScriptConfigurationModel BuildRunOnOpenScriptConfigurationModel(RunOnOpenScriptConfigurationModel model);
    }
}
