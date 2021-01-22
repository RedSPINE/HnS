// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Inputs/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Keyboard + Mouse"",
            ""id"": ""ba332324-8c60-43a7-bfd3-d6c92f127b96"",
            ""actions"": [
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""54562d97-a46a-42e6-9b0b-df86d8ec54c6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""35e09a3b-a58a-4a61-ab4b-69056536d7df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""9f7fa516-d98d-496c-ae7e-984cfef6bab2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""888eec9e-afdf-4938-9c34-1c704a722747"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse"",
                    ""type"": ""Value"",
                    ""id"": ""2d380f78-ab72-43ea-a4e9-4de65abfc17c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftClick"",
                    ""type"": ""Button"",
                    ""id"": ""cc47e55e-5f12-4316-96d3-a3b5890b9fc7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""Button"",
                    ""id"": ""ad3112f5-d107-4e3a-9aca-77ead510e84b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9503251f-f85c-49d5-9f22-ff70311309af"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3fe9130-e7eb-4e84-9884-4f3f02330094"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""207081e3-5298-46ab-bded-1aaff6d16dc2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75797053-7cd7-4496-9f7a-517616682d76"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""69d5f66f-8515-4d91-b27e-c87544c6f6b8"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b010fb79-edcb-48a7-b930-10c50807d192"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a134d72-1017-4d2b-8f7f-dacdaeba3491"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Keyboard + Mouse
        m_KeyboardMouse = asset.FindActionMap("Keyboard + Mouse", throwIfNotFound: true);
        m_KeyboardMouse_Up = m_KeyboardMouse.FindAction("Up", throwIfNotFound: true);
        m_KeyboardMouse_Down = m_KeyboardMouse.FindAction("Down", throwIfNotFound: true);
        m_KeyboardMouse_Left = m_KeyboardMouse.FindAction("Left", throwIfNotFound: true);
        m_KeyboardMouse_Right = m_KeyboardMouse.FindAction("Right", throwIfNotFound: true);
        m_KeyboardMouse_Mouse = m_KeyboardMouse.FindAction("Mouse", throwIfNotFound: true);
        m_KeyboardMouse_LeftClick = m_KeyboardMouse.FindAction("LeftClick", throwIfNotFound: true);
        m_KeyboardMouse_RightClick = m_KeyboardMouse.FindAction("RightClick", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Keyboard + Mouse
    private readonly InputActionMap m_KeyboardMouse;
    private IKeyboardMouseActions m_KeyboardMouseActionsCallbackInterface;
    private readonly InputAction m_KeyboardMouse_Up;
    private readonly InputAction m_KeyboardMouse_Down;
    private readonly InputAction m_KeyboardMouse_Left;
    private readonly InputAction m_KeyboardMouse_Right;
    private readonly InputAction m_KeyboardMouse_Mouse;
    private readonly InputAction m_KeyboardMouse_LeftClick;
    private readonly InputAction m_KeyboardMouse_RightClick;
    public struct KeyboardMouseActions
    {
        private @PlayerInput m_Wrapper;
        public KeyboardMouseActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Up => m_Wrapper.m_KeyboardMouse_Up;
        public InputAction @Down => m_Wrapper.m_KeyboardMouse_Down;
        public InputAction @Left => m_Wrapper.m_KeyboardMouse_Left;
        public InputAction @Right => m_Wrapper.m_KeyboardMouse_Right;
        public InputAction @Mouse => m_Wrapper.m_KeyboardMouse_Mouse;
        public InputAction @LeftClick => m_Wrapper.m_KeyboardMouse_LeftClick;
        public InputAction @RightClick => m_Wrapper.m_KeyboardMouse_RightClick;
        public InputActionMap Get() { return m_Wrapper.m_KeyboardMouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardMouseActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardMouseActions instance)
        {
            if (m_Wrapper.m_KeyboardMouseActionsCallbackInterface != null)
            {
                @Up.started -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnDown;
                @Left.started -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnRight;
                @Mouse.started -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnMouse;
                @Mouse.performed -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnMouse;
                @Mouse.canceled -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnMouse;
                @LeftClick.started -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnLeftClick;
                @LeftClick.performed -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnLeftClick;
                @LeftClick.canceled -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnLeftClick;
                @RightClick.started -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnRightClick;
            }
            m_Wrapper.m_KeyboardMouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Mouse.started += instance.OnMouse;
                @Mouse.performed += instance.OnMouse;
                @Mouse.canceled += instance.OnMouse;
                @LeftClick.started += instance.OnLeftClick;
                @LeftClick.performed += instance.OnLeftClick;
                @LeftClick.canceled += instance.OnLeftClick;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
            }
        }
    }
    public KeyboardMouseActions @KeyboardMouse => new KeyboardMouseActions(this);
    public interface IKeyboardMouseActions
    {
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnMouse(InputAction.CallbackContext context);
        void OnLeftClick(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
    }
}
