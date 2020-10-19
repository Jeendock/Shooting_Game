using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject BulletPrefap;
    public int bulletDelay = 20;
    private int bulletDelayCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            transform.position = transform.position + new Vector3(-0.08f, 0);

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            transform.position = transform.position + new Vector3(0.08f, 0);

        bulletDelayCount++;
        if (bulletDelayCount >= bulletDelay)
        {
            var bulletObject = Instantiate(BulletPrefap);
            bulletObject.transform.position = transform.position;
            bulletDelayCount = 0;
        }
    }
}
