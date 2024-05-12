using UnityEngine;

public class HpSystem : MonoBehaviour
{
    [SerializeField, Header("血量"), Range(0, 500)]
    private float hp;

    protected void Damage(float damage)
    {
        // 血量扣除傷害值
        hp -= damage;
        // 如果 血量 <= 0 就死亡
        if (hp <= 0) Dead();

        print($"<color=#f69>{gameObject.name} 血量：{hp}</color>");
    }

    // virtual 虛擬：允許子類別覆寫
    protected virtual void Dead()
    {
        print($"<color=#f33>{gameObject.name} 死亡</color>");
    }
}
