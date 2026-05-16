using System.Collections.Generic;

/// <summary>
/// 全局FSM管理器
/// </summary>
public class FsmManager : Singleton<FsmManager>
{
    private readonly Dictionary<string, FsmBase> fsmDic = new Dictionary<string, FsmBase>();

    /// <summary>创建状态机</summary>
    public FsmBase CreateFsm(string fsmName)
    {
        if (!fsmDic.TryGetValue(fsmName, out var fsm))
        {
            fsm = new FsmBase();
            fsmDic.Add(fsmName, fsm);
        }
        return fsm;
    }

    /// <summary>获取状态机</summary>
    public FsmBase GetFsm(string fsmName)
    {
        fsmDic.TryGetValue(fsmName, out var fsm);
        return fsm;
    }

    /// <summary>销毁状态机</summary>
    public void DestroyFsm(string fsmName)
    {
        if (fsmDic.ContainsKey(fsmName))
            fsmDic.Remove(fsmName);
    }
}