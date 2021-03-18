using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTableUI : MonoBehaviour
{
    [SerializeField] private GameObject skillButtonPrefab = null;
    private List<GameObject> skillButtons;

    private void Start() {
        skillButtons = new List<GameObject>();
    }

    public void Unselect(int marker = 0)
    {
        foreach (var skillButton in skillButtons)
        {
            skillButton.GetComponent<SkillButton>().Unselect(marker);
        }
    }
}
