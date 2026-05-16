using System.Collections.Generic;

/// <summary>
/// 有限状态机基类
/// </summary>
public class FsmBase
{
    // 存储所有状态
    protected Dictionary<string, StateBase> stateDic = new Dictionary<string, StateBase>();
    // 当前运行状态
    protected StateBase currentState;
    // 当前状态名
    public string CurrentStateName { get; private set; }

    /// <summary>添加状态</summary>
    public void AddState(string stateName, StateBase state)
    {
        if (!stateDic.ContainsKey(stateName))
        {
            stateDic.Add(stateName, state);
        }
    }

    /// <summary>切换状态</summary>
    public void SwitchState(string stateName)
    {
        if (!stateDic.TryGetValue(stateName, out var targetState)) return;

        // 退出当前状态
        currentState?.ExitState();
        // 切换
        currentState = targetState;
        CurrentStateName = stateName;
        // 进入新状态
        currentState.EnterState();
    }

    /// <summary>帧更新</summary>
    public void FsmUpdate()
    {
        currentState?.UpdateState();
    }
}