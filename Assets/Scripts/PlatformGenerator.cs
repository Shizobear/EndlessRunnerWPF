using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public GameObject platform;
    public Transform generationPoint;
    public float distanceBetween;
    private float platformWidth;

    public float distanceBetweenMin, distanceBetweenMax;

	public ObjectPooler objPooler;

    private void Awake()
    {
        platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
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
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

            GameObject newPlatform = objPooler.GetObjectFromPool();

			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive(true);
        }
    }

}
