using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoinScript : MonoBehaviour
{
    public GameObject theCoin;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0f, 1f, 0f, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Vector3 randomPosition = new Vector3(Random.Range(-5, 5), 1, Random.Range(-5, 5));
            Instantiate(theCoin, randomPosition, Quaternion.identity);
        }
    }
}
