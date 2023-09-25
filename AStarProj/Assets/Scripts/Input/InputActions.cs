//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.1
//     from Assets/InputSystem/InputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @BWCustomControl: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @BWCustomControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""User"",
            ""id"": ""69fac02a-7c5d-4d18-8f80-d097b9c33d35"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""7d4757e4-46b2-4919-98d3-3223da727f34"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MovementSpeed"",
                    ""type"": ""Button"",
                    ""id"": ""0caceebd-4e75-4872-a654-c72e6626ebbc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Orientation"",
                    ""type"": ""Value"",
                    ""id"": ""0b9335fd-42f0-4698-ba1f-dfe45a89bb9f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""OrientationToggle"",
                    ""type"": ""Button"",
                    ""id"": ""f460a0c2-9eca-43ca-aa90-1aa4f1381446"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""6887de81-6d47-4151-8d30-b9ad541fb9a4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2c7f716b-1962-40d6-baf6-cf319ea263a0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7fc8bad1-5c1c-4d17-b376-94e9e8647307"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3a9b806d-6625-4650-a2f4-a3038076ec23"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c371d502-2d64-4107-b812-39dac446204c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow keys"",
                    ""id"": ""abeef8d7-0e05-4b1b-95e6-12caa1fa71e9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""990da629-b304-402c-b2ef-e83e37f26e14"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""328c72d2-3c0b-4b6e-b3be-ceb6db834a10"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5a7db7d8-c129-4481-b7b5-dba06f5099a1"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c0588bed-11c0-4859-af07-ff290f584cfa"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8a84cffb-924e-4da5-b7f7-c8ad559f0ce0"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementSpeed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03a8a4e4-cb6a-4f50-b663-907bd48a6f32"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Orientation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bcf998a-c7a0-4667-8d5a-cac883e5fdb9"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OrientationToggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // User
        m_User = asset.FindActionMap("User", throwIfNotFound: true);
        m_User_Movement = m_User.FindAction("Movement", throwIfNotFound: true);
        m_User_MovementSpeed = m_User.FindAction("MovementSpeed", throwIfNotFound: true);
        m_User_Orientation = m_User.FindAction("Orientation", throwIfNotFound: true);
        m_User_OrientationToggle = m_User.FindAction("OrientationToggle", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // User
    private readonly InputActionMap m_User;
    private List<IUserActions> m_UserActionsCallbackInterfaces = new List<IUserActions>();
    private readonly InputAction m_User_Movement;
    private readonly InputAction m_User_MovementSpeed;
    private readonly InputAction m_User_Orientation;
    private readonly InputAction m_User_OrientationToggle;
    public struct UserActions
    {
        private @BWCustomControl m_Wrapper;
        public UserActions(@BWCustomControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_User_Movement;
        public InputAction @MovementSpeed => m_Wrapper.m_User_MovementSpeed;
        public InputAction @Orientation => m_Wrapper.m_User_Orientation;
        public InputAction @OrientationToggle => m_Wrapper.m_User_OrientationToggle;
        public InputActionMap Get() { return m_Wrapper.m_User; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UserActions set) { return set.Get(); }
        public void AddCallbacks(IUserActions instance)
        {
            if (instance == null || m_Wrapper.m_UserActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UserActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @MovementSpeed.started += instance.OnMovementSpeed;
            @MovementSpeed.performed += instance.OnMovementSpeed;
            @MovementSpeed.canceled += instance.OnMovementSpeed;
            @Orientation.started += instance.OnOrientation;
            @Orientation.performed += instance.OnOrientation;
            @Orientation.canceled += instance.OnOrientation;
            @OrientationToggle.started += instance.OnOrientationToggle;
            @OrientationToggle.performed += instance.OnOrientationToggle;
            @OrientationToggle.canceled += instance.OnOrientationToggle;
        }

        private void UnregisterCallbacks(IUserActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @MovementSpeed.started -= instance.OnMovementSpeed;
            @MovementSpeed.performed -= instance.OnMovementSpeed;
            @MovementSpeed.canceled -= instance.OnMovementSpeed;
            @Orientation.started -= instance.OnOrientation;
            @Orientation.performed -= instance.OnOrientation;
            @Orientation.canceled -= instance.OnOrientation;
            @OrientationToggle.started -= instance.OnOrientationToggle;
            @OrientationToggle.performed -= instance.OnOrientationToggle;
            @OrientationToggle.canceled -= instance.OnOrientationToggle;
        }

        public void RemoveCallbacks(IUserActions instance)
        {
            if (m_Wrapper.m_UserActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUserActions instance)
        {
            foreach (var item in m_Wrapper.m_UserActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UserActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UserActions @User => new UserActions(this);
    public interface IUserActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnMovementSpeed(InputAction.CallbackContext context);
        void OnOrientation(InputAction.CallbackContext context);
        void OnOrientationToggle(InputAction.CallbackContext context);
    }
}
