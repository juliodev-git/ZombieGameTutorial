using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    #region InitializeInput
    private DefaultInputActions _input;

    private void Awake()
    {
        _input = new DefaultInputActions();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }
    #endregion InitializeInput

    const float SPEED = 30.0f;

    private Transform _cam;

    private Rigidbody _rb;
    private Vector3 _movement;
    private Vector2 _stick;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        _stick = _input.Player.Move.ReadValue<Vector2>();

        _movement = new Vector3(_stick.x, 0.0f, _stick.y);
    }

    private void FixedUpdate()
    {
        //apply a force to the rigidbody in the direction the player is holding the joystick (or WASD) relative to the camera
        Move(Quaternion.Euler(0.0f, _cam.rotation.eulerAngles.y, 0.0f) * _movement);
    }

    public void Move(Vector3 direction) {
        _rb.AddForce(direction * SPEED);
    }
}
