using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{
    public PlayerMovement PlayerMovement;
    private int numbuff = 5, op = 0, tempo = 10;

    private void Start()
    {
        PlayerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }
    

    public void buffativar() {
        
        op = Random.Range(0, numbuff);
        //op = 3;
        
        if (op == 0)
        {
            //Diminuir velodicade
            Debug.Log("Diminuindo Velocidade");
            PlayerMovement.SetMoveSpeed(-100);
            Countdown(tempo);
            

        }

        if (op == 1)
        {
            //Aumentar Velocidade
            Debug.Log("Velocidade Aumentada");
            PlayerMovement.SetMoveSpeed(100);
            Countdown(tempo);
        }

        if (op == 2)
        {
            //Pulo Automatico
            Debug.Log("Canguru Mode");

            Countdown(tempo);
        }

        if (op == 3)
        {
            //Pular mais Alto
            Debug.Log("Pulo mais alto");

            Countdown(tempo);
        }

        if (op == 4)
        {
            //Inverter Controles
            Debug.Log("Inverter controles");

            Countdown(tempo);
        }





    }
    void Resetar()
    {
        if (op == 0){
            //volta velocidade ao normal
            PlayerMovement.SetMoveSpeed(100);
        }

        if (op == 1)
        {
            //volta velocidade ao normal
            PlayerMovement.SetMoveSpeed(-100);
        }
    }

    IEnumerator Countdown(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        Resetar();
    }


}
   
