SetWorkingDir %A_ScriptDir%  ; Ensures a consistent starting directory.

#NoEnv
SendMode Input  ; Recommended for new scripts due to its superior speed and reliability.
#SingleInstance force ;only one instance of this script may run at a time!
#MaxHotkeysPerInterval 2000
#WinActivateForce ;https://autohotkey.com/docs/commands/_WinActivateForce.htm

;;;;;;;;;;FUNCTION FOR DIRECTLY APPLYING A PRESET EFFECT TO A CLIP!;;;;;;;;;;;;
; preset() is my most used, and most useful AHK function! There is no good reason why Premiere doesn't have this functionality.
;keep in mind, I use 150% UI scaling, so your pixel distances for commands like mousemove WILL be different!
;to use this script yourself, carefully go through  testing the script and changing the values, ensuring that the script works, one line at a time. use message boxes to check on variables and see where the cursor is. remove those message boxes later when you have it all working!
;NOTE: you also need to get the PrFocus() function.
#IfWinActive ahk_exe Adobe Premiere Pro.exe

configure()
{
keywait, %A_PriorHotKey% ;this is probably WAY cleaner than allowing the physical key UP events to just happen WHENEVER during the following function. I'm gonna add this to a LOT of my functions... It'll be a bit slower, but also should have way fewer issues, making it worth it.

sendinput, {blind}{SC0EC} ;for debugging

ifWinNotActive ahk_exe Adobe Premiere Pro.exe
	goto theEnding ;and this line is here just in case the function is called while not inside premiere.

;Setting the coordinate mode is really important. This ensures that pixel distances are consistant for everything, everywhere.
coordmode, pixel, Window
coordmode, mouse, Window
coordmode, Caret, Client

;This (temporarily) blocks the mouse and keyboard from sending any information, which could interfere with the funcitoning of the script.
BlockInput, SendAndMouse
BlockInput, MouseMove
BlockInput, On

SetKeyDelay, 0 ;NO DELAY BETWEEN TYPED STUFF! It might actually be best to put this at "1" though.

;prFocus("timeline") ;maybe not essential i think...
Sendinput, k ;shuttle STOP
sleep 10
Sendinput, k ; another shortcut for Shuttle Stop.
;so if the video is playing, this will stop it. Othewise, it can mess up the script.
sleep 5

sendinput, {mButton} ;this will MIDDLE CLICK to bring focus to the panel underneath the cursor (the timeline). I forget exactly why, but if you create a nest, and immediately try to apply a preset to it, it doesn't work, because the timeline wasn't in focus...?
;but i just tried that and it still didn't work...
sleep 5
Send +{7}
sleep 15 ;"sleep" means the script will wait for 20 milliseconds before the next command. This is done to give Premiere some time to load its own things.
Sendinput, +f ;CTRL B ------------------------- set in premiere to "select find box"

Sendinput, twirl in 
sleep 5
MouseMove, %A_CaretX%, %A_CaretY%, 0
sleep 5
blockinput, MouseMoveOff ;returning mouse movement ability
BlockInput, off ;do not comment out or delete this line -- or you won't regain control of the keyboard!! However, CTRL+ALT+DEL will still work if you get stuck!! Cool.

MsgBox, Original Coordinates X: %A_CaretX%, Y: %A_CaretY% `nEnter these coordinates into the console window `nOnce these numbers are entered. Click on the icon next to Twirl In and click ALT+V

theEnding:
}

getCurrentPos()
{
keywait, %A_PriorHotKey% ;this is probably WAY cleaner than allowing the physical key UP events to just happen WHENEVER during the following function. I'm gonna add this to a LOT of my functions... It'll be a bit slower, but also should have way fewer issues, making it worth it.

ifWinNotActive ahk_exe Adobe Premiere Pro.exe
	goto theEnd ;and this line is here just in case the function is called while not inside premiere.

coordmode, pixel, Window
coordmode, mouse, Window
coordmode, Caret, Window

;This (temporarily) blocks the mouse and keyboard from sending any information, which could interfere with the funcitoning of the script.
BlockInput, SendAndMouse
BlockInput, MouseMove
BlockInput, On

MouseGetPos, X, Y

blockinput, MouseMoveOff ;returning mouse movement ability
BlockInput, off ;do not comment out or delete this line -- or you won't regain control of the keyboard!! However, CTRL+ALT+DEL will still work if you get stuck!! Cool.

MsgBox, New Coordinates X: %X%, Y: %Y% `nEnter these coordinates into the console window

ExitApp
theEnd:
}

!b::configure()
!v::getCurrentPos()

Esc::ExitApp