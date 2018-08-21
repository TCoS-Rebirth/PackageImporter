using SBGame;
using Engine;


//custom class
public abstract class UnrealScriptState<T> where T : Actor
{
    public virtual void BeginState(T outer) { }
    public virtual void EndState(T outer) { }
}

public class Auto_Pawn_PawnAlive: UnrealScriptState<Game_Pawn>
{
    public override void BeginState(Game_Pawn pawn)
    {
        pawn.SetCollision(true, false);
        if (pawn.Controller != null) ((Game_Controller)pawn.Controller).SBGotoState((Game_Controller.EControllerStates)1);
        pawn.mCurrentState = (Game_Pawn.EPawnStates)1;
        pawn.mNetState = (Game_Pawn.EPawnStates)1;
        //if (pawn.SBRole == (Actor.eSBNetworkRoles)1 && sv_CanReplicate()) pawn.sv2clrel_UpdateNetState_CallStub(mNetState);
        //if (pawn.CombatStats != null) pawn.CombatStats.sv_ExitCombat();
        pawn.Velocity = new Vector(0, 0, 0);
        pawn.SetPhysics(Actor.EPhysics.PHYS_Walking);
    }
}

public class Pawn_PawnDead: UnrealScriptState<Game_Pawn>
{
    public override void BeginState(Game_Pawn pawn)
    {
        Game_Pawn Killer;
        pawn.SetCollision(false, false);
        if (pawn.SBRole == (Actor.eSBNetworkRoles)1)
        {
            pawn.Skills.sv_FireCondition(null, 6);
            ((Game_Controller)pawn.Controller).sv_FireHook((Content_Type.EContentHook)8, null, 0);
            if (pawn.CombatStats != null)
            {
                Killer = pawn.CombatStats.sv_GetKiller();
            }
            else
            {
                Killer = null;
            }
            pawn.sv2rel_CombatMessageDeath_CallStub(Killer, pawn);
            if (pawn.IsPlayerPawn())
            {
                //pawn.sv2cl_CombatMessageDeath_CallStub(Killer);
                if (pawn.MiniGameProxy != null)
                {
                    pawn.MiniGameProxy.sv_PlayerDied();
                }
            ((Game_PlayerStats)pawn.CharacterStats).DecreasePePRank();
            }
            pawn.Skills.sv_RemoveDuffs(null, false);
        }
        pawn.combatState.RemovePreparedBonusConditional();
        //pawn.PlayDeathAnim(Acceleration);
        pawn.Skills.ResetAttacking();
        ((Game_Controller)pawn.Controller).SBGotoState((Game_Controller.EControllerStates)2);
        pawn.mCurrentState = (Game_Pawn.EPawnStates)2;
        pawn.mNetState = (Game_Pawn.EPawnStates)2;
        if (pawn.SBRole == (Actor.eSBNetworkRoles)1 && pawn.sv_CanReplicate())
        {
            pawn.sv2clrel_UpdateNetState_CallStub(pawn.mNetState);
        }
        pawn.SetPhysics(Actor.EPhysics.PHYS_None);
        pawn.StopMoving();
        //pawn.StaticPlaySound(19, 1024.00000000);
        if (pawn.SBRole == (Actor.eSBNetworkRoles)1)
        {
            pawn.sv_DestroyPet(true);
        }
    }
}

public class Auto_Controller_PawnAlive: UnrealScriptState<Game_Controller>
{
    public override void BeginState(Game_Controller outer)
    {
        //if (IsClient() && outer.Pawn != null)
        //{
            //GUI.HideDeathRespawn();                                               
        //}
    }
}

public class Controller_PawnSitting: UnrealScriptState<Game_Controller>
{
    public override void EndState(Game_Controller outer)
    {
        (outer as Game_PlayerController).OnSitDown(false);
        base.EndState(outer);
    }

    public void cl_OnPlayerTick(float aDeltaTime, Game_PlayerController outer)
    {
        //Game_PlayerPawn gpp = (Game_PlayerPawn)outer.Pawn;
        outer.TickMovement(aDeltaTime);
    }

    public override void BeginState(Game_Controller outer)
    {
        Game_PlayerPawn gpp = (Game_PlayerPawn)outer.Pawn;
        if (gpp != null)
        {
            if (/*!outer.IsServer() && */gpp.Physics != gpp.mNetPhysics)
            {
                gpp.SetPhysics(gpp.mNetPhysics);
            }
        }
        base.BeginState(outer);
        (outer as Game_PlayerController).OnSitDown(true);
    }
}

public class Controller_PawnDead: UnrealScriptState<Game_Controller>
{
    public override void BeginState(Game_Controller outer)
    {
        var pawn = outer.Pawn as Game_Pawn;
        if (pawn != null)
        {
            if (pawn.Trading != null) pawn.Trading.cl_HandleDeath();
        }
        if ((outer as Game_PlayerController).GroupingTeams != null) (outer as Game_PlayerController).GroupingTeams.HandleDeath();
    }
}
