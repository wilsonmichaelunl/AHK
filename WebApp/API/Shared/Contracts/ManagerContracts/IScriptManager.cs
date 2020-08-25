using DataContracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Contracts.ManagerContracts
{
    public interface IScriptManager
    {
        MemoryStream BuildRunOnOpenPreset(RunOnOpenScriptConfigurationModel model);
        MemoryStream BuildRunOnOpenFavorite(RunOnOpenScriptConfigurationModel model);
    }
}
