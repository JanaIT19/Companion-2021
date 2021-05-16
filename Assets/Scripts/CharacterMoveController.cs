using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //adds component if it doesn't exist; doesn't allow to remove component from game object
public class CharacterMoveController : MonoBehaviour
{
    [Range (0f, 20f)]
    public float MoveSpeed = 5f;

    private Rigidbody2D _rigidBody;
    private bool _isFacingRight = true;
    private Animator _animator;
    // Start is called before the first frame update
    private void Awake() 
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate() 
    {
        float velocity = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        _animator.SetFloat("Speed", Mathf.Abs(velocity));
        if ((!_isFacingRight && velocity > 0) || (_isFacingRight && velocity < 0))
        {
            Flip();
        }
        _rigidBody.velocity = new Vector2(velocity, _rigidBody.velocity.y);
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        var playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }
}
