using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWallSpawner : MonoBehaviour
{
    [SerializeField] private Camera camera;
    private BackgroundScroller controller;

    private void Start()
    {
        controller = camera.GetComponent<BackgroundScroller>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Wall")
        {
            controller.SpawnWall();
        }
    }
}
