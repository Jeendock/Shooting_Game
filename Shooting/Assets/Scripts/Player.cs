using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject BulletPrefap;
    public int bulletDelay = 20;
    private int bulletDelayCount = 0;

    private float defaultY;

    private void Start()
    {
        defaultY = transform.position.y;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var diff = transform.position.x - worldPosition.x;
            if (Mathf.Abs(diff) < 0.5f)
            {
                transform.position = new Vector2(worldPosition.x, defaultY);
            }
            else
            {
                transform.position = new Vector2(diff / 5.0f, defaultY);
            }
        }

        //if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        //    transform.position = transform.position + new Vector3(-0.08f, 0);

        //if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        //    transform.position = transform.position + new Vector3(0.08f, 0);

        Fire();
    }

    private void Fire()
    {
        bulletDelayCount++;
        if (bulletDelayCount >= bulletDelay)
        {
            var bulletObject = Instantiate(BulletPrefap);
            bulletObject.transform.position = transform.position;
            bulletDelayCount = 0;
        }
    }
}