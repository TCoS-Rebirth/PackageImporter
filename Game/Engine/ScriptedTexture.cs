﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------



namespace Engine
{


    public class ScriptedTexture : BitmapMaterial
    {
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public int RenderTarget;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public Viewport RenderViewport;
        
        public Actor Client;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public int Revision;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public int OldRevision;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public int Invalid;
        
        public ScriptedTexture()
        {
        }
    }
}
/*
final native function DrawPortal(int X,int Y,int width,int Height,Actor CamActor,Vector CamLocation,Rotator CamRotation,optional int FOV,optional bool ClearZ);
final native function DrawTile(float X,float Y,float XL,float YL,float U,float V,float UL,float VL,Material Material,Color Color);
final native function TextSize(coerce string Text,Font Font,out int width,out int Height);
final native function DrawText(int StartX,int StartY,coerce string Text,Font Font,Color Color);
final native function SetSize(int width,int Height);
*/