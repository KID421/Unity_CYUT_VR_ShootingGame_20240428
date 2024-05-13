using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HpPlayer : HpSystem
{
    [SerializeField, Header("血條圖片")]
    private Image imgHp;
    [SerializeField, Header("血量文字")]
    private TMP_Text textHp;
    [SerializeField, Header("武器系統")]
    private FireSystem fireSystem;

    private string enemyAttackArea = "敵人攻擊";
    private float hpMax;

    private void Awake()
    {
        hpMax = hp;
        UpdateUI();
    }

    // 用來偵測有勾選 Is Trigger 的物件
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains(enemyAttackArea))
        {
            Damage(20);
        }
    }

    private void UpdateUI()
    {
        imgHp.fillAmount = hp / hpMax;
        textHp.text = $"血量 {hp} / {hpMax}";
    }

    protected override void Damage(float damage)
    {
        if (hp <= 0) return;
        base.Damage(damage);
        UpdateUI();
    }

    protected override void Dead()
    {
        base.Dead();
        // 關閉武器系統
        fireSystem.enabled = false;
    }
}
