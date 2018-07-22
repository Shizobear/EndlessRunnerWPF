using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public GameObject platform;
    public Transform generationPoint;
    public float distanceBetween;
    private float platformWidth;

    //public GameObject[] objPoolerArray;
    private float[] platformWidthArray;
    private int platformSelector;

    public float distanceBetweenMin, distanceBetweenMax;

    public ObjectPooler[] objPoolerArray;

    private float minHeight, maxHeight, heigthChange;
    public float maxHeightChange;

    public Transform maxHeightPoint;

    private CoinGenerator coinGenerator;
    public float coinThreshold;

    public ObjectPooler spikePool;
    public float spikeThreshold;

    private void Awake()
    {
        platformWidthArray = new float[objPoolerArray.Length];
        coinGenerator = FindObjectOfType<CoinGenerator>();

        for (int i = 0; i < objPoolerArray.Length; i++)
        {
            platformWidthArray[i] = objPoolerArray[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

    }

    private void Start()
    {
        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        CreatePlatform();

    }

    private void CreatePlatform()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            platformSelector = Random.Range(0, objPoolerArray.Length);

            heigthChange = transform.position.y + Random.Range(-maxHeightChange, maxHeightChange);

            heigthChange = Mathf.Clamp(heigthChange, minHeight, maxHeight);

            transform.position = new Vector3(transform.position.x + (platformWidthArray[platformSelector] / 2f) + distanceBetween, heigthChange, transform.position.z);


            if (platformSelector == objPoolerArray.Length)
            {
                platformSelector = objPoolerArray.Length - 1;
            }

            GameObject newPlatform = objPoolerArray[platformSelector].GetObjectFromPool();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if (Random.Range(0, 100) < coinThreshold)
            {
                int coinCount = Random.Range(0, 4);
                float coinHeight = Random.Range(1f, 3f);

                if (coinCount > 2 && coinCount <= 3)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        coinGenerator.SpawnCoin(new Vector3(transform.position.x + ((float)i * coinGenerator.distanceBetweenCoins), transform.position.y + coinHeight, transform.position.z));
                    }
                }
                else if (coinCount > 1 && coinCount <= 2)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        coinGenerator.SpawnCoin(new Vector3(transform.position.x + ((float)i * coinGenerator.distanceBetweenCoins), transform.position.y + coinHeight, transform.position.z));
                    }
                }
                else
                {
                    for (int i = 0; i < 1; i++)
                    {
                        coinGenerator.SpawnCoin(new Vector3(transform.position.x + ((float)i * coinGenerator.distanceBetweenCoins), transform.position.y + coinHeight, transform.position.z));
                    }
                }
            }

            if(Random.Range(0, 100) < spikeThreshold) {
                GameObject spike = spikePool.GetObjectFromPool();

                float spikeXPosition = Random.Range(-platformWidthArray[platformSelector] / 2 + 1f, platformWidthArray[platformSelector] / 2 - 1.2f);
                
                Vector3 spikePosition = new Vector3 (spikeXPosition, 0.5f, 0f);

                spike.transform.position = transform.position + spikePosition;
                spike.transform.rotation = transform.rotation;
                spike.SetActive(true);

            }
            transform.position = new Vector3(transform.position.x + (platformWidthArray[platformSelector] / 2), transform.position.y, transform.position.z);
        }
    }

}
