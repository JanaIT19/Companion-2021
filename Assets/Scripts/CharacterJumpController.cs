using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterJumpController : MonoBehaviour
{
    [Range (0f, 20f)]
    public float JumpForce = 5f;
    public LayerMask GroundLayer;
    public Transform GroundCheck;
    public float GroundCheckRadius;

    private bool _isGrounded;
    private Rigidbody2D _rigidBody;
    private Animator _animator;
    private EventManager _eventManager;

    // Start is called before the first frame update
    private void Awake() 
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        _eventManager = FindObjectOfType<EventManager>();
    }

    private void Update() 
    {
        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, JumpForce ); //addforce would sum up values and make it look weird
            _eventManager?.OnPlayerJump.Invoke();
        }
    }

    private void FixedUpdate() 
    {
        _isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, GroundLayer);
        _animator.SetBool("IsJumping", !_isGrounded);
    }
}
