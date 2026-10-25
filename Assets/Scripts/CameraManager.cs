using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float Sensitivity = 1f;
    public float smoothness = 1f;

    Vector2 mousePos = Vector2.zero;
    Vector2 smoothRotation = Vector2.zero;
    Vector2 targetRotation = Vector2.zero;

    public GameObject player;

    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
    }
    void LateUpdate()
    {
        float mouseX = Input.GetAxisRaw("Mouse Y") * Sensitivity;
        float mouseY = Input.GetAxisRaw("Mouse X") * Sensitivity;

        targetRotation.x -= mouseX;
        targetRotation.x = Mathf.Clamp(targetRotation.x, -90f, 90f);
        targetRotation.y += mouseY;

        smoothRotation.x = Mathf.Lerp(smoothRotation.x, targetRotation.x, smoothness);
        smoothRotation.y = Mathf.Lerp(smoothRotation.y, targetRotation.y, smoothness);

        transform.rotation = Quaternion.Euler(smoothRotation.x, smoothRotation.y, 0);
        player.transform.localRotation = Quaternion.Euler(0, smoothRotation.y, 0);
    }
}



