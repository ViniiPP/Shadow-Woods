using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    struct SpawnTime
    {
        public float instantiateTime;
        public float interval;
        public float intervalVariation;
    }

    public Sprite[] cactusSprites;

    public GameObject cactusPrefabRef;
    public GameObject flyPrefabRef;

    SpawnTime cactus;
    SpawnTime Fly;

    public bool stopSpawning = false;

    float flyMaxHeight = 2;
    float flyMinHeight = -1;

    void Start()
    {
        cactus.instantiateTime = 0;
        cactus.interval = 2;
        cactus.intervalVariation = 0.5f;

        Fly.instantiateTime = 0;
        Fly.interval = 2;
        Fly.intervalVariation = 0.5f;
    }


    void Update()
    {
        // spawn do cacto
        if (Time.time >= cactus.instantiateTime && !stopSpawning)
        {
            GameObject obj = Instantiate(cactusPrefabRef, new Vector3(5, -0.7f), Quaternion.identity);
            obj.GetComponent<SpriteRenderer>().sprite = cactusSprites[Random.Range(0, cactusSprites.Length)];
            obj.AddComponent<BoxCollider2D>();
            cactus.instantiateTime = Time.time + Random.Range(cactus.interval - cactus.intervalVariation, cactus.interval + cactus.intervalVariation);
        }

        // spawn do passaro
        if (Time.time >= Fly.instantiateTime && !stopSpawning)
        {
            GameObject obj = Instantiate(flyPrefabRef, new Vector3(5, Random.Range(flyMaxHeight, flyMinHeight)), Quaternion.identity);
            Fly.instantiateTime = Time.time + Random.Range(Fly.interval - Fly.intervalVariation, Fly.interval + Fly.intervalVariation);
        }
    }
}
