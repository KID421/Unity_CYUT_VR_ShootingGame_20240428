using UnityEngine;

public class HpEnemy : HpSystem
{
    private string bulletName = "子彈";

    private void OnCollisionEnter(Collision collision)
    {
        // 如果 碰到的物件 名稱 包含 子彈 兩個字 就受傷
        if (collision.gameObject.name.Contains(bulletName))
        {
            float attack = collision.gameObject.GetComponent<Bullet>().attack;
            Damage(attack);
        }
    }

    // override 覆寫：覆寫父類別有 virtual 的成員
    protected override void Dead()
    {
        // 父類別原有內容
        base.Dead();
        // 刪除物件
        Destroy(gameObject);
    }
}
