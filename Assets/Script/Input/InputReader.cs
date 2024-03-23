using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    public float MoveAxis;

    public Vector2 Direction;
    public float MoveDeadzone = 0.05f;
    public float JoystickDeadzone = 0.35f;
    public bool isEleganceMod = false;
    public float EleganceValue = 0;

    public Action OnJumpStarted;
    public Action OnJumpCanceled;

    public Action OnHatThrowHold;
    public Action OnHatThrowRelease;

    public Action OnBowtieDashStarted;
    public Action OnBowtieShieldHold;
    public Action OnBowtieShieldRelease;

    public Action OnHatTeleportStarted;

    public Action OnTieAttackStarted;
    public Action OnTieAttackCanceled;

    public Action OnEleganceModHold;
    public Action OnEleganceModRelease;

    public Action OnMenuUp;
    public Action OnMenuDown;
    public Action OnMenuLeft;
    public Action OnMenuRight;

    public Action OnMenuOkStarted;

    private Controls controls;

    private void OnEnable()
    {
        if (controls != null)
            return;

        controls = new Controls();
        controls.Player.SetCallbacks(this);
        controls.Player.Enable();
    }

    public void OnDisable()
    {
        controls.Player.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        float axis = context.ReadValue<float>();
        MoveAxis = GetClampMove(axis);
    }

    private float GetClampMove(float axis)
    {
        if (axis > MoveDeadzone) return 1;
        if (axis < -1 * MoveDeadzone) return -1;
        return axis;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
            OnJumpStarted?.Invoke();
        else if (context.canceled)
            OnJumpCanceled?.Invoke();
    }

    public void OnHatThrow(InputAction.CallbackContext context)
    {
        if (context.started)
            OnHatThrowHold?.Invoke();
        else if (context.canceled)
            OnHatThrowRelease?.Invoke();
    }

    public void OnBowtieDash(InputAction.CallbackContext context)
    {
        if (context.started)
            OnBowtieDashStarted?.Invoke();
    }

    public void OnDirection(InputAction.CallbackContext context)
    {
        Direction = context.ReadValue<Vector2>();
    }

    public Vector2 GetClampedDirection()
    {
        Vector2 dir = Vector2.zero;

        if (Direction.x > 0 || Direction.x < 0)
        {
            dir.x = ApplyDeadzone(Direction.x);
        }
        if (Direction.y > 0 || Direction.y < 0)
        {
            dir.y = ApplyDeadzone(Direction.y);
        }

        dir.Normalize();
        return dir;
    }

    public Vector2 GetClampedFacingDirection(int facing)
    {
        Vector2 dir = Vector2.zero;

        // if x is aligned with facing we do nothing else
        if (Direction.x * facing > 0)
            return GetClampedDirection();

        // if x is opposite to facing, x is zero and y is either up or down
        dir.y = Direction.y;
        dir.Normalize();
        return dir;
    }

    private float ApplyDeadzone(float axis)
    {
        if (axis > JoystickDeadzone) return 1;
        if (axis < -1 * JoystickDeadzone) return -1;
        return 0;
    }

    public void OnBowtieShield(InputAction.CallbackContext context)
    {
        if (context.started)
            OnBowtieShieldHold?.Invoke();
        else if (context.canceled)
            OnBowtieShieldRelease?.Invoke();
    }

    public void OnHatTeleport(InputAction.CallbackContext context)
    {
        if (context.started)
            OnHatTeleportStarted?.Invoke();
    }

    public void OnTieAttack(InputAction.CallbackContext context)
    {
        if (context.started)
            OnTieAttackStarted?.Invoke();
        else if (context.canceled)
            OnTieAttackCanceled?.Invoke();
    }

    public void OnEleganceModifier(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            OnEleganceModHold?.Invoke();
            isEleganceMod = true;
        }
        else if (context.canceled)
        {
            OnEleganceModRelease?.Invoke();
            isEleganceMod = false;
        }
    }

    public void OnEleganceValue(InputAction.CallbackContext context)
    {
        if (context.canceled)
            EleganceValue = 0;
        else
            EleganceValue = context.ReadValue<float>();
    }

    public void OnMenuMove(InputAction.CallbackContext context)
    {
        if (!context.started)
            return;

        Vector2 menuMove = context.ReadValue<Vector2>();
        if (menuMove.x > 0)
            OnMenuRight?.Invoke();
        if (menuMove.x < 0)
            OnMenuLeft?.Invoke();
        if (menuMove.y > 0)
            OnMenuUp?.Invoke();
        if (menuMove.y < 0)
            OnMenuDown?.Invoke();
    }

    public void OnMenuOk(InputAction.CallbackContext context)
    {
        if (context.started)
            OnMenuOkStarted?.Invoke();
    }
}
