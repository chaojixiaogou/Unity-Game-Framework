using UnityEngine;
using UnityEngine.UI;

public class BtnTest : MonoBehaviour
{
    public Button testBtn;

    private void Awake()
    {
        testBtn.onClick.AddListener(OnClickTestBtn);
        // 监听全局事件
        EventManager.Instance.AddEvent("TestEvent", ReceiveEvent);
    }

    void OnClickTestBtn()
    {
        // 播放音效
        AudioManager.Instance.PlaySound("click");
        // 派发全局事件
        EventManager.Instance.DispatchEvent("TestEvent", "按钮点击成功");
    }

    void ReceiveEvent(object msg)
    {
        Debug.Log("收到全局事件：" + msg);
    }
}