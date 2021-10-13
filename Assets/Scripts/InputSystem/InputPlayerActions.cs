// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputSystem/InputPlayerActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputPlayerActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputPlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputPlayerActions"",
    ""maps"": [
        {
            ""name"": ""PC"",
            ""id"": ""b4b113b6-ee29-4023-b736-9a82d4ab6cae"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""7b04cdd1-e387-406f-9f39-4e50dbf3ee0b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f384a3e7-20d6-419c-9969-9d88b37b70c5"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""SmartPhone"",
            ""id"": ""a9df581a-3e27-44d1-9bb9-c81f89fe51df"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""e579dd0b-248c-448c-81d5-a223913a1ad0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""14dfb33f-86f1-43ff-93c9-de7ba03f0996"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PC
        m_PC = asset.FindActionMap("PC", throwIfNotFound: true);
        m_PC_Jump = m_PC.FindAction("Jump", throwIfNotFound: true);
        // SmartPhone
        m_SmartPhone = asset.FindActionMap("SmartPhone", throwIfNotFound: true);
        m_SmartPhone_Jump = m_SmartPhone.FindAction("Jump", throwIfNotFound: true);
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

    // PC
    private readonly InputActionMap m_PC;
    private IPCActions m_PCActionsCallbackInterface;
    private readonly InputAction m_PC_Jump;
    public struct PCActions
    {
        private @InputPlayerActions m_Wrapper;
        public PCActions(@InputPlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_PC_Jump;
        public InputActionMap Get() { return m_Wrapper.m_PC; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PCActions set) { return set.Get(); }
        public void SetCallbacks(IPCActions instance)
        {
            if (m_Wrapper.m_PCActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_PCActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PCActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PCActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_PCActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public PCActions @PC => new PCActions(this);

    // SmartPhone
    private readonly InputActionMap m_SmartPhone;
    private ISmartPhoneActions m_SmartPhoneActionsCallbackInterface;
    private readonly InputAction m_SmartPhone_Jump;
    public struct SmartPhoneActions
    {
        private @InputPlayerActions m_Wrapper;
        public SmartPhoneActions(@InputPlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_SmartPhone_Jump;
        public InputActionMap Get() { return m_Wrapper.m_SmartPhone; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SmartPhoneActions set) { return set.Get(); }
        public void SetCallbacks(ISmartPhoneActions instance)
        {
            if (m_Wrapper.m_SmartPhoneActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_SmartPhoneActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_SmartPhoneActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_SmartPhoneActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_SmartPhoneActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public SmartPhoneActions @SmartPhone => new SmartPhoneActions(this);
    public interface IPCActions
    {
        void OnJump(InputAction.CallbackContext context);
    }
    public interface ISmartPhoneActions
    {
        void OnJump(InputAction.CallbackContext context);
    }
}
