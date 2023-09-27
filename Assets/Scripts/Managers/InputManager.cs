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

        _gameControls.InGame.Movement.performed += move => 
        {
            myPlayer.SetMovementDirection(move.ReadValue<Vector3>());
        };

        _gameControls.InGame.Jump.performed += jump =>
        {
            Debug.Log("i jumped");
        };

        _gameControls.InGame.Crouch.performed += crouch =>
        {
            Debug.Log("i crouched");
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
