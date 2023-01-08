using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsPlayerController : MonoBehaviour
{
    private PlayerMovement player;
    private Rigidbody2D rgb;

    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;

    private void Awake()
    {
        player = GetComponent<PlayerMovement>();
        rgb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("click");
            UseTool();
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void UseTool()
    {
        Vector2 position = rgb.position + player.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            ToolHit hit = c.GetComponent<ToolHit>();
            if (hit != null)
            {
                Debug.Log("hit");
                hit.Hit();
                break;
            }
        }
    }
}
