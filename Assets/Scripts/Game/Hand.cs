using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Transform HandMesh; //removed mHandMesh; 

    private void Update()
    {
        HandMesh.position = Vector3.Lerp(HandMesh.position, transform.position, Time.deltaTime * 15.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (!collision.gameObject.CompareTag("Bubble"))
            return;

        Bubble bubble = collision.gameObject.GetComponent<Bubble>();
        StartCoroutine(bubble.Pop());
    }
}
