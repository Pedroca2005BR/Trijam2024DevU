using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPoint : MonoBehaviour
{
    public Buffs Buffs;
    public PlayerMovement PlayerMovement;
    private void Start()
    {
        Buffs = GameObject.FindObjectOfType<Buffs>();
        PlayerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Buffs.buffativar();
            SpawnBox.instance.RespawnBox();
            Destroy(transform.parent.gameObject);
        }
    }
}
