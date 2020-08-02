using DataContracts;
using Microsoft.AspNetCore.Mvc;
using MVCWebApp.Shared.Contracts.EngineContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MVCWebApp.Engines
{
    public class ScriptEngine : IScriptEngine
    {
        public MemoryStream BuildRunOnOpenPreset(RunOnOpenScriptConfigurationModel model)
        {
            var adjustmentX = model.OriginalX - model.NewX;
            var adjustmentY = model.NewY - model.OriginalY;

            string[] lines =
            {
                "SetWorkingDir %A_ScriptDir%  ; Ensures a consistent starting directory.",
                "#NoEnv",
                "SendMode Input",
                "#SingleInstance force",
                "#MaxHotkeysPerInterval 2000",
                "#WinActivateForce",
                "#IfWinActive ahk_exe Adobe Premiere Pro.exe",
                "keywait, %A_PriorHotKey%",
                "ifWinNotActive ahk_exe Adobe Premiere Pro.exe",
                "  ExitApp",
                "coordmode, pixel, Window",
                "coordmode, mouse, Window",
                "coordmode, Caret, Client",
                "BlockInput, SendAndMouse",
                "BlockInput, MouseMove",
                "BlockInput, On",
                "SetKeyDelay, 0",
                "Sendinput, k",
                "sleep 10",
                "Sendinput, k",
                "sleep 10",
                "MouseGetPos, xposP, yposP",
                "sendinput, {mButton}",
                "sleep 10",
                "prFocus(\"effects\")",
                "sleep 10",
                "Sendinput, +f",
                "sleep 10",
                "if (A_CaretX = \"\")",
                "{",
                "waiting2 = 0",
                "loop",
                "   {",
                "   waiting2 ++",
                "   sleep 33",
                "   tooltip, counter = (%waiting2% * 33)`nCaret = %A_CaretX%",
                "    if (A_CaretX <> \"\")",
                "       {",
                "       tooltip, CARET WAS FOUND",
                "       break",
                "       }",
                "   if (waiting2 > 40)",
                "       {",
                "       tooltip, FAIL - no caret found. `nIf your cursor will not move`, hit the button to call the preset() function again.`nTo remove this tooltip`, refresh the script using its icon in the taskbar.`n`nIt's possible Premiere tried to AUTOSAVE at just the wrong moment!",
                "       sleep 200",
                "       ExitApp",
                "       }",
                "   }",
                "sleep 1",
                "tooltip",
                "}",
                "MouseMove, %A_CaretX%, %A_CaretY%, 0",
                "sleep 10",
                "MouseGetPos, , , Window, classNN",
                "WinGetClass, class, ahk_id %Window%",
                "ControlGetPos, XX, YY, Width, Height, %classNN%, ahk_class %class%, SubWindow, SubWindow",
                "sleep 10",
                $"Send {model.EffectName}",
                "sleep 10",
                $"MouseMove, {adjustmentX}, {adjustmentY}, 0, R",
                "sleep 10",
                "MouseGetPos, iconX, iconY, Window, classNN",
                "sleep 10",
                "WinGetClass, class, ahk_id %Window%",
                "sleep 10",
                "MouseMove, 0, 125, 1, R",
                "sleep 10",
                "MouseClick, left, , , 1",
                "sleep 10",
                "MouseMove, iconX, iconY, 0",
                "sleep 10",
                "MouseClickDrag, Left, , , %xposP%, %yposP%, 0",
                "sleep 10",
                "MouseClick, middle, , , 1",
                "blockinput, MouseMoveOff",
                "BlockInput, off",
                "ExitApp",
                "",
                "",
                "",
                "",
                "",
                "",
                "prFocus(panel)",
                "{",
                "Send +{7}",
                "sleep 10",
                "Send +{7}",
                "sleep 10",
                "}",
                "Esc::ExitApp"
            };

            using (MemoryStream stream = new MemoryStream())
            {
                StreamWriter objstreamwriter = new StreamWriter(stream);
                foreach (string line in lines)
                {
                    objstreamwriter.Write(line);
                    objstreamwriter.WriteLine();
                }
                objstreamwriter.Flush();
                objstreamwriter.Close();
                return stream;
            }
        }

        public MemoryStream BuildRunOnOpenFavorite(RunOnOpenScriptConfigurationModel model)
        {
            var adjustmentX = model.OriginalX - model.NewX;
            var adjustmentY = model.NewY - model.OriginalY;

            string[] lines =
            {
                "SetWorkingDir %A_ScriptDir%  ; Ensures a consistent starting directory.",
                "#NoEnv",
                "SendMode Input",
                "#SingleInstance force",
                "#MaxHotkeysPerInterval 2000",
                "#WinActivateForce",
                "#IfWinActive ahk_exe Adobe Premiere Pro.exe",
                "keywait, %A_PriorHotKey%",
                "ifWinNotActive ahk_exe Adobe Premiere Pro.exe",
                "  ExitApp",
                "coordmode, pixel, Window",
                "coordmode, mouse, Window",
                "coordmode, Caret, Client",
                "BlockInput, SendAndMouse",
                "BlockInput, MouseMove",
                "BlockInput, On",
                "SetKeyDelay, 0",
                "Sendinput, k",
                "sleep 10",
                "Sendinput, k",
                "sleep 10",
                "MouseGetPos, xposP, yposP",
                "sendinput, {mButton}",
                "sleep 10",
                "prFocus(\"effects\")",
                "sleep 10",
                "Sendinput, +f",
                "sleep 10",
                "if (A_CaretX = \"\")",
                "{",
                "waiting2 = 0",
                "loop",
                "   {",
                "   waiting2 ++",
                "   sleep 33",
                "   tooltip, counter = (%waiting2% * 33)`nCaret = %A_CaretX%",
                "    if (A_CaretX <> \"\")",
                "       {",
                "       tooltip, CARET WAS FOUND",
                "       break",
                "       }",
                "   if (waiting2 > 40)",
                "       {",
                "       tooltip, FAIL - no caret found. `nIf your cursor will not move`, hit the button to call the preset() function again.`nTo remove this tooltip`, refresh the script using its icon in the taskbar.`n`nIt's possible Premiere tried to AUTOSAVE at just the wrong moment!",
                "       sleep 200",
                "       ExitApp",
                "       }",
                "   }",
                "sleep 1",
                "tooltip",
                "}",
                "MouseMove, %A_CaretX%, %A_CaretY%, 0",
                "sleep 10",
                "MouseGetPos, , , Window, classNN",
                "WinGetClass, class, ahk_id %Window%",
                "ControlGetPos, XX, YY, Width, Height, %classNN%, ahk_class %class%, SubWindow, SubWindow",
                "sleep 10",
                $"Send {model.EffectName}",
                "sleep 10",
                $"MouseMove, {adjustmentX}, {adjustmentY}, 0, R",
                "sleep 10",
                "MouseGetPos, iconX, iconY, Window, classNN",
                "sleep 10",
                "WinGetClass, class, ahk_id %Window%",
                "sleep 10",
                "MouseMove, 0, 50, 0, R",
                "sleep 10",
                "MouseClick, left, , , 1",
                "sleep 10",
                "MouseMove, iconX, iconY, 0",
                "sleep 10",
                "MouseClickDrag, Left, , , %xposP%, %yposP%, 0",
                "sleep 10",
                "MouseClick, middle, , , 1",
                "blockinput, MouseMoveOff",
                "BlockInput, off",
                "ExitApp",
                "",
                "",
                "",
                "",
                "",
                "",
                "prFocus(panel)",
                "{",
                "Send +{7}",
                "sleep 10",
                "Send +{7}",
                "sleep 10",
                "}",
                "Esc::ExitApp"
            };

            using (MemoryStream stream = new MemoryStream())
            {
                StreamWriter objstreamwriter = new StreamWriter(stream);
                foreach (string line in lines)
                {
                    objstreamwriter.Write(line);
                    objstreamwriter.WriteLine();
                }
                objstreamwriter.Flush();
                objstreamwriter.Close();
                return stream;
            }
        }

        public void ValidateRunOnOpenScriptConfigurationModel(RunOnOpenScriptConfigurationModel model)
        {
            if (Regex.Replace(model.EffectName, @"[^0-9a-zA-Z]+", string.Empty).Length <= 0)
            {
                throw new ValidationException("Effect name is required");
            }

            if (Regex.Replace(model.FileName, @"[^0-9a-zA-Z]+", string.Empty).Length <= 0)
            {
                throw new ValidationException("File name is required");
            }
        }

        public RunOnOpenScriptConfigurationModel BuildRunOnOpenScriptConfigurationModel(RunOnOpenScriptConfigurationModel model)
        {
            model.EffectName = Regex.Replace(model.FileName, @"[^0-9a-zA-Z]+", string.Empty);
            model.FileName = Regex.Replace(model.FileName, @"[^0-9a-zA-Z]+", string.Empty);

            return model;
        }
    }
}
