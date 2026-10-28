using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 12f;
    private CharacterController controller;
    private float xInput;
    private float zInput;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        zInput = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(xInput, 0f, zInput).normalized;
        controller.Move(dir * moveSpeed * Time.deltaTime);
    }
}