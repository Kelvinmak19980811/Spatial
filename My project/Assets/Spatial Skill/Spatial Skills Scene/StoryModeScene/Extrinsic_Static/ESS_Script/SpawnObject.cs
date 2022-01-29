using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject FoodPrefab;

    public Vector3 center;
    public Vector2 size;


    // Start is called before the first frame update
    void Start()
    {
        SpawnFood();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            SpawnFood();
        }
    }

    public void SpawnFood()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2 , size.x / 2), transform.position.y , Random.Range(-transform.position.z / 2, transform.position.z / 2) );
        Instantiate(FoodPrefab, pos, Quaternion.identity);
    }

    void OnDrawGimosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
