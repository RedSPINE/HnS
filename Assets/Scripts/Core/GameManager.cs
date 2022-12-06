using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SkillTable skillTable = null;
    private SkillTableUI skillTableUI;
    private List<SkillSO> skills;

    // Start is called before the first frame update
    void Start()
    {
        LogSkills();
        skillTableUI = FindObjectOfType<SkillTableUI>();
        skillTableUI.EmptySkillList();
        LoadSkills();
        skillTableUI.Unselect();
    }

    // Update is called once per frame
    private void LoadSkills()
    {
        foreach (SkillSO skill in skillTable.skills)
        {
            skillTableUI.AddSkill(skill);
        }   
    }

    private void LogSkills()
    {
        String log = "List of Skills :\n";
        foreach (var skill in skillTable.skills)
        {
            log += skill.skillName + "\n";
        }
        Debug.Log(log);
    }
}
