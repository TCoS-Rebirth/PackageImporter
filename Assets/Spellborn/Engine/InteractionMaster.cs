using System;

namespace Engine
{
    [Serializable] public class InteractionMaster : Interactions
    {
        public InteractionMaster()
        {
        }
    }
}
/*
event NotifyLevelChange(array<Interaction> InteractionArray) {
local int Index;
Index = 0;                                                                  
while (Index < InteractionArray.Length) {                                   
InteractionArray[Index].NotifyLevelChange();                              
Index++;                                                                  
}
}
event ProcessMessage(coerce string Msg,float MsgLife,array<Interaction> InteractionArray) {
local int Index;
Index = 0;                                                                  
while (Index < InteractionArray.Length) {                                   
InteractionArray[Index].Message(Msg,MsgLife);                             
Index++;                                                                  
}
}
event ProcessTick(array<Interaction> InteractionArray,float DeltaTime) {
local int Index;
Index = 0;                                                                  
while (Index < InteractionArray.Length) {                                   
if (InteractionArray[Index].bRequiresTick
&& !InteractionArray[Index].bNativeEvents) {
InteractionArray[Index].Tick(DeltaTime);                                
}
Index++;                                                                  
}
}
event ProcessPostRender(array<Interaction> InteractionArray,Canvas Canvas) {
local int Index;
Index = InteractionArray.Length;                                            
while (Index > 0) {                                                         
if (InteractionArray[Index - 1].bVisible
&& !InteractionArray[Index - 1].bNativeEvents) {
InteractionArray[Index - 1].PostRender(Canvas);                         
}
Index--;                                                                  
}
}
event ProcessPreRender(array<Interaction> InteractionArray,Canvas Canvas) {
local int Index;
Index = InteractionArray.Length;                                            
while (Index > 0) {                                                         
if (InteractionArray[Index - 1].bVisible
&& !InteractionArray[Index - 1].bNativeEvents) {
InteractionArray[Index - 1].PreRender(Canvas);                          
}
Index--;                                                                  
}
}
event bool ProcessKeyEvent(array<Interaction> InteractionArray,out byte Key,out byte Action,float delta) {
local int Index;
Index = 0;                                                                  
while (Index < InteractionArray.Length) {                                   
if (InteractionArray[Index].bActive
&& !InteractionArray[Index].bNativeEvents
&& InteractionArray[Index].KeyEvent(Key,Action,delta)) {
return True;                                                            
}
Index++;                                                                  
}
return False;                                                               
}
event bool ProcessKeyType(array<Interaction> InteractionArray,out byte Key,optional string Unicode) {
local int Index;
Index = 0;                                                                  
while (Index < InteractionArray.Length) {                                   
if (InteractionArray[Index].bActive
&& !InteractionArray[Index].bNativeEvents
&& InteractionArray[Index].KeyType(Key,Unicode)) {
return True;                                                            
}
Index++;                                                                  
}
return False;                                                               
}
event SetFocusTo(Interaction Inter,optional Player ViewportOwner) {
local array<Interaction> InteractionArray;
local Interaction Temp;
local int i;
local int iIndex;
if (ViewportOwner != None) {                                                
InteractionArray = ViewportOwner.LocalInteractions;                       
} else {                                                                    
InteractionArray = GlobalInteractions;                                    
}
if (InteractionArray.Length == 0) {                                         
Log("Attempt to SetFocus on an empty Array.",'IMaster');                  
return;                                                                   
}
iIndex = -1;                                                                
i = 0;                                                                      
while (i < InteractionArray.Length) {                                       
if (InteractionArray[i] == Inter) {                                       
iIndex = i;                                                             
goto jl00B9;                                                            
}
i++;                                                                      
}
if (iIndex < 0) {                                                           
Log("Interaction " $ string(Inter) $ " is not in "
$ string(ViewportOwner)
$ ".",'IMaster');
return;                                                                   
} else {                                                                    
if (iIndex == 0) {                                                        
return;                                                                 
}
}
Temp = InteractionArray[iIndex];                                            
i = 0;                                                                      
while (i < iIndex) {                                                        
InteractionArray[i + 1] = InteractionArray[i];                            
i++;                                                                      
}
InteractionArray[0] = Temp;                                                 
InteractionArray[0].bActive = True;                                         
InteractionArray[0].bVisible = True;                                        
}
event RemoveInteraction(Interaction RemoveMe) {
local int Index;
if (RemoveMe.ViewportOwner != None) {                                       
Index = 0;                                                                
while (Index < RemoveMe.ViewportOwner.LocalInteractions.Length) {         
if (RemoveMe.ViewportOwner.LocalInteractions[Index] == RemoveMe) {      
RemoveMe.ViewportOwner.LocalInteractions.Remove(Index,1);             
return;                                                               
}
Index++;                                                                
}
} else {                                                                    
Index = 0;                                                                
while (Index < GlobalInteractions.Length) {                               
if (GlobalInteractions[Index] == RemoveMe) {                            
GlobalInteractions.Remove(Index,1);                                   
return;                                                               
}
Index++;                                                                
}
}
Log("Could not remove interaction [Sirenix.OdinInspector.FoldoutGroup("
$ string(RemoveMe)
$ "] (Not Found)",'IMaster');
}
event Interaction AddInteraction(string InteractionName,optional Player AttachTo) {
local Interaction NewInteraction;
local class<Interaction> NewInteractionClass;
NewInteractionClass = Class<Interaction>(static.DynamicLoadObject(InteractionName,Class'Class'));
if (NewInteractionClass != None) {                                          
NewInteraction = new NewInteractionClass;                                 
if (NewInteraction != None) {                                             
if (AttachTo != None) {                                                 
AttachTo.LocalInteractions.Length = AttachTo.LocalInteractions.Length + 1;
AttachTo.LocalInteractions[AttachTo.LocalInteractions.Length - 1] = NewInteraction;
NewInteraction.ViewportOwner = AttachTo;                              
} else {                                                                
GlobalInteractions.Length = GlobalInteractions.Length + 1;            
GlobalInteractions[GlobalInteractions.Length - 1] = NewInteraction;   
}
NewInteraction.Initialize();                                            
NewInteraction.Master = self;                                           
return NewInteraction;                                                  
} else {                                                                  
Log("Could not create interaction [Sirenix.OdinInspector.FoldoutGroup("
$ InteractionName
$ "]",'IMaster');
}
} else {                                                                    
Log("Could not load interaction [Sirenix.OdinInspector.FoldoutGroup(" $ InteractionName
$ "]",'IMaster');
}
return None;                                                                
}
native function Travel(string URL);
*/