﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AHKPresetCreator.Engines
{
    public class BuildScriptsEngine
    {
        public void BuildPresetScripts(int originalX, int originalY, int newX, int newY)
        {
            var adjustmentX = originalX - newX;
            var adjustmentY = newY - originalY;


            string[] lines =
            {
                "SetWorkingDir %A_ScriptDir%  ; Ensures a consistent starting directory.",
                "#NoEnv",
                "SendMode Input",
                "#SingleInstance force", 
                "#MaxHotkeysPerInterval 2000",
                "#WinActivateForce",
                "#IfWinActive ahk_exe Adobe Premiere Pro.exe",
                "preset(item)",
                "{",
                "keywait, %A_PriorHotKey%",
                "ifWinNotActive ahk_exe Adobe Premiere Pro.exe",
                "  goto theEnding",
                "coordmode, pixel, Window",
                "coordmode, mouse, Window",
                "coordmode, Caret, Client",
                "BlockInput, SendAndMouse",
                "BlockInput, MouseMove",
                "BlockInput, On",
                "SetKeyDelay, 0",
                "Sendinput, ^!+k",
                "sleep 10",
                "Sendinput, ^!+k",
                "sleep 10",
                "MouseGetPos, xposP, yposP",
                "sendinput, {mButton}",
                "sleep 10",
                "prFocus(\"effects\")",
                "sleep 10",
                "Sendinput, ^b",
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
                "       GOTO theEnding",
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
                "Send %item%",
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
                "theEnding:",
                "}",
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
                "!b::preset(\"Twirl In\")",
                "Esc::ExitApp"
        };

            System.IO.File.WriteAllLines(@"C:\Test.ahk", lines);
            return;
        }
    }
}
