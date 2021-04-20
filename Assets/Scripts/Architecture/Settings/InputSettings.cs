using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSettings : SingletonScriptableObject<InputSettings>
{
    public enum ControlScheme
    {
        KeyboardMouse,
        Gamepad
    }
    private ControlScheme scheme;
    public ControlScheme Scheme { get => scheme; }

    
}
