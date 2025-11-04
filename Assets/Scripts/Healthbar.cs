using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Image fill;
    [SerializeField] private Gradient gradient; // ไล่สี เขียว→เหลือง→แดง
    [SerializeField] private Vector3 offset = new Vector3(0f, 1.2f, 0f); // ตำแหน่งเหนือหัว

    private Transform target; // ตัวละครที่ bar จะตาม

    private void Awake()
    {
        target = transform.parent; // ให้ bar ติดกับตัวแม่ (เช่น Player)
    }

    private void LateUpdate()
    {
        if (target != null)
            transform.position = target.position + offset;
    }

    public void SetMaxHealth(int maxHealth, int current)
    {
        slider.maxValue = maxHealth;
        slider.value = current;
        fill.color = gradient.Evaluate(1f);
    }

    public void UpdateHealth(int current)
    {
        slider.value = current;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
