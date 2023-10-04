using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float tempoEmMilissegundos;

    [SerializeField]
    private TMP_Text timerTexto;
    
    private void Start()
    {
        tempoEmMilissegundos = 0f;
    }
    
    private void Update()
    {
        tempoEmMilissegundos += Time.deltaTime;
        SetTexto();
    }

    public void SetTexto()
    {
        float minutos = Mathf.FloorToInt(tempoEmMilissegundos / 60);
        float segundos = Mathf.FloorToInt(tempoEmMilissegundos % 60);
        string tempoString = string.Format("{00:00}:{1:00}", minutos, segundos);
        timerTexto.SetText(tempoString);
    }

    public void OnDisable()
    {
        tempoEmMilissegundos = 0f;
    }
}
