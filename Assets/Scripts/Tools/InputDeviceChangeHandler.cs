using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class InputDeviceChangeHandler : MonoBehaviour
{
    void OnEnable()
    {
        InputUser.onChange += onInputDeviceChange;
    }

    void OnDisable()
    {
        InputUser.onChange -= onInputDeviceChange;
    }

    private void onInputDeviceChange(InputUser user, InputUserChange change, InputDevice device)
    {
        if (change == InputUserChange.ControlSchemeChanged)
        {
            Debug.Log(user.controlScheme.Value.name.ToString());
        }
    }
}
