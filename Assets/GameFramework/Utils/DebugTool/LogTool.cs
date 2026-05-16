using UnityEngine;

/// <summary>
/// 框架统一日志工具
/// 可一键开关日志、分级打印、打包屏蔽日志
/// </summary>
public static class LogTool
{
    // 总开关：是否启用所有日志
    public static bool IsOpenLog = true;
    // 分级控制
    public static bool ShowNormal = true;
    public static bool ShowWarning = true;
    public static bool ShowError = true;

    /// <summary>普通日志</summary>
    public static void Log(string msg)
    {
        if (!IsOpenLog || !ShowNormal) return;
        Debug.Log($"【普通】{msg}");
    }

    /// <summary>黄色警告日志</summary>
    public static void LogWarning(string msg)
    {
        if (!IsOpenLog || !ShowWarning) return;
        Debug.LogWarning($"【警告】{msg}");
    }

    /// <summary>红色错误日志</summary>
    public static void LogError(string msg)
    {
        if (!IsOpenLog || !ShowError) return;
        Debug.LogError($"【错误】{msg}");
    }

    /// <summary>打包后关闭所有日志</summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void CloseLogInBuild()
    {
#if !UNITY_EDITOR
        IsOpenLog = false;
#endif
    }
}