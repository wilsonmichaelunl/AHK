using DataContracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Contracts.EngineContracts
{
    public interface IScriptEngine
    {
        MemoryStream BuildRunOnOpenPreset(RunOnOpenScriptConfigurationModel model);
        MemoryStream BuildRunOnOpenFavorite(RunOnOpenScriptConfigurationModel model);
        void ValidateRunOnOpenScriptConfigurationModel(RunOnOpenScriptConfigurationModel model);
        RunOnOpenScriptConfigurationModel BuildRunOnOpenScriptConfigurationModel(RunOnOpenScriptConfigurationModel model);
        MemoryStream GetConfiguartionScript();
    }
}
