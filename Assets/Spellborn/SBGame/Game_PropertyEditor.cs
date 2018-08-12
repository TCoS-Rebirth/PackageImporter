using System;
using SBBase;

namespace SBGame
{
    [Serializable] public class Game_PropertyEditor : Base_Component
    {
        public Game_PropertyEditor()
        {
        }
    }
}
/*
protected native function cl2sv_OpenEditObject_CallStub();
native event cl2sv_OpenEditObject(string aClassName,string aName);
protected native function cl2sv_SendChanges_CallStub();
native event cl2sv_SendChanges(string aClassName,string aName,array<byte> aData);
native function EditObject(Object aObject);
*/