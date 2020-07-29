using AHKPresetCreator.Engines;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AHKPresetCreator.Managers
{
    public class BuildScriptsManager
    {
        BuildScriptsEngine engine = new BuildScriptsEngine();

        public void BuildPresetScript(int originalX, int originalY, int newX, int newY)
        {
            engine.BuildPresetScript(originalX, originalY, newX, newY);

            return;
        }

        public void BuildFavoriteScript(int originalX, int originalY, int newX, int newY)
        {
            engine.BuildFavoriteScript(originalX, originalY, newX, newY);

            return;
        }

        public void BuildStreamDeckPresetScript(int originalX, int originalY, int newX, int newY, string effect)
        {
            engine.BuildStreamDeckPresetScript(originalX, originalY, newX, newY, effect);

            return;
        }

        public void BuildStreamDeckFavoriteScript(int originalX, int originalY, int newX, int newY, string effect)
        {
            engine.BuildStreamDeckFavoriteScript(originalX, originalY, newX, newY, effect);

            return;
        }
    }
}
