using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPoint : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpawnBox.instance.RespawnBox();
            Destroy(transform.parent.gameObject);
        }
    }
}
