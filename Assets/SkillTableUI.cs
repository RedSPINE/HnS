using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTableUI : MonoBehaviour
{
    [SerializeField] private GameObject skillButtonPrefab = null;
    [SerializeField] private Transform contentTarget = null;
    private List<GameObject> skillButtons;
    private PlayerController controller;

    private void Start()
    {
        skillButtons = new List<GameObject>();
        controller = FindObjectOfType<PlayerController>();
    }

    public void AddSkill(ScrSkill skill)
    {
        GameObject skillButtonGO = Instantiate(skillButtonPrefab, Vector3.zero, Quaternion.identity, contentTarget);
        skillButtonGO.GetComponent<SkillButton>().skill = skill;
        skillButtons.Add(skillButtonGO);
    }

    public void Unselect(int marker = 0)
    {
        foreach (var skillButton in skillButtons)
        {
            skillButton.GetComponent<SkillButton>().Unselect(marker);
        }
    }

    public void EquipSkill(int index, ScrSkill skill)
    {
        controller.skills[index-1] = skill;
    }

    public void EmptySkillList()
    {
        foreach (Transform child in contentTarget)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
