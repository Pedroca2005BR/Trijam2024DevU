using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

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
        
        op = Random.Range(0, 5);
        //op = 2;
        
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

            playerMovement.SetLandEvent();
                
            
        }

        if (op == 3)
        {
            //Pular mais Alto
            Debug.Log("Pulo mais alto");

            playerMovement.ChangeJumpForce(1100);
           
            //Countdown(2);
        }

        if (op == 4)
        {
            //Inverter Controles
            Debug.Log("Inverter controles");
            playerMovement.SetSpeedOpposite();

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
        else if (isfaster == 1) playerMovement.SetMoveSpeedSlow(2);
        else if (isfaster == 2) playerMovement.SetLandEvent();
        else if (isfaster == 3) playerMovement.ChangeJumpForce(800);
        else if (isfaster == 4) playerMovement.SetSpeedOpposite();

    }
  


}
   
