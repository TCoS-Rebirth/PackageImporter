﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Collections.Generic;
using TCosReborn.Framework.Common;


namespace Engine
{


    public class Player : SBPackageResource
    {
        
        public const int IDC_WAIT = 6;
        
        public const int IDC_SIZEWE = 5;
        
        public const int IDC_SIZENWSE = 4;
        
        public const int IDC_SIZENS = 3;
        
        public const int IDC_SIZENESW = 2;
        
        public const int IDC_SIZEALL = 1;
        
        public const int IDC_ARROW = 0;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public int vfOut;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public int vfExec;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public PlayerController Actor;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public PlayerController OldActor;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public Console Console;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public bool bWindowsMouseAvailable;
        
        public bool bShowWindowsMouse;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public float WindowsMouseX;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public float WindowsMouseY;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public int CurrentVoiceBandwidth;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public int CurrentNetSpeed;
        
        public int ConfiguredInternetSpeed;
        
        public int ConfiguredLanSpeed;
        
        public byte SelectedCursor;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public InteractionMaster InteractionMaster;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public List<Interaction> LocalInteractions = new List<Interaction>();
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public BaseGUIController GUIController;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public GUI_BaseDesktop GUIDesktop;
        
        public Player()
        {
        }
    }
}
