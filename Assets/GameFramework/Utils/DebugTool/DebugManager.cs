using UnityEngine;

/// <summary>
/// 游戏全局调试管理器
/// 快捷按键、调试面板、帧率显示、碰撞框显示等
/// </summary>
public class DebugManager : MonoSingleton<DebugManager>
{
    [Header("调试总开关")]
    public bool debugEnable = true;

    [Header("帧率显示")]
    public bool showFPS = true;
    private float _fpsTimer;
    private int _fpsCount;
    private string _fpsText;

    [Header("调试绘制")]
    public bool showGizmos = false;

    protected override void Init()
    {
        LogTool.Log("调试工具初始化完成");
    }

    private void Update()
    {
        if (!debugEnable) return;

        // 帧率统计
        UpdateFPS();
        // 调试快捷键
        CheckDebugKey();
    }

    #region 帧率显示
    void UpdateFPS()
    {
        if (!showFPS) return;
        _fpsTimer += Time.deltaTime;
        _fpsCount++;
        if (_fpsTimer >= 1f)
        {
            _fpsText = $"FPS：{_fpsCount}";
            _fpsTimer = 0;
            _fpsCount = 0;
        }
    }

    private void OnGUI()
    {
        if (!debugEnable || !showFPS) return;
        GUI.color = Color.green;
        GUI.Label(new Rect(20, 20, 150, 30), _fpsText);
    }
    #endregion

    #region 调试快捷键
    void CheckDebugKey()
    {
        // F1 开关所有调试
        if (Input.GetKeyDown(KeyCode.F1))
        {
            debugEnable = !debugEnable;
            LogTool.Log($"调试模式已{(debugEnable ? "开启" : "关闭")}");
        }
        // F2 显示/隐藏碰撞体Gizmos
        if (Input.GetKeyDown(KeyCode.F2))
        {
            showGizmos = !showGizmos;
            LogTool.Log($"碰撞框绘制：{(showGizmos ? "开启" : "关闭")}");
        }
        // F3 清空控制台
        if (Input.GetKeyDown(KeyCode.F3))
        {
            System.Console.Clear();
        }
        // F4 切换 1 倍 / 2 倍游戏速度
        if (Input.GetKeyDown(KeyCode.F4))
        {
            Time.timeScale = Time.timeScale == 1 ? 2 : 1;
            LogTool.Log($"游戏速度：{Time.timeScale}倍");
        }
        // F5 暂停游戏
        if (Input.GetKeyDown(KeyCode.F5))
        {
            Time.timeScale = 0;
            LogTool.Log("游戏暂停");
        }
    }
    #endregion

    private void OnDrawGizmosSelected()
    {
        if (!debugEnable || !showGizmos) return;
        // 可扩展：绘制范围、攻击区域、寻路路径等
    }

    /// <summary>场景内绘制3D文字</summary>
    public void DrawWorldText(Vector3 pos, string content, Color color)
    {
        if (!debugEnable) return;
        UnityEditor.Handles.color = color;
        UnityEditor.Handles.Label(pos, content);
    }

    /// <summary>绘制2D圆形范围</summary>
    public void DrawCircleArea(Vector2 center, float radius, Color color)
    {
        if (!debugEnable || !showGizmos) return;
        Gizmos.color = color;
        Gizmos.DrawWireSphere(center, radius);
    }
}