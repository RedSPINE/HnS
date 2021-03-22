using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour, IPointerClickHandler 
{
    private PlayerController controller;
    [HideInInspector] public SkillSO skill = null;
    
    [SerializeField] private Image marker1 = null;
    [SerializeField] private Image marker2 = null;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<PlayerController>();
        if (skill!=null) GetComponent<Image>().sprite = skill.icon;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SkillTableUI skillTableUI = FindObjectOfType<SkillTableUI>();
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            skillTableUI.Unselect(1);
            skillTableUI.EquipSkill(1, skill);
            marker1.enabled = true;
            Debug.Log(skill.name + " on left click.");
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            skillTableUI.Unselect(2);
            skillTableUI.EquipSkill(2, skill);
            marker2.enabled = true;
            Debug.Log(skill.name + " on right click.");
        }
    }

    public void Unselect(int marker = 0)
    {
        if(marker==1)
        {
            marker1.enabled = false;
        }
        else if(marker==2)
        {
            marker2.enabled = false;
        }
        else
        {
            marker1.enabled = false;
            marker2.enabled = false;
        }
    }
    
}
