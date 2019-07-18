// GENERATED AUTOMATICALLY FROM 'Assets/Aidan/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerInput : IInputActionCollection
{
    private InputActionAsset asset;
    public PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""a1757954-87d2-4dda-93f2-4ba046d82b21"",
            ""actions"": [
                {
                    ""name"": ""RaiseRightArm"",
                    ""id"": ""e7d37a12-80af-4d96-839c-eeb704055569"",
                    ""expectedControlLayout"": """",
                    ""continuous"": true,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                },
                {
                    ""name"": ""LowerRightArm"",
                    ""id"": ""250ca065-6d43-4cac-ba86-4af3051ba6ce"",
                    ""expectedControlLayout"": """",
                    ""continuous"": true,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                },
                {
                    ""name"": ""RaiseLeftArm"",
                    ""id"": ""10817e9a-79eb-459b-bcb9-e1dfb8e345b5"",
                    ""expectedControlLayout"": """",
                    ""continuous"": true,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                },
                {
                    ""name"": ""LowerLeftArm"",
                    ""id"": ""5094ad8a-7cd9-47ee-bee2-7b7078a769a2"",
                    ""expectedControlLayout"": """",
                    ""continuous"": true,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e75515cd-eb16-4919-8520-c236288c7689"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RaiseRightArm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""919e1701-382a-4903-bf9e-b5cc46830dbb"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LowerRightArm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""65470e16-4447-4b62-a372-cbe631d4c7cf"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RaiseLeftArm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""525fce98-27ba-4953-bb01-4df61f59c8d2"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LowerLeftArm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.GetActionMap("Gameplay");
        m_Gameplay_RaiseRightArm = m_Gameplay.GetAction("RaiseRightArm");
        m_Gameplay_LowerRightArm = m_Gameplay.GetAction("LowerRightArm");
        m_Gameplay_RaiseLeftArm = m_Gameplay.GetAction("RaiseLeftArm");
        m_Gameplay_LowerLeftArm = m_Gameplay.GetAction("LowerLeftArm");
    }

    ~PlayerInput()
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

    public ReadOnlyArray<InputControlScheme> controlSchemes
    {
        get => asset.controlSchemes;
    }

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

    // Gameplay
    private InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private InputAction m_Gameplay_RaiseRightArm;
    private InputAction m_Gameplay_LowerRightArm;
    private InputAction m_Gameplay_RaiseLeftArm;
    private InputAction m_Gameplay_LowerLeftArm;
    public struct GameplayActions
    {
        private PlayerInput m_Wrapper;
        public GameplayActions(PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @RaiseRightArm { get { return m_Wrapper.m_Gameplay_RaiseRightArm; } }
        public InputAction @LowerRightArm { get { return m_Wrapper.m_Gameplay_LowerRightArm; } }
        public InputAction @RaiseLeftArm { get { return m_Wrapper.m_Gameplay_RaiseLeftArm; } }
        public InputAction @LowerLeftArm { get { return m_Wrapper.m_Gameplay_LowerLeftArm; } }
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                RaiseRightArm.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRaiseRightArm;
                RaiseRightArm.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRaiseRightArm;
                RaiseRightArm.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRaiseRightArm;
                LowerRightArm.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLowerRightArm;
                LowerRightArm.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLowerRightArm;
                LowerRightArm.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLowerRightArm;
                RaiseLeftArm.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRaiseLeftArm;
                RaiseLeftArm.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRaiseLeftArm;
                RaiseLeftArm.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRaiseLeftArm;
                LowerLeftArm.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLowerLeftArm;
                LowerLeftArm.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLowerLeftArm;
                LowerLeftArm.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLowerLeftArm;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                RaiseRightArm.started += instance.OnRaiseRightArm;
                RaiseRightArm.performed += instance.OnRaiseRightArm;
                RaiseRightArm.canceled += instance.OnRaiseRightArm;
                LowerRightArm.started += instance.OnLowerRightArm;
                LowerRightArm.performed += instance.OnLowerRightArm;
                LowerRightArm.canceled += instance.OnLowerRightArm;
                RaiseLeftArm.started += instance.OnRaiseLeftArm;
                RaiseLeftArm.performed += instance.OnRaiseLeftArm;
                RaiseLeftArm.canceled += instance.OnRaiseLeftArm;
                LowerLeftArm.started += instance.OnLowerLeftArm;
                LowerLeftArm.performed += instance.OnLowerLeftArm;
                LowerLeftArm.canceled += instance.OnLowerLeftArm;
            }
        }
    }
    public GameplayActions @Gameplay
    {
        get
        {
            return new GameplayActions(this);
        }
    }
    public interface IGameplayActions
    {
        void OnRaiseRightArm(InputAction.CallbackContext context);
        void OnLowerRightArm(InputAction.CallbackContext context);
        void OnRaiseLeftArm(InputAction.CallbackContext context);
        void OnLowerLeftArm(InputAction.CallbackContext context);
    }
}
