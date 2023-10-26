using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{

    private static GameControls _gameControls;
    
    public static void Init(Player myPlayer)
    {
        _gameControls = new GameControls();

        _gameControls.Perm.Enable();

        _gameControls.InGame.Movement.performed += ctx => 
        {
            myPlayer.Move(ctx.ReadValue<Vector3>());
        };

        _gameControls.InGame.Jump.performed += ctx =>
        {
            myPlayer.Jump();
        };

        _gameControls.InGame.Crouch.performed += ctx =>
        {
            Debug.Log("i crouched");
        };

        _gameControls.InGame.ResetCharactor.performed += ctx =>
        {
            myPlayer.ResetCharactor();
        };

        _gameControls.InGame.Look.performed += ctx =>
        {
            myPlayer.SetLookRotation(ctx.ReadValue<Vector2>());
        };

        _gameControls.InGame.Punch.started += ctx =>
        {
            myPlayer.Punch();
        };

    }

    public static void SetGameControls()
    {
        _gameControls.InGame.Enable();
        _gameControls.UI.Disable();
    }

    public static void SetUIControls()
    {
        _gameControls.UI.Enable();
        _gameControls.InGame.Disable();
    }

}
