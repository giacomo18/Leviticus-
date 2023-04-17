using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxMovement : MonoBehaviour
{
    private Camera mainCamera;

    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        FollowMousePosition();
    }

    private void FollowMousePosition()
    {
        transform.position = GetWorldPositionFromMouse();
    }

    private Vector2 GetWorldPositionFromMouse()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}
