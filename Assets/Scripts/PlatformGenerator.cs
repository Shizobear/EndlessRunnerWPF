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

    private void Awake()
    {
        platformWidthArray = new float[objPoolerArray.Length];

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

            transform.position = new Vector3(transform.position.x + (platformWidthArray[platformSelector] / 2) + distanceBetween, heigthChange, transform.position.z);

            
            if (platformSelector == objPoolerArray.Length)
            {
                platformSelector = objPoolerArray.Length - 1;
            }

            GameObject newPlatform = objPoolerArray[platformSelector].GetObjectFromPool();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

			transform.position = new Vector3(transform.position.x + (platformWidthArray[platformSelector] / 2), transform.position.y, transform.position.z);
        }
    }

}
