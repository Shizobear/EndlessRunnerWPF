using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{

    // Use this for initialization
    public ObjectPooler coinPool;

    public float distanceBetweenCoins;

    public void SpawnCoin(Vector3 position)
    {

        GameObject coin2 = coinPool.GetObjectFromPool();
        coin2.transform.position = new Vector3(position.x - distanceBetweenCoins, position.y, position.z);
        coin2.SetActive(true);
		
    }
}
