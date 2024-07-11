using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 InputVec;

    public void OnMove(InputValue value)
    {
        InputVec = value.Get<Vector2>();
    }
}

