using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private List<ScrSkill> skills;

    // Start is called before the first frame update
    void Start()
    {
        var loadSkills = Resources.LoadAll<ScrSkill>("Skills/");
        skills = new List<ScrSkill>(loadSkills);
        Debug.Log(skills.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LogSkills()
    {
        String log = "List of Skills :\n";
        foreach (var skill in skills)
        {
            log += skill.skillName + "\n";
        }
        Debug.Log(log);
    }
}
