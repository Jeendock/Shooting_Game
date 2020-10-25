using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public abstract class CollisionObject : MonoBehaviour
{
    public Vector2 MovementVector;

    private void Update()
    {
        transform.Translate(MovementVector);
    }
}