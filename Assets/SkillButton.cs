using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour, IPointerClickHandler 
{
    private PlayerController controller;

    [SerializeField] private Image marker1 = null;
    [SerializeField] private Image marker2 = null;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<PlayerController>();
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            marker1.enabled = true;
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            marker2.enabled = true;
        }
    }

    public void Unselect(int marker = 0)
    {
        marker1.enabled = marker==2;
        marker2.enabled = marker==1;
    }
    
}
