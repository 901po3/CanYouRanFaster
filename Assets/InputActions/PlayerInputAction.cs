// GENERATED AUTOMATICALLY FROM 'Assets/InputActions/PlayerInputAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputAction : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputAction"",
    ""maps"": [
        {
            ""name"": ""PlayerContols"",
            ""id"": ""17ed4684-9118-49ac-a6a4-fa61959bd62c"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""deae0e34-a084-48ad-8bc5-9a6d8e0524d1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""c6fba327-e73f-4f3c-a793-f7fec9484c25"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DropToHang"",
                    ""type"": ""Button"",
                    ""id"": ""3268e309-529c-4bc0-8508-27f5c96f3078"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""6e6f66a9-ff82-449b-bcc8-a6ec911e46fe"",
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
                    ""id"": ""38d65025-2d87-4ce4-9222-be61b46aeee4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4cb51a7b-fdda-44c6-a6f4-d982bde20001"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""620d3cbe-a50f-400e-aad0-76ffc302eecd"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8d43b2ec-b36a-43a2-b60a-1b40fa6bcf10"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""MoveAxis"",
                    ""id"": ""9457d9ee-9540-41ba-ad52-5b4e61470df3"",
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
                    ""id"": ""fc6628ed-ea5e-43c0-8471-2ada31ca58c6"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""28c2f551-cd4c-4158-a169-139dd8996667"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""612d0ade-c52b-4241-a33c-1055f5770f60"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7017bf7a-b24a-43a8-9e5f-69a91ad976e2"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b1650e2a-115e-4f2c-ba10-681358eac101"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dfe0982b-234a-4f56-92af-6f2647627deb"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""615d53e3-9bf8-410c-aef8-12253a12a011"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""DropToHang"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""507931b6-c2cf-4327-92a1-46d7507781bf"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""DropToHang"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerContols
        m_PlayerContols = asset.FindActionMap("PlayerContols", throwIfNotFound: true);
        m_PlayerContols_Move = m_PlayerContols.FindAction("Move", throwIfNotFound: true);
        m_PlayerContols_Jump = m_PlayerContols.FindAction("Jump", throwIfNotFound: true);
        m_PlayerContols_DropToHang = m_PlayerContols.FindAction("DropToHang", throwIfNotFound: true);
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

    // PlayerContols
    private readonly InputActionMap m_PlayerContols;
    private IPlayerContolsActions m_PlayerContolsActionsCallbackInterface;
    private readonly InputAction m_PlayerContols_Move;
    private readonly InputAction m_PlayerContols_Jump;
    private readonly InputAction m_PlayerContols_DropToHang;
    public struct PlayerContolsActions
    {
        private @PlayerInputAction m_Wrapper;
        public PlayerContolsActions(@PlayerInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerContols_Move;
        public InputAction @Jump => m_Wrapper.m_PlayerContols_Jump;
        public InputAction @DropToHang => m_Wrapper.m_PlayerContols_DropToHang;
        public InputActionMap Get() { return m_Wrapper.m_PlayerContols; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerContolsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerContolsActions instance)
        {
            if (m_Wrapper.m_PlayerContolsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerContolsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerContolsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerContolsActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_PlayerContolsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerContolsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerContolsActionsCallbackInterface.OnJump;
                @DropToHang.started -= m_Wrapper.m_PlayerContolsActionsCallbackInterface.OnDropToHang;
                @DropToHang.performed -= m_Wrapper.m_PlayerContolsActionsCallbackInterface.OnDropToHang;
                @DropToHang.canceled -= m_Wrapper.m_PlayerContolsActionsCallbackInterface.OnDropToHang;
            }
            m_Wrapper.m_PlayerContolsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @DropToHang.started += instance.OnDropToHang;
                @DropToHang.performed += instance.OnDropToHang;
                @DropToHang.canceled += instance.OnDropToHang;
            }
        }
    }
    public PlayerContolsActions @PlayerContols => new PlayerContolsActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IPlayerContolsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDropToHang(InputAction.CallbackContext context);
    }
}
