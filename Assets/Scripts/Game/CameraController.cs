using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    private Touch touch;
    private Vector2 touchPosition;
    private Quaternion rotateZ;
 
    private float rotateSpeedModifire = 0.1f;

    void Update()
    {
        
        if (Input.touchCount > 0)
            touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Moved && !EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
            rotateZ = Quaternion.Euler(0f, 0f, - touch.deltaPosition.x *rotateSpeedModifire );
            transform.rotation = rotateZ * transform.rotation;
        }
    }
}
