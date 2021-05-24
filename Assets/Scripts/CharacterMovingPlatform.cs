using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovingPlatform : MonoBehaviour
{
    public LayerMask MovingPlatformLayer;
    public Transform PlatformCheck;
    public float PlatformCheckRadius;

    private bool _isOnPlatform = false;
    private int _parentID = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        var platformCollider = Physics2D.OverlapCircle(PlatformCheck.position, PlatformCheckRadius, MovingPlatformLayer);
        ChangePlayerParent(platformCollider == null ? null : platformCollider.gameObject);
    }

    private void ChangePlayerParent(GameObject parentObject)
    {
        if (parentObject == null && _parentID == -1)
        {
            return;
        }

        if(parentObject != null && parentObject.GetInstanceID() == _parentID)
        {
            return;
        }
        Debug.Log(parentObject);
        _parentID = parentObject == null ? -1 : parentObject.GetInstanceID();
        transform.parent = parentObject == null ? null : parentObject.transform;
    }
}
