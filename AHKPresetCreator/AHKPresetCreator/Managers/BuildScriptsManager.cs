using AHKPresetCreator.Engines;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AHKPresetCreator.Managers
{
    public class BuildScriptsManager
    {
        public void BuildPresetScripts(int originalX, int originalY, int newX, int newY)
        {
            var engine = new BuildScriptsEngine();
            engine.BuildPresetScripts(originalX, originalY, newX, newY);

            return;
        }
    }
}
