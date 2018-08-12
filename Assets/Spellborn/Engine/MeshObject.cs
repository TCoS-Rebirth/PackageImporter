using System;

namespace Engine
{
    [Serializable] public class MeshObject : UObject
    {
        public MeshObject()
        {
        }

        public enum EMeshSectionMethod
        {
            MSM_SmoothOnly,

            MSM_RigidOnly,

            MSM_Mixed,

            MSM_SinglePiece,

            MSM_ForcedRigid,
        }

        public enum EImpLightMode
        {
            ILM_Unlit,

            ILM_PseudoShaded,

            ILM_Uniform,
        }

        public enum EImpDrawMode
        {
            IDM_Normal,

            IDM_Fading,
        }

        public enum EImpSpaceMode
        {
            ISM_Sprite,

            ISM_Fixed,

            ISM_PivotVertical,

            ISM_PivotHorizontal,
        }
    }
}