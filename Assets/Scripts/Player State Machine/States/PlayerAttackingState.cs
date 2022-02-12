using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingState : PlayerAbstractState
{
    public PlayerAttackingState(PlayerStateMachine ctx, PlayerStateFactory factory) : base(ctx, factory) { }

    public override void EnterState()
    {
        _ctx.PlayerInput.Controller.Disable();
        if (_ctx.HitCounter > 2)
        {
            _ctx.HitCounter = 0;
        }
        _ctx.PlayerAnimator.SetInteger(_ctx.H_hitCount, _ctx.HitCounter);
        _ctx.PlayerAnimator.SetTrigger(_ctx.H_attack);
        _ctx.KatanaTrail.GetComponent<ParticleSystem>().Play();
        //_ctx.KatanaTrail.SetActive(true);
    }
    public override void UpdateState()
    {
        Debug.Log("In Attack hash " + _ctx.PlayerAnimator.GetCurrentAnimatorStateInfo(0).shortNameHash);

        CheckSwitchStates();
    }
    public override void ExitState()
    {
        _ctx.IsAttackingPressed = false;
        _ctx.HitCounter++;
        _ctx.KatanaTrail.GetComponent<ParticleSystem>().Stop();
        _ctx.PlayerInput.Controller.Enable();

    }
    public override void CheckSwitchStates()
    {
        if ((_ctx.H_attackAnimationList.Contains(_ctx.PlayerAnimator.GetCurrentAnimatorStateInfo(0).shortNameHash)
        || _ctx.H_attackAnimationList.Contains(_ctx.PlayerAnimator.GetNextAnimatorStateInfo(0).shortNameHash))
        || _ctx.PlayerAnimator.IsInTransition(0))
        {

        }
        else
        {
            SwitchState(_factory.Idle());
            //_ctx.PlayerInput.Controller.Enable();
            // if (_ctx.IsMovementPressed)
            // {
            //     SwitchState(_factory.Moving());
            // }
            // else
            // {
            //     SwitchState(_factory.Idle());
            // }
        }
    }

    public override void InitializeSubState() { }
    public override string getName()
    {
        return "Attacking";
    }
}
