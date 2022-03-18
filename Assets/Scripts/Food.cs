using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public void DestroyAfterDelay(int time)
    {
        Invoke("SpawnFood", time);
        Destroy(gameObject, time);
    }

    void SpawnFood()
    {
        GameManager.Instance.SpawnFoodItem();
    }
}
