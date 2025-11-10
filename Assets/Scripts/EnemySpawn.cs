using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    struct SpawnTime
    {
        public float instantiateTime;
        public float interval;
        public float intervalVariation;
    }

    [Header("Referências")]
    public Dino dino;
    public Sprite[] cactusSprites;
    public GameObject cactusPrefabRef;
    public GameObject flyPrefabRef;

    [Header("Configurações de Spawn")]
    public float birdOffsetY = 0.5f;
    public bool stopSpawning = false;

    SpawnTime cactus;
    SpawnTime Fly;

    void Start()
    {
        // Tenta encontrar o Dino automaticamente se não foi atribuído
        if (dino == null) dino = FindFirstObjectByType<Dino>();

        cactus.instantiateTime = 0;
        cactus.interval = 2;
        cactus.intervalVariation = 0.5f;

        Fly.instantiateTime = 0;
        Fly.interval = 2;
        Fly.intervalVariation = 0.5f;
    }

    void Update()
    {
        if (stopSpawning) return;
        if (ManageMap.Instance.GetCurrentMap() == MapList.TransitionMap) return;


        // spawn do cacto
        if (Time.time >= cactus.instantiateTime)
        {
            GameObject obj = Instantiate(cactusPrefabRef, new Vector3(5, -0.7f), Quaternion.identity);

            if (obj.GetComponent<SpriteRenderer>() != null && cactusSprites.Length > 0)
                obj.GetComponent<SpriteRenderer>().sprite = cactusSprites[Random.Range(0, cactusSprites.Length)];

            if (obj.GetComponent<BoxCollider2D>() == null)
                obj.AddComponent<BoxCollider2D>();

            cactus.instantiateTime = Time.time + Random.Range(cactus.interval - cactus.intervalVariation, cactus.interval + cactus.intervalVariation);
        }

        // spawn do passaro
        if (Time.time >= Fly.instantiateTime)
        {
            // Define a altura baseada na posição do Dino
            float spawnY = 0;
            if (dino != null)
            {
                // Pega a altura atual do Dino e soma o ajuste
                spawnY = dino.transform.position.y + birdOffsetY;
            }
            else
            {
                spawnY = Random.Range(0f, 2f); // Altura aleatória caso não ache o Dino
                ;
            }

            Instantiate(flyPrefabRef, new Vector3(5, spawnY), Quaternion.identity);

            Fly.instantiateTime = Time.time + Random.Range(Fly.interval - Fly.intervalVariation, Fly.interval + Fly.intervalVariation);
        }
    }
}