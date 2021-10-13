using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputReader _inputReader;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();

        _inputReader.OnJumpEvent += OnJump;
    }

    private void OnJump()
    {
        Debug.Log("OnJumpTest");
    }
}
