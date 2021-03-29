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
    private float timeToUpdateDamage = 1f;
    private float previousHealthPct = 1;

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
        Debug.Log("HandleHealthChange");
        Health.fillAmount = pct;
        StartCoroutine(ChangeToPct(pct));
    }

    private IEnumerator ChangeToPct(float pct)
    {
        float preChangePct = previousHealthPct;
        float elapsed = 0f;

        while (elapsed < timeToUpdateDamage)
        {
            elapsed += Time.deltaTime;
            Damage.fillAmount = Mathf.Lerp(previousHealthPct, pct, elapsed / timeToUpdateDamage);
            yield return null;
        }
        
        previousHealthPct = pct;
        Damage.fillAmount = pct;
    }
}
