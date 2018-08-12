using System;

namespace Engine
{
    [Serializable] public class Info : Actor
    {
        public Info()
        {
        }
    }
}
/*
static event string GetDescriptionText(string PropName) {
return "";                                                                  
}
static event byte GetSecurityLevel(string PropName) {
return 0;                                                                   
}
static event bool AllowClassRemoval() {
return True;                                                                
}
static event bool AcceptPlayInfoProperty(string PropertyName) {
return True;                                                                
}
static function FillPlayInfo(PlayInfo PlayInfo) {
PlayInfo.AddClass(default.Class);                                           
}
*/