using System;

namespace Engine
{
    [Serializable] public class Interaction : Interactions
    {
        public Interaction()
        {
        }
    }
}
/*
event NotifyMusicChange();
function StreamFinished(int Handle,byte Reason);
function Tick(float DeltaTime);
function SetFocus() {
Master.SetFocusTo(self,ViewportOwner);                                      
}
function PostRender(Canvas Canvas);
function PreRender(Canvas Canvas);
function bool KeyEvent(out byte Key,out byte Action,float delta) {
return False;                                                               
}
function bool KeyType(out byte Key,optional string Unicode) {
return False;                                                               
}
function Message(coerce string Msg,float MsgLife) {
}
event NotifyLevelChange();
event Initialized();
native function Vector ScreenToWorld(Vector Location,optional Vector CameraLocation,optional Rotator CameraRotation);
native function Vector WorldToScreen(Vector Location,optional Vector CameraLocation,optional Rotator CameraRotation);
native function bool ConsoleCommand(coerce string s);
native function Initialize();
*/