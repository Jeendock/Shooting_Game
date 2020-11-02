using UnityEngine;

public class Enemy : CollisionObject
{
    [SerializeField]
    private int hp = 3;

    private void Start()
    {
        MovementVector = new Vector2(0, -0.07f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Destroy(collision.gameObject);
        }
    }

    public void DecreaseHP(int value = 1)
    {
        hp -= value;
        if (hp == 0)
        {
            var destroyEffectPrefab = Resources.Load("Prefab/Explosive") as GameObject;
            var enemeyObject = Instantiate(destroyEffectPrefab, transform);

            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            //enemeyObject.transform.position = transform.position;
            //Destroy(gameObject);

            Invoke("DestroySelf", 0.4f);
        }
    }

    private void DestorySelf()
    {
        Destroy(gameObject);
    }
}