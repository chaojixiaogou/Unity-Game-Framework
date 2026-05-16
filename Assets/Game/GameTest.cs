using UnityEngine;

public class GameTest : MonoBehaviour
{
    void Start()
    {
        // 框架调用打开UI
        UIManager.Instance.OpenUI("MainPanel");
    }
}