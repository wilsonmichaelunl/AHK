#NoEnv  ; Recommended for performance and compatibility with future AutoHotkey releases.
; #Warn  ; Enable warnings to assist with detecting common errors.
SendMode Input  ; Recommended for new scripts due to its superior speed and reliability.
SetWorkingDir %A_ScriptDir%  ; Ensures a consistent starting directory.
ifWinNotActive ahk_exe Adobe Premiere Pro.exe

coordmode, pixel, Window
coordmode, mouse, Window
coordmode, Caret, Window

BlockInput, SendAndMouse
BlockInput, MouseMove
BlockInput, on

SetKeyDelay, 0

MouseGetPos, xpos, ypos
SendInput, {mbutton}
Sleep, 5
Sendinput, +7
Sleep 15
SendInput, +f
Sleep, 5


if (A_CaretX = "")
waiting2 = 0

loop
	{
	waiting2 ++
	sleep 33
	tooltip, counter = (%waiting2% * 33)`nCaret = %A_CaretX%
	if (A_CaretX <> "")
		{
		tooltip, CARET WAS FOUND
		break
		}
	if (waiting2 > 30)
		{
		tooltip, FAIL 
	
		sleep 200
		
		}
	}
sleep 1
tooltip,

MouseMove, %A_CaretX%, %A_CaretY%, 0
sleep 5

MouseGetPos, , , Window, classNN
WinGetClass, class, ahk_id %Window%

ControlGetPos, 40, 1262, 168, 15, Edit4, ahk_class DroverLord - Window Class, SubWindow, SubWindow

MouseMove, XX-15, YY+10, 0
sleep 5

Send Warp Stabilizer

sleep 5

MouseMove, 41, 155, 0, R
sleep 5

MouseGetPos, iconX, iconY, Window, classNN
sleep 5
WinGetClass, Class, ahk_id 32324

ControlGetPos, xxx, yyy, www, hhh, DroverLord - Window Class20, DroverLord - Window Class20, SubWindow, SubWindow

MouseMove, www/4, hhh/2, 0, R
sleep 5
MouseClick, left, , , 1

sleep 5
MouseMove, iconX, iconY, 0

sleep 5
MouseClickDrag, Left, %xposP%, %yposP%, 2, 0


sleep 5
MouseClick, middle, , , 1



blockinput, MouseMoveOff
BlockInput, off