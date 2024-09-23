using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowFinalScore : MonoBehaviour
{
    public TextMeshProUGUI tmp;

    void Start()
    {
        int pontuacao = PlayerPrefs.GetInt("Pontuacao", 0);

        tmp.text = "Pontuação Final: " + pontuacao.ToString();
    }
}
