using UnityEngine;

public class Enemy : CollisionObject
{
    [SerializeField]
    private int hp = 3;

    private int enemyDataKey;

    private EnemyData enemyData => EnemyData.Get(enemyDataKey);

    private void Awake()
    {
        enemyDataKey = Random.Range(1, EnemyData.All.Length + 1);
        hp = enemyData.Hp;

        MovementVector = new Vector2(0, -0.07f);

        var sprite = Resources.Load<Sprite>($"Images/Enemies/{ enemyData.ImageName}") as Sprite;
        GetComponent<SpriteRenderer>().sprite = sprite;
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
        if (hp <= 0)
        {
            var destroyEffectPrefab = Resources.Load("Prefab/Explosive") as GameObject;
            var enemeyObject = Instantiate(destroyEffectPrefab, transform);

            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            //enemeyObject.transform.position = transform.position;
            //Destroy(gameObject);

            GameHUD.Instance.AddScore(enemyData.Score);

            Invoke("DestroySelf", 0.4f);
        }
    }

    private void DestorySelf()
    {
        Destroy(gameObject);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
    }
}