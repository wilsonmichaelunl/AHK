using DataContracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Shared.Contracts.ManagerContracts
{
    public interface IScriptManager
    {
        MemoryStream BuildRunOnOpenPreset(RunOnOpenScriptConfigurationModel model);
        MemoryStream BuildRunOnOpenFavorite(RunOnOpenScriptConfigurationModel model);
    }
}
