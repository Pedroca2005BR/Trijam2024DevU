using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPoint : MonoBehaviour
{
    public Buffs Buffs;
    bool hasEntered = false;
    //public PlayerMovement PlayerMovement;
    private void Start()
    {
        Buffs = GameObject.FindObjectOfType<Buffs>();
        //PlayerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasEntered)
        {
            return;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            hasEntered = true;
            Buffs.buffativar();
            SpawnBox.instance.RespawnBox();
            Destroy(transform.parent.gameObject);
        }
    }
}
