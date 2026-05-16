using UnityEngine;

/// <summary>
/// 游戏框架唯一启动入口
/// </summary>
public class GameRoot : MonoBehaviour
{
    private void Awake()
    {
        // 优先初始化所有全局管理器
        InitFramework();
    }

    private void Start()
    {
        Debug.Log("===== 通用游戏框架初始化完成 =====");
        // 框架启动后可执行初始业务
    }

    /// <summary>
    /// 初始化所有框架模块
    /// </summary>
    void InitFramework()
    {
        // 触发所有单例初始化
        var ui = UIManager.Instance;
        var audio = AudioManager.Instance;
        var evt = EventManager.Instance;
        var scene = SceneMgr.Instance;
        var pool = ObjectPool.Instance;
        var fsmMgr = FsmManager.Instance;
        var debug = DebugManager.Instance;
    }
}