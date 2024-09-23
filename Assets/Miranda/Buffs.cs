using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Buffs : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private int numbuff = 5, op = 0;
    [SerializeField] int tempo = 3;
    //int isfaster = 0;



    private void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }
    

    public void buffativar() {
        
        op = Random.Range(0, 2);
        //op = 0;
        
        if (op == 0)
        {
            //Diminuir velodicade
            Debug.Log("Diminuindo Velocidade");
            playerMovement.SetMoveSpeedSlow(2);
            


        }

        if (op == 1)
        {
            //Aumentar Velocidade
            Debug.Log("Velocidade Aumentada");
            playerMovement.SetMoveSpeedFast(2);
            //StartCoroutine(Countdown(1));
 
        }

        if (op == 2)
        {
            //Pulo Automatico
            Debug.Log("Canguru Mode");
            
                playerMovement.isJumping = true;
                //Countdown(2);
            
        }

        if (op == 3)
        {
            //Pular mais Alto
            Debug.Log("Pulo mais alto");
           
            //Countdown(2);
        }

        if (op == 4)
        {
            //Inverter Controles
            Debug.Log("Inverter controles");

            //Countdown(2);
        }

        StartCoroutine(Countdown(op));



    }
    private void Update()
    {
        
    }


    IEnumerator Countdown(int isfaster)
    {
        //Debug.Log("Entrou Countdown");
        int counter = tempo;
        while (counter > 0)
        {
            //Debug.Log("while");
            
            counter--;
            yield return new WaitForSeconds(1f);

        }
        //Debug.Log("saiu while");
        if (isfaster == 0) playerMovement.SetMoveSpeedFast(2);
        if (isfaster == 1) playerMovement.SetMoveSpeedSlow(2);
        
    }
  


}
   
