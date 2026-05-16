using UnityEngine;

/// <summary>
/// 所有状态父类
/// </summary>
public abstract class StateBase
{
    // 所属状态机
    protected FsmBase fsm;

    protected StateBase(FsmBase fsm)
    {
        this.fsm = fsm;
    }

    /// <summary>进入状态</summary>
    public abstract void EnterState();

    /// <summary>状态持续执行</summary>
    public abstract void UpdateState();

    /// <summary>退出状态</summary>
    public abstract void ExitState();
}