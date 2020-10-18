using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject BulletPrefap;
    public int bulletDelay = 20;
    private int bulletDelayCount = 0;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.position = transform.position + new Vector3(-0.08f, 0);

        if (Input.GetKey(KeyCode.RightArrow))
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
