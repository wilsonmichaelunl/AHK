using Contracts.EngineContracts;
using Contracts.ManagerContracts;
using DataContracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Managers
{
    public class ScriptManager : IScriptManager
    {
        private IScriptEngine _scriptEngine { get; }

        public ScriptManager(IScriptEngine scriptEngine)
        {
            _scriptEngine = scriptEngine;
        }

        public MemoryStream BuildRunOnOpenPreset(RunOnOpenScriptConfigurationModel model)
        {
            _scriptEngine.ValidateRunOnOpenScriptConfigurationModel(model);
            model = _scriptEngine.BuildRunOnOpenScriptConfigurationModel(model);
            var file = _scriptEngine.BuildRunOnOpenPreset(model);

            return file;
        }

        public MemoryStream BuildRunOnOpenFavorite(RunOnOpenScriptConfigurationModel model)
        {
            _scriptEngine.ValidateRunOnOpenScriptConfigurationModel(model);
            model = _scriptEngine.BuildRunOnOpenScriptConfigurationModel(model);
            var file = _scriptEngine.BuildRunOnOpenFavorite(model);

            return file;
        }
    }
}
