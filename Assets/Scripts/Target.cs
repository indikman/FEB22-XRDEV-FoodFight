using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Target : MonoBehaviour
{
    public BoxCollider area;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        var foodStuff = collision.gameObject.GetComponent<XRGrabInteractable>();

        if(foodStuff != null && GameManager.Instance.isGame())
        {
            Destroy(collision.gameObject);
            ChangeRandomPosition();

            GameManager.Instance.AddScore();
            GameManager.Instance.SpawnFoodItem();
        }
    }

    private void ChangeRandomPosition()
    {
        float x = Random.Range(area.bounds.min.x, area.bounds.max.x);
        float y = Random.Range(area.bounds.min.y, area.bounds.max.y);
        float z = Random.Range(area.bounds.min.z, area.bounds.max.z);

        transform.position = new Vector3(x, y, z);
    }
}
