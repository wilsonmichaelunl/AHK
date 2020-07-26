SetWorkingDir %A_ScriptDir%  ; Ensures a consistent starting directory.

#NoEnv
Menu, Tray, Icon, shell32.dll, 283 ; this changes the tray icon to a little keyboard!
; #Warn  ; Enable warnings to assist with detecting common errors.
SendMode Input  ; Recommended for new scripts due to its superior speed and reliability.
#SingleInstance force ;only one instance of this script may run at a time!
#MaxHotkeysPerInterval 2000
#WinActivateForce ;https://autohotkey.com/docs/commands/_WinActivateForce.htm
CoordMode, Mouse, Screen


preset(item)
{
BlockInput, SendAndMouse
BlockInput, On
SetKeyDelay, 0
MouseGetPos, xpos, ypos
ControlGetPos, X, Y, Width, Height, Edit2, ahk_class Premiere Pro
MouseMove, X, Y, 0
sleep 10
MouseClick, left, , , 1
sleep 10
Send ^{a} {backspace}
sleep 10
Send %item%
sleep 10
MouseMove, 70, 65, 0, R
MouseClickDrag, Left, , , %xpos%, %ypos%, 0
BlockInput, off 
}

!b::preset("Twirl in")

Esc::ExitApp
