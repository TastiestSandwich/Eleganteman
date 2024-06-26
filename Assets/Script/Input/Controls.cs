//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Script/Input/Controls.inputactions
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

public partial class @Controls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""ade48799-4d9a-46a4-aab5-6dc30fb51e68"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""fdb0db9c-2391-4d41-836d-5e12029c8372"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""d3555165-bbee-4721-bb7b-c8cc68b11c9c"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""HatThrow"",
                    ""type"": ""Button"",
                    ""id"": ""f391a3ce-e2da-4427-a4ad-f3318b6f4029"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=2)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""BowtieDash"",
                    ""type"": ""Button"",
                    ""id"": ""07a1d89d-81eb-44fa-9057-2e68325b5a2d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Direction"",
                    ""type"": ""PassThrough"",
                    ""id"": ""660d60c9-1f63-4766-af33-98dcf9f0e4ad"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""BowtieShield"",
                    ""type"": ""Button"",
                    ""id"": ""83e85fea-579d-4c22-a383-5a02ef054e5f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=2)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""HatTeleport"",
                    ""type"": ""Button"",
                    ""id"": ""0de87b21-f17c-46d7-981e-122791578e73"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TieAttack"",
                    ""type"": ""Button"",
                    ""id"": ""e9b0bed4-f80e-47a5-975f-6dfe344a94e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""EleganceModifier"",
                    ""type"": ""Button"",
                    ""id"": ""b13e01ac-84b6-468b-ac69-987a528d3953"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""EleganceValue"",
                    ""type"": ""Value"",
                    ""id"": ""5ba6d403-1931-4e61-9d9e-c64794f88e2e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MenuMove"",
                    ""type"": ""Value"",
                    ""id"": ""2f5dfa9e-b45a-42ec-b3be-e1f321698816"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MenuOk"",
                    ""type"": ""Button"",
                    ""id"": ""b7fa0b7c-e9f3-4622-8e08-e1e4163cc4e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7c099882-f4a8-4a2f-83b3-af6588bfc5dc"",
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
                    ""id"": ""252365d9-a226-45f4-a247-ec4aa435e947"",
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
                    ""id"": ""e33d90aa-3296-4c9a-94fa-5b9e9b43b263"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""1543b19d-f1b4-48a9-ac26-5a85ea49f445"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""227f5052-153c-4b61-833f-1def9cea5924"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""948b21da-0bab-47e3-b73b-32605e15d757"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""092ecb6b-7d66-45f0-a2c4-1f1330970586"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""HatThrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""abbdff2e-c410-4843-8a95-7213c5cbab24"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HatThrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""297e402a-f6d0-4be0-b597-e420300ce60f"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""BowtieDash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2884e6c4-11a7-4d23-b97f-f02a4ea4980c"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""BowtieDash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""948ae158-a0fc-494a-ae6d-7694f59cc57f"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""b7771c66-74be-4df0-9408-da6c85d98c7e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direction"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ddd104a5-16db-49be-82f5-dd0329fe6e04"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e281d698-252b-45a1-b519-ee923bc7a097"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""77d5a93d-c853-4f0d-884b-2371945ab626"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3b6cd75d-e06c-4a27-8b30-f6ad9e442c5f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3ba922d1-a93a-4c8c-9743-6d11328e9cf3"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""BowtieShield"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ebe37517-14a0-4b75-ab8c-8e9a28439699"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""BowtieShield"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72ee0bb2-255d-4a7a-be32-aa40ad96ad94"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""HatTeleport"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb98757a-9425-4883-88ad-723adb180b50"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""HatTeleport"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4f31d0d-b58f-4109-ba62-e839718df099"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""TieAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a11079ec-3897-4d43-afb4-3b50b1dcc24d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""TieAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2738dc75-dac0-44f5-aca7-3a75ef40f771"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""EleganceModifier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11092f43-7117-41b7-ae2e-1747dad5a09d"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""EleganceModifier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c51a674b-e641-4ab7-85c8-fa0f2536730c"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""EleganceValue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4df97a84-151e-4a8d-8bb4-549c68372f35"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MenuMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc044120-0afa-4963-92dd-5e9dfb81996e"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MenuMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""b3fdea17-ec48-4a5e-8a8b-dadcfc2f5850"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1992f29b-bfe5-4954-b099-8583b809f24e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MenuMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8e35c913-b7da-4d31-8b57-e63c6ab3d9bd"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MenuMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fa401c0a-243e-4fbe-beb7-02e0d0cec3f7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MenuMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""00c6e1d2-cb65-451a-9f65-fece70524d7e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MenuMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5dad1ecc-7793-4e21-902b-6195ffd466a0"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MenuOk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13465b89-21e6-4f84-acfb-be2e68ca1f45"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuOk"",
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
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_HatThrow = m_Player.FindAction("HatThrow", throwIfNotFound: true);
        m_Player_BowtieDash = m_Player.FindAction("BowtieDash", throwIfNotFound: true);
        m_Player_Direction = m_Player.FindAction("Direction", throwIfNotFound: true);
        m_Player_BowtieShield = m_Player.FindAction("BowtieShield", throwIfNotFound: true);
        m_Player_HatTeleport = m_Player.FindAction("HatTeleport", throwIfNotFound: true);
        m_Player_TieAttack = m_Player.FindAction("TieAttack", throwIfNotFound: true);
        m_Player_EleganceModifier = m_Player.FindAction("EleganceModifier", throwIfNotFound: true);
        m_Player_EleganceValue = m_Player.FindAction("EleganceValue", throwIfNotFound: true);
        m_Player_MenuMove = m_Player.FindAction("MenuMove", throwIfNotFound: true);
        m_Player_MenuOk = m_Player.FindAction("MenuOk", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_HatThrow;
    private readonly InputAction m_Player_BowtieDash;
    private readonly InputAction m_Player_Direction;
    private readonly InputAction m_Player_BowtieShield;
    private readonly InputAction m_Player_HatTeleport;
    private readonly InputAction m_Player_TieAttack;
    private readonly InputAction m_Player_EleganceModifier;
    private readonly InputAction m_Player_EleganceValue;
    private readonly InputAction m_Player_MenuMove;
    private readonly InputAction m_Player_MenuOk;
    public struct PlayerActions
    {
        private @Controls m_Wrapper;
        public PlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @HatThrow => m_Wrapper.m_Player_HatThrow;
        public InputAction @BowtieDash => m_Wrapper.m_Player_BowtieDash;
        public InputAction @Direction => m_Wrapper.m_Player_Direction;
        public InputAction @BowtieShield => m_Wrapper.m_Player_BowtieShield;
        public InputAction @HatTeleport => m_Wrapper.m_Player_HatTeleport;
        public InputAction @TieAttack => m_Wrapper.m_Player_TieAttack;
        public InputAction @EleganceModifier => m_Wrapper.m_Player_EleganceModifier;
        public InputAction @EleganceValue => m_Wrapper.m_Player_EleganceValue;
        public InputAction @MenuMove => m_Wrapper.m_Player_MenuMove;
        public InputAction @MenuOk => m_Wrapper.m_Player_MenuOk;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @HatThrow.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHatThrow;
                @HatThrow.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHatThrow;
                @HatThrow.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHatThrow;
                @BowtieDash.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBowtieDash;
                @BowtieDash.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBowtieDash;
                @BowtieDash.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBowtieDash;
                @Direction.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDirection;
                @Direction.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDirection;
                @Direction.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDirection;
                @BowtieShield.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBowtieShield;
                @BowtieShield.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBowtieShield;
                @BowtieShield.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBowtieShield;
                @HatTeleport.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHatTeleport;
                @HatTeleport.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHatTeleport;
                @HatTeleport.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHatTeleport;
                @TieAttack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTieAttack;
                @TieAttack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTieAttack;
                @TieAttack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTieAttack;
                @EleganceModifier.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEleganceModifier;
                @EleganceModifier.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEleganceModifier;
                @EleganceModifier.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEleganceModifier;
                @EleganceValue.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEleganceValue;
                @EleganceValue.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEleganceValue;
                @EleganceValue.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEleganceValue;
                @MenuMove.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenuMove;
                @MenuMove.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenuMove;
                @MenuMove.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenuMove;
                @MenuOk.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenuOk;
                @MenuOk.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenuOk;
                @MenuOk.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenuOk;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @HatThrow.started += instance.OnHatThrow;
                @HatThrow.performed += instance.OnHatThrow;
                @HatThrow.canceled += instance.OnHatThrow;
                @BowtieDash.started += instance.OnBowtieDash;
                @BowtieDash.performed += instance.OnBowtieDash;
                @BowtieDash.canceled += instance.OnBowtieDash;
                @Direction.started += instance.OnDirection;
                @Direction.performed += instance.OnDirection;
                @Direction.canceled += instance.OnDirection;
                @BowtieShield.started += instance.OnBowtieShield;
                @BowtieShield.performed += instance.OnBowtieShield;
                @BowtieShield.canceled += instance.OnBowtieShield;
                @HatTeleport.started += instance.OnHatTeleport;
                @HatTeleport.performed += instance.OnHatTeleport;
                @HatTeleport.canceled += instance.OnHatTeleport;
                @TieAttack.started += instance.OnTieAttack;
                @TieAttack.performed += instance.OnTieAttack;
                @TieAttack.canceled += instance.OnTieAttack;
                @EleganceModifier.started += instance.OnEleganceModifier;
                @EleganceModifier.performed += instance.OnEleganceModifier;
                @EleganceModifier.canceled += instance.OnEleganceModifier;
                @EleganceValue.started += instance.OnEleganceValue;
                @EleganceValue.performed += instance.OnEleganceValue;
                @EleganceValue.canceled += instance.OnEleganceValue;
                @MenuMove.started += instance.OnMenuMove;
                @MenuMove.performed += instance.OnMenuMove;
                @MenuMove.canceled += instance.OnMenuMove;
                @MenuOk.started += instance.OnMenuOk;
                @MenuOk.performed += instance.OnMenuOk;
                @MenuOk.canceled += instance.OnMenuOk;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
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
    public interface IPlayerActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnHatThrow(InputAction.CallbackContext context);
        void OnBowtieDash(InputAction.CallbackContext context);
        void OnDirection(InputAction.CallbackContext context);
        void OnBowtieShield(InputAction.CallbackContext context);
        void OnHatTeleport(InputAction.CallbackContext context);
        void OnTieAttack(InputAction.CallbackContext context);
        void OnEleganceModifier(InputAction.CallbackContext context);
        void OnEleganceValue(InputAction.CallbackContext context);
        void OnMenuMove(InputAction.CallbackContext context);
        void OnMenuOk(InputAction.CallbackContext context);
    }
}
