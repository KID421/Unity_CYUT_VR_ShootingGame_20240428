using UnityEngine;

public class FireSystem : MonoBehaviour
{
    [SerializeField, Header("子彈預製物")]
    private GameObject prefabBullet;
    [SerializeField, Header("子彈生成點")]
    private Transform firePoint;
    [SerializeField, Header("發射速度"), Range(0, 3000)]
    private float fireSpeed = 500;

    // 更新事件：一秒執行約 60 次
    private void Update()
    {
        // 如果 按下左鍵 就發射子彈
        if (Input.GetKeyDown(KeyCode.Mouse0)) FireBullet();
    }

    public void FireBullet()
    {
        // 生成(物件，座標，角度)
        // 暫存子彈 = 生成(子彈預製物，生成點的座標，零角度)
        GameObject temp = Instantiate(prefabBullet, firePoint.position, Quaternion.identity);

        // 紅色軸向 X transform.right
        // 綠色軸向 Y transform.up
        // 藍色軸向 Z transform.forward
        // 暫存子彈 取得剛體 添加推力(武器的前方 * 速度)
        temp.GetComponent<Rigidbody>().AddForce(transform.forward * -fireSpeed);
    }
}

