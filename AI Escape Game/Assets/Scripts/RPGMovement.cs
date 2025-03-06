using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGMovement : MonoBehaviour
{
    //Movement speed (in units per second)
    public float moveSpeed;

    //Vector for storing inputs
    private Vector2 _inputVector;

    private Rigidbody2D _rb2d;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (_inputVector.magnitude != 0f)
        {
            _animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
            _animator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
        }

        _animator.SetFloat("Speed", _inputVector.magnitude * moveSpeed);
    }

    void FixedUpdate()
    {
        _rb2d.MovePosition((Vector2)transform.position + _inputVector * moveSpeed * Time.deltaTime);
    }
}
