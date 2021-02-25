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
                    ""name"": ""Mouse"",
                    ""type"": ""Value"",
                    ""id"": ""2d380f78-ab72-43ea-a4e9-4de65abfc17c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.1,pressPoint=0.5)""
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
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""d133922a-3c04-43dc-bb49-4880dd9f9ba3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Space"",
                    ""type"": ""Button"",
                    ""id"": ""6cf56df6-0f44-425e-96b0-d242611066dd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
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
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""78855855-d4e3-415e-a43a-8524362730e4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""537b9f6a-92c3-4e6e-a90e-01da00e4ecc1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e19525b9-cebc-445e-90c6-e846a2dd5a50"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c1009c80-58e8-4cf8-9d1c-626f87d20341"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""27ce38fe-df47-4109-b915-02e2054be35a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ce45ad56-f255-4dbd-9ea7-bff4781e2bc9"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Space"",
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
        m_KeyboardMouse_Mouse = m_KeyboardMouse.FindAction("Mouse", throwIfNotFound: true);
        m_KeyboardMouse_LeftClick = m_KeyboardMouse.FindAction("LeftClick", throwIfNotFound: true);
        m_KeyboardMouse_RightClick = m_KeyboardMouse.FindAction("RightClick", throwIfNotFound: true);
        m_KeyboardMouse_Move = m_KeyboardMouse.FindAction("Move", throwIfNotFound: true);
        m_KeyboardMouse_Space = m_KeyboardMouse.FindAction("Space", throwIfNotFound: true);
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
    private readonly InputAction m_KeyboardMouse_Mouse;
    private readonly InputAction m_KeyboardMouse_LeftClick;
    private readonly InputAction m_KeyboardMouse_RightClick;
    private readonly InputAction m_KeyboardMouse_Move;
    private readonly InputAction m_KeyboardMouse_Space;
    public struct KeyboardMouseActions
    {
        private @PlayerInput m_Wrapper;
        public KeyboardMouseActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Mouse => m_Wrapper.m_KeyboardMouse_Mouse;
        public InputAction @LeftClick => m_Wrapper.m_KeyboardMouse_LeftClick;
        public InputAction @RightClick => m_Wrapper.m_KeyboardMouse_RightClick;
        public InputAction @Move => m_Wrapper.m_KeyboardMouse_Move;
        public InputAction @Space => m_Wrapper.m_KeyboardMouse_Space;
        public InputActionMap Get() { return m_Wrapper.m_KeyboardMouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardMouseActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardMouseActions instance)
        {
            if (m_Wrapper.m_KeyboardMouseActionsCallbackInterface != null)
            {
                @Mouse.started -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnMouse;
                @Mouse.performed -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnMouse;
                @Mouse.canceled -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnMouse;
                @LeftClick.started -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnLeftClick;
                @LeftClick.performed -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnLeftClick;
                @LeftClick.canceled -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnLeftClick;
                @RightClick.started -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnRightClick;
                @Move.started -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnMove;
                @Space.started -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnSpace;
                @Space.performed -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnSpace;
                @Space.canceled -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnSpace;
            }
            m_Wrapper.m_KeyboardMouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Mouse.started += instance.OnMouse;
                @Mouse.performed += instance.OnMouse;
                @Mouse.canceled += instance.OnMouse;
                @LeftClick.started += instance.OnLeftClick;
                @LeftClick.performed += instance.OnLeftClick;
                @LeftClick.canceled += instance.OnLeftClick;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Space.started += instance.OnSpace;
                @Space.performed += instance.OnSpace;
                @Space.canceled += instance.OnSpace;
            }
        }
    }
    public KeyboardMouseActions @KeyboardMouse => new KeyboardMouseActions(this);
    public interface IKeyboardMouseActions
    {
        void OnMouse(InputAction.CallbackContext context);
        void OnLeftClick(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnSpace(InputAction.CallbackContext context);
    }
}
