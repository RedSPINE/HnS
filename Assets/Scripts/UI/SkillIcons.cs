using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class SkillIcons : MonoBehaviour
{
    [SerializeField] private Image skill1 = null;
    [SerializeField] private Image skill2 = null;
    private PlayerController controller;

    private void Start() {
        controller = FindObjectOfType<PlayerController>();
    }

    private void Update() {
        skill1.sprite = controller.skills[0].icon;
        skill2.sprite = controller.skills[1].icon;
    }
}
