using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float height;
    [SerializeField]
    private float pauseTime;
    
    private Vector3 copyOfPosition;

    void Start()
    {
        StartCoroutine(MovePosition((transform.position + new Vector3(0, height, 0)), speed));
    }

    IEnumerator MovePosition(Vector3 destination, float speed)
    {
        copyOfPosition = transform.position;
        while (transform.position != destination)
        {
            transform.position = Vector3.Lerp(transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }
        destination = copyOfPosition;
        yield return new WaitForSeconds(pauseTime);
        StartCoroutine(MovePosition(destination, speed));
    }
}
