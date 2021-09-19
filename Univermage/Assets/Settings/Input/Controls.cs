// GENERATED AUTOMATICALLY FROM 'Assets/Settings/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""57553864-13c6-42db-a197-4fb61851d9b4"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""beaa003f-3dd3-451e-a35b-aaa704b071fa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SpellCast"",
                    ""type"": ""Button"",
                    ""id"": ""5fe7a135-0128-4aaf-bdd0-9e81c0db89f4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Save"",
                    ""type"": ""Button"",
                    ""id"": ""072ff7c8-464f-4dc9-be71-15e4994b3729"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""LoadLastSave"",
                    ""type"": ""Button"",
                    ""id"": ""57b3d3a8-30b8-4c4b-9d09-1ee321e413ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""RestartLevel"",
                    ""type"": ""Button"",
                    ""id"": ""d618b872-123e-444d-b9b1-011d470faca2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""de0cc1d0-cd70-46bc-b6ec-2806fd06e585"",
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
                    ""id"": ""b20b458d-26de-477c-aabe-ba93b3969499"",
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
                    ""id"": ""acce5026-b2e7-498b-b296-e95f1599586d"",
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
                    ""id"": ""0ebf52f4-66a7-4bcd-a21a-cd64d25357a5"",
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
                    ""id"": ""cc6aa052-e47b-46a2-839a-eec9029459b5"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""475caf71-207f-4d85-a0d9-7742a02d253f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpellCast"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c1b0cac-6e6a-4016-96b5-163312dd86fa"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RestartLevel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1570a286-7b53-4e80-81a2-4223f01486d3"",
                    ""path"": ""<Keyboard>/f5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Save"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d755a2f-0d50-4f59-bd00-010f6c7ae78e"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LoadLastSave"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_SpellCast = m_Player.FindAction("SpellCast", throwIfNotFound: true);
        m_Player_Save = m_Player.FindAction("Save", throwIfNotFound: true);
        m_Player_LoadLastSave = m_Player.FindAction("LoadLastSave", throwIfNotFound: true);
        m_Player_RestartLevel = m_Player.FindAction("RestartLevel", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_SpellCast;
    private readonly InputAction m_Player_Save;
    private readonly InputAction m_Player_LoadLastSave;
    private readonly InputAction m_Player_RestartLevel;
    public struct PlayerActions
    {
        private @Controls m_Wrapper;
        public PlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @SpellCast => m_Wrapper.m_Player_SpellCast;
        public InputAction @Save => m_Wrapper.m_Player_Save;
        public InputAction @LoadLastSave => m_Wrapper.m_Player_LoadLastSave;
        public InputAction @RestartLevel => m_Wrapper.m_Player_RestartLevel;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @SpellCast.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpellCast;
                @SpellCast.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpellCast;
                @SpellCast.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpellCast;
                @Save.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSave;
                @Save.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSave;
                @Save.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSave;
                @LoadLastSave.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLoadLastSave;
                @LoadLastSave.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLoadLastSave;
                @LoadLastSave.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLoadLastSave;
                @RestartLevel.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRestartLevel;
                @RestartLevel.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRestartLevel;
                @RestartLevel.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRestartLevel;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @SpellCast.started += instance.OnSpellCast;
                @SpellCast.performed += instance.OnSpellCast;
                @SpellCast.canceled += instance.OnSpellCast;
                @Save.started += instance.OnSave;
                @Save.performed += instance.OnSave;
                @Save.canceled += instance.OnSave;
                @LoadLastSave.started += instance.OnLoadLastSave;
                @LoadLastSave.performed += instance.OnLoadLastSave;
                @LoadLastSave.canceled += instance.OnLoadLastSave;
                @RestartLevel.started += instance.OnRestartLevel;
                @RestartLevel.performed += instance.OnRestartLevel;
                @RestartLevel.canceled += instance.OnRestartLevel;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnSpellCast(InputAction.CallbackContext context);
        void OnSave(InputAction.CallbackContext context);
        void OnLoadLastSave(InputAction.CallbackContext context);
        void OnRestartLevel(InputAction.CallbackContext context);
    }
}
