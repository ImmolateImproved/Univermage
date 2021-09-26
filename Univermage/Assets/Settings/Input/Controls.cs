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
                },
                {
                    ""name"": ""NextTutorial"",
                    ""type"": ""Button"",
                    ""id"": ""8dcf5d0f-1d58-42bd-a6fd-07520fcab16d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""FreeCamera"",
                    ""type"": ""Button"",
                    ""id"": ""ce84968c-915f-4538-8044-01ec80aeccc5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""de0cc1d0-cd70-46bc-b6ec-2806fd06e585"",
                    ""path"": ""2DVector(mode=1)"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""56ef9036-59b3-4e21-8349-5941046c2db7"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextTutorial"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4b9877b-9ce5-4c73-8e0f-19f3d31617cd"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FreeCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""FreeCamera"",
            ""id"": ""efb0d6ce-ef19-4bb4-8e73-b92101485a9e"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""19a2d3c9-2b1a-48c4-bf1a-a13d7f95d6bf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""d44b6a8c-c602-443e-865d-fdd06a08ee0f"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7ae6d4f0-b04b-47a4-9353-eb8102a21c67"",
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
                    ""id"": ""70e58688-c921-42ef-8012-4a432c99eb1c"",
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
                    ""id"": ""4df8e5fb-66fe-4ada-87f5-90ccbfbd0a16"",
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
                    ""id"": ""75176458-1f32-4d83-8afd-0fa22662c593"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Tutorial"",
            ""id"": ""31352516-5942-4542-b946-d3d3d3dc2c27"",
            ""actions"": [
                {
                    ""name"": ""NextTutorial"",
                    ""type"": ""Button"",
                    ""id"": ""41583991-bcf1-4efd-ba01-91d297309988"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""40f9a9c8-0746-4b78-97b6-bd499edd1a46"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextTutorial"",
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
        m_Player_NextTutorial = m_Player.FindAction("NextTutorial", throwIfNotFound: true);
        m_Player_FreeCamera = m_Player.FindAction("FreeCamera", throwIfNotFound: true);
        // FreeCamera
        m_FreeCamera = asset.FindActionMap("FreeCamera", throwIfNotFound: true);
        m_FreeCamera_Movement = m_FreeCamera.FindAction("Movement", throwIfNotFound: true);
        // Tutorial
        m_Tutorial = asset.FindActionMap("Tutorial", throwIfNotFound: true);
        m_Tutorial_NextTutorial = m_Tutorial.FindAction("NextTutorial", throwIfNotFound: true);
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
    private readonly InputAction m_Player_NextTutorial;
    private readonly InputAction m_Player_FreeCamera;
    public struct PlayerActions
    {
        private @Controls m_Wrapper;
        public PlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @SpellCast => m_Wrapper.m_Player_SpellCast;
        public InputAction @Save => m_Wrapper.m_Player_Save;
        public InputAction @LoadLastSave => m_Wrapper.m_Player_LoadLastSave;
        public InputAction @RestartLevel => m_Wrapper.m_Player_RestartLevel;
        public InputAction @NextTutorial => m_Wrapper.m_Player_NextTutorial;
        public InputAction @FreeCamera => m_Wrapper.m_Player_FreeCamera;
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
                @NextTutorial.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNextTutorial;
                @NextTutorial.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNextTutorial;
                @NextTutorial.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNextTutorial;
                @FreeCamera.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFreeCamera;
                @FreeCamera.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFreeCamera;
                @FreeCamera.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFreeCamera;
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
                @NextTutorial.started += instance.OnNextTutorial;
                @NextTutorial.performed += instance.OnNextTutorial;
                @NextTutorial.canceled += instance.OnNextTutorial;
                @FreeCamera.started += instance.OnFreeCamera;
                @FreeCamera.performed += instance.OnFreeCamera;
                @FreeCamera.canceled += instance.OnFreeCamera;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // FreeCamera
    private readonly InputActionMap m_FreeCamera;
    private IFreeCameraActions m_FreeCameraActionsCallbackInterface;
    private readonly InputAction m_FreeCamera_Movement;
    public struct FreeCameraActions
    {
        private @Controls m_Wrapper;
        public FreeCameraActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_FreeCamera_Movement;
        public InputActionMap Get() { return m_Wrapper.m_FreeCamera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FreeCameraActions set) { return set.Get(); }
        public void SetCallbacks(IFreeCameraActions instance)
        {
            if (m_Wrapper.m_FreeCameraActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_FreeCameraActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_FreeCameraActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_FreeCameraActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_FreeCameraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public FreeCameraActions @FreeCamera => new FreeCameraActions(this);

    // Tutorial
    private readonly InputActionMap m_Tutorial;
    private ITutorialActions m_TutorialActionsCallbackInterface;
    private readonly InputAction m_Tutorial_NextTutorial;
    public struct TutorialActions
    {
        private @Controls m_Wrapper;
        public TutorialActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @NextTutorial => m_Wrapper.m_Tutorial_NextTutorial;
        public InputActionMap Get() { return m_Wrapper.m_Tutorial; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TutorialActions set) { return set.Get(); }
        public void SetCallbacks(ITutorialActions instance)
        {
            if (m_Wrapper.m_TutorialActionsCallbackInterface != null)
            {
                @NextTutorial.started -= m_Wrapper.m_TutorialActionsCallbackInterface.OnNextTutorial;
                @NextTutorial.performed -= m_Wrapper.m_TutorialActionsCallbackInterface.OnNextTutorial;
                @NextTutorial.canceled -= m_Wrapper.m_TutorialActionsCallbackInterface.OnNextTutorial;
            }
            m_Wrapper.m_TutorialActionsCallbackInterface = instance;
            if (instance != null)
            {
                @NextTutorial.started += instance.OnNextTutorial;
                @NextTutorial.performed += instance.OnNextTutorial;
                @NextTutorial.canceled += instance.OnNextTutorial;
            }
        }
    }
    public TutorialActions @Tutorial => new TutorialActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnSpellCast(InputAction.CallbackContext context);
        void OnSave(InputAction.CallbackContext context);
        void OnLoadLastSave(InputAction.CallbackContext context);
        void OnRestartLevel(InputAction.CallbackContext context);
        void OnNextTutorial(InputAction.CallbackContext context);
        void OnFreeCamera(InputAction.CallbackContext context);
    }
    public interface IFreeCameraActions
    {
        void OnMovement(InputAction.CallbackContext context);
    }
    public interface ITutorialActions
    {
        void OnNextTutorial(InputAction.CallbackContext context);
    }
}
