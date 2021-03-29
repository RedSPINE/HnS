using System.Timers;
using System.Collections;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField]
    private Image Health;
    [SerializeField]
    private Image Damage;

    [SerializeField]
    private float damageSpeed = 1;
    private float targetPct;
    private bool locked;

    private void Awake()
    {
        var parentEntity = GetComponentInParent<Entity>();
        Health.fillAmount = 1;
        Damage.fillAmount = 1;
        parentEntity.OnHealthPctChange += HandleHealthChange;
    }

    private void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
    }

    private void HandleHealthChange(float pct)
    {
        Health.fillAmount = pct;
        targetPct = pct;
        StartCoroutine(UpdateDamage());
    }

    private IEnumerator UpdateDamage()
    {
        if (locked) { yield break; }
        locked = true;

        while (Damage.fillAmount > targetPct)
        {
            var fillAmount = Damage.fillAmount;
            fillAmount -= Time.deltaTime * damageSpeed;
            if (fillAmount < targetPct)
                fillAmount = targetPct;
            Damage.fillAmount = fillAmount;
            yield return null;
        }

        locked = false;
    }
}
