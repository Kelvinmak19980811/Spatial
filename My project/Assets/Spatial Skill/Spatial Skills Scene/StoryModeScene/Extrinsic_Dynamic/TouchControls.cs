// GENERATED AUTOMATICALLY FROM 'Assets/Spatial Skill/Spatial Skills Scene/StoryModeScene/Extrinsic_Dynamic/TouchControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TouchControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TouchControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TouchControls"",
    ""maps"": [
        {
            ""name"": ""TouchInput"",
            ""id"": ""c38c3a1b-c73e-4d34-8ee2-b9b261a15187"",
            ""actions"": [
                {
                    ""name"": ""Touch"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9a1724df-bebe-4b31-81c0-0a8a7e7faa8c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""246f4e06-ee0e-4163-b827-63811b60beae"",
                    ""path"": ""<Touchscreen>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // TouchInput
        m_TouchInput = asset.FindActionMap("TouchInput", throwIfNotFound: true);
        m_TouchInput_Touch = m_TouchInput.FindAction("Touch", throwIfNotFound: true);
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

    // TouchInput
    private readonly InputActionMap m_TouchInput;
    private ITouchInputActions m_TouchInputActionsCallbackInterface;
    private readonly InputAction m_TouchInput_Touch;
    public struct TouchInputActions
    {
        private @TouchControls m_Wrapper;
        public TouchInputActions(@TouchControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Touch => m_Wrapper.m_TouchInput_Touch;
        public InputActionMap Get() { return m_Wrapper.m_TouchInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchInputActions set) { return set.Get(); }
        public void SetCallbacks(ITouchInputActions instance)
        {
            if (m_Wrapper.m_TouchInputActionsCallbackInterface != null)
            {
                @Touch.started -= m_Wrapper.m_TouchInputActionsCallbackInterface.OnTouch;
                @Touch.performed -= m_Wrapper.m_TouchInputActionsCallbackInterface.OnTouch;
                @Touch.canceled -= m_Wrapper.m_TouchInputActionsCallbackInterface.OnTouch;
            }
            m_Wrapper.m_TouchInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Touch.started += instance.OnTouch;
                @Touch.performed += instance.OnTouch;
                @Touch.canceled += instance.OnTouch;
            }
        }
    }
    public TouchInputActions @TouchInput => new TouchInputActions(this);
    public interface ITouchInputActions
    {
        void OnTouch(InputAction.CallbackContext context);
    }
}
