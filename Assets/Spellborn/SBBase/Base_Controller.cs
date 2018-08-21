using System;
using Engine;
using UnityEngine;

namespace SBBase
{
    public abstract class Base_Controller : PlayerController
    {
        [NonSerialized, HideInInspector]
        public int AccountID;

        [NonSerialized, HideInInspector]
        public int CharacterID;

        [FieldConst()]
        [NonSerialized, HideInInspector]
        public bool ControllerInitialized;

        [TypeProxyDefinition(TypeName = "Base_Pawn")]
        public Type mPawnClass;

        public enum EGroupIDs
        {
            EGroupIDs_RESERVED_0 = 0,

            GID_CLIENT = 1,

            GID_RELEVANT = 2,

            EGroupIDs_RESERVED_3 = 3,

            GID_SCENERY = 4,

            EGroupIDs_RESERVED_5 = 5,

            EGroupIDs_RESERVED_6 = 6,

            EGroupIDs_RESERVED_7 = 7,

            GID_TEAM = 8,

            EGroupIDs_RESERVED_9 = 9,

            EGroupIDs_RESERVED_10 = 10,

            EGroupIDs_RESERVED_11 = 11,

            EGroupIDs_RESERVED_12 = 12,

            EGroupIDs_RESERVED_13 = 13,

            EGroupIDs_RESERVED_14 = 14,

            EGroupIDs_RESERVED_15 = 15,

            GID_FRIENDS = 16,

            EGroupIDs_RESERVED_17 = 17,

            EGroupIDs_RESERVED_18 = 18,

            EGroupIDs_RESERVED_19 = 19,

            EGroupIDs_RESERVED_20 = 20,

            EGroupIDs_RESERVED_21 = 21,

            EGroupIDs_RESERVED_22 = 22,

            EGroupIDs_RESERVED_23 = 23,

            EGroupIDs_RESERVED_24 = 24,

            EGroupIDs_RESERVED_25 = 25,

            EGroupIDs_RESERVED_26 = 26,

            EGroupIDs_RESERVED_27 = 27,

            EGroupIDs_RESERVED_28 = 28,

            EGroupIDs_RESERVED_29 = 29,

            EGroupIDs_RESERVED_30 = 30,

            EGroupIDs_RESERVED_31 = 31,

            GID_GUILD = 32,

            EGroupIDs_RESERVED_33 = 33,

            EGroupIDs_RESERVED_34 = 34,

            EGroupIDs_RESERVED_35 = 35,

            EGroupIDs_RESERVED_36 = 36,

            EGroupIDs_RESERVED_37 = 37,

            EGroupIDs_RESERVED_38 = 38,

            EGroupIDs_RESERVED_39 = 39,

            EGroupIDs_RESERVED_40 = 40,

            EGroupIDs_RESERVED_41 = 41,

            EGroupIDs_RESERVED_42 = 42,

            EGroupIDs_RESERVED_43 = 43,

            EGroupIDs_RESERVED_44 = 44,

            EGroupIDs_RESERVED_45 = 45,

            EGroupIDs_RESERVED_46 = 46,

            EGroupIDs_RESERVED_47 = 47,

            EGroupIDs_RESERVED_48 = 48,

            EGroupIDs_RESERVED_49 = 49,

            EGroupIDs_RESERVED_50 = 50,

            EGroupIDs_RESERVED_51 = 51,

            EGroupIDs_RESERVED_52 = 52,

            EGroupIDs_RESERVED_53 = 53,

            EGroupIDs_RESERVED_54 = 54,

            EGroupIDs_RESERVED_55 = 55,

            EGroupIDs_RESERVED_56 = 56,

            EGroupIDs_RESERVED_57 = 57,

            EGroupIDs_RESERVED_58 = 58,

            EGroupIDs_RESERVED_59 = 59,

            EGroupIDs_RESERVED_60 = 60,

            EGroupIDs_RESERVED_61 = 61,

            EGroupIDs_RESERVED_62 = 62,

            EGroupIDs_RESERVED_63 = 63,

            GID_QUERY = 64,

            EGroupIDs_RESERVED_65 = 65,

            EGroupIDs_RESERVED_66 = 66,

            EGroupIDs_RESERVED_67 = 67,

            EGroupIDs_RESERVED_68 = 68,

            EGroupIDs_RESERVED_69 = 69,

            EGroupIDs_RESERVED_70 = 70,

            EGroupIDs_RESERVED_71 = 71,

            EGroupIDs_RESERVED_72 = 72,

            EGroupIDs_RESERVED_73 = 73,

            EGroupIDs_RESERVED_74 = 74,

            EGroupIDs_RESERVED_75 = 75,

            EGroupIDs_RESERVED_76 = 76,

            EGroupIDs_RESERVED_77 = 77,

            EGroupIDs_RESERVED_78 = 78,

            EGroupIDs_RESERVED_79 = 79,

            EGroupIDs_RESERVED_80 = 80,

            EGroupIDs_RESERVED_81 = 81,

            EGroupIDs_RESERVED_82 = 82,

            EGroupIDs_RESERVED_83 = 83,

            EGroupIDs_RESERVED_84 = 84,

            EGroupIDs_RESERVED_85 = 85,

            EGroupIDs_RESERVED_86 = 86,

            EGroupIDs_RESERVED_87 = 87,

            EGroupIDs_RESERVED_88 = 88,

            EGroupIDs_RESERVED_89 = 89,

            EGroupIDs_RESERVED_90 = 90,

            EGroupIDs_RESERVED_91 = 91,

            EGroupIDs_RESERVED_92 = 92,

            EGroupIDs_RESERVED_93 = 93,

            EGroupIDs_RESERVED_94 = 94,

            EGroupIDs_RESERVED_95 = 95,

            EGroupIDs_RESERVED_96 = 96,

            EGroupIDs_RESERVED_97 = 97,

            EGroupIDs_RESERVED_98 = 98,

            EGroupIDs_RESERVED_99 = 99,

            EGroupIDs_RESERVED_100 = 100,

            EGroupIDs_RESERVED_101 = 101,

            EGroupIDs_RESERVED_102 = 102,

            EGroupIDs_RESERVED_103 = 103,

            EGroupIDs_RESERVED_104 = 104,

            EGroupIDs_RESERVED_105 = 105,

            EGroupIDs_RESERVED_106 = 106,

            EGroupIDs_RESERVED_107 = 107,

            EGroupIDs_RESERVED_108 = 108,

            EGroupIDs_RESERVED_109 = 109,

            EGroupIDs_RESERVED_110 = 110,

            EGroupIDs_RESERVED_111 = 111,

            EGroupIDs_RESERVED_112 = 112,

            EGroupIDs_RESERVED_113 = 113,

            EGroupIDs_RESERVED_114 = 114,

            EGroupIDs_RESERVED_115 = 115,

            EGroupIDs_RESERVED_116 = 116,

            EGroupIDs_RESERVED_117 = 117,

            EGroupIDs_RESERVED_118 = 118,

            EGroupIDs_RESERVED_119 = 119,

            EGroupIDs_RESERVED_120 = 120,

            EGroupIDs_RESERVED_121 = 121,

            EGroupIDs_RESERVED_122 = 122,

            EGroupIDs_RESERVED_123 = 123,

            EGroupIDs_RESERVED_124 = 124,

            EGroupIDs_RESERVED_125 = 125,

            EGroupIDs_RESERVED_126 = 126,

            EGroupIDs_RESERVED_127 = 127,

            GID_SERVER = 128,
        }

        public virtual void Sv_OnInit() { }
    }
}
/*
native function sv_ClientMessage(string Message);
native function sv_PrivateMessage(Pawn aPawn,string Message);
native function sv_ZoneMessage(string Message);
native function sv_UniverseMessage(string Message);
native function sv_GlobalMessage(string Message);
native function sv_SupportMessage(string Message);
native function sv_SystemMessage(string Message);
native function bool sv_CanReplicate();
event cl_OnShutdown();
event cl_OnTick(float DeltaTime) {
}
event cl_OnBaseline();
event cl_OnInit() {
if (Pawn != None) {                                                         
Base_Pawn(Pawn).cl_OnInit();                                              
}
if (Player != None) {                                                       
Player.GUIDesktop.OnLogin();                                              
}
ControllerInitialized = True;                                               
}
event sv_OnShutdown();
*/