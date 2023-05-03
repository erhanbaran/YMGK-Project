using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        Destroy(gameObject,0.4f);
    }
}
