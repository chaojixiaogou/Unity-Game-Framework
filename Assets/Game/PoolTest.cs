using UnityEngine;

public class PoolTest : MonoBehaviour
{
    private void Update()
    {
        // 按A生成子弹
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject bullet = ObjectPool.Instance.GetObj("Bullet/Bullet");
            bullet.transform.position = Vector3.up * 2;
        }
        // 按S回收所有子弹
        if (Input.GetKeyDown(KeyCode.S))
        {
            // 找到场景中激活的子弹回收
            GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
            foreach (var b in bullets)
            {
                ObjectPool.Instance.RecycleObj("Bullet/Bullet", b);
            }
        }
    }
}