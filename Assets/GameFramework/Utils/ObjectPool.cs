using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 通用游戏对象池管理器
/// </summary>
public class ObjectPool : Singleton<ObjectPool>
{
    // 键：预制体名  值：闲置对象队列
    private readonly Dictionary<string, Queue<GameObject>> _poolDic = new Dictionary<string, Queue<GameObject>>();
    // 对象父容器，统一管理层级
    private Transform _poolRoot;

    public ObjectPool()
    {
        // 运行时创建对象池父物体
        GameObject root = new GameObject("ObjectPoolRoot");
        UnityEngine.Object.DontDestroyOnLoad(root);
        _poolRoot = root.transform;
    }

    /// <summary>
    /// 从对象池获取对象
    /// </summary>
    /// <param name="prefabName">Resources下预制体路径</param>
    /// <param name="parent">挂载父物体</param>
    /// <returns></returns>
    public GameObject GetObj(string prefabName, Transform parent = null)
    {
        GameObject obj = null;
        // 1. 池子里有闲置对象直接取出
        if (_poolDic.ContainsKey(prefabName) && _poolDic[prefabName].Count > 0)
        {
            obj = _poolDic[prefabName].Dequeue();
        }
        else
        {
            // 2. 没有就加载实例化
            GameObject prefab = Resources.Load<GameObject>(prefabName);
            if (prefab == null)
            {
                Debug.LogError($"对象池加载失败：{prefabName} 路径不存在");
                return null;
            }
            obj = UnityEngine.Object.Instantiate(prefab);
        }

        // 激活+设置父物体
        obj.SetActive(true);
        if (parent != null)
            obj.transform.SetParent(parent);
        else
            obj.transform.SetParent(_poolRoot);

        return obj;
    }

    /// <summary>
    /// 回收对象回池子
    /// </summary>
    public void RecycleObj(string prefabName, GameObject obj, Action resetAction = null)
    {
        if (obj == null) return;
        // 执行自定义重置逻辑
        resetAction?.Invoke();
        // 隐藏对象
        obj.SetActive(false);
        obj.transform.SetParent(_poolRoot);

        // 存入对应队列
        if (!_poolDic.ContainsKey(prefabName))
        {
            _poolDic.Add(prefabName, new Queue<GameObject>());
        }
        _poolDic[prefabName].Enqueue(obj);
    }

    /// <summary>
    /// 清空指定对象池
    /// </summary>
    public void ClearPool(string prefabName)
    {
        if (_poolDic.TryGetValue(prefabName, out var queue))
        {
            queue.Clear();
        }
    }

    /// <summary>
    /// 清空所有对象池
    /// </summary>
    public void ClearAllPool()
    {
        _poolDic.Clear();
    }
}