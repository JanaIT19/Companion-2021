using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    Vector3 mousePosition;
    public float moveSpeed = 0.1f;
    Rigidbody2D rb;
    Vector2 position = new Vector2(0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() 
    {
        if (rb != null)
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

            rb.MovePosition(position);
        }
    }
}
