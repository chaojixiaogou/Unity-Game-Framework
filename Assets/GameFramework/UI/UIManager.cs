using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    // UI缓存池 存放已经加载过的UI
    private readonly Dictionary<string, GameObject> _uiCache = new Dictionary<string, GameObject>();
    // 直接用场景里的Canvas做UI根
    private Transform _uiRoot;

    protected override void Init()
    {
        // 重点：自动找到场景中的Canvas作为UI父物体
        GameObject canvasObj = GameObject.Find("Canvas");
        if (canvasObj == null)
        {
            Debug.LogError("场景中没有Canvas！请先创建Canvas");
            return;
        }
        _uiRoot = canvasObj.transform;
    }

    /// <summary>
    /// 打开UI面板
    /// </summary>
    public GameObject OpenUI(string uiPrefabName)
    {
        if (_uiRoot == null) return null;
        
        // 优先从缓存取
        if (_uiCache.TryGetValue(uiPrefabName, out GameObject uiPanel))
        {
            uiPanel.SetActive(true);
            return uiPanel;
        }
        // 资源路径：Resources/UI/面板名
        GameObject prefab = Resources.Load<GameObject>($"UI/{uiPrefabName}");
        if (prefab == null)
        {
            Debug.LogError($"找不到UI预制体：{uiPrefabName} 路径Resources/UI下");
            return null;
        }
        // 实例化到Canvas下面！！
        GameObject newUI = Instantiate(prefab, _uiRoot);
        newUI.name = uiPrefabName;
        _uiCache.Add(uiPrefabName, newUI);
        return newUI;
    }

    /// <summary>
    /// 关闭UI 隐藏不销毁
    /// </summary>
    public void CloseUI(string uiName)
    {
        if (_uiCache.TryGetValue(uiName, out GameObject ui))
        {
            ui.SetActive(false);
        }
    }

    /// <summary>
    /// 销毁指定UI
    /// </summary>
    public void DestroyUI(string uiName)
    {
        if (_uiCache.TryGetValue(uiName, out GameObject ui))
        {
            Destroy(ui);
            _uiCache.Remove(uiName);
        }
    }
}