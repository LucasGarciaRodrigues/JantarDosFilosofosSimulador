using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BotãoPausar : MonoBehaviour
{
    private bool estaPausado;
    [SerializeField]
    private TMP_Text texto;
    [SerializeField]
    private Button botaoPausar;
    
    public void Start()
    {
        estaPausado = false;
        botaoPausar.onClick.AddListener(OnPausar);
    }

    public void OnPausar()
    {
        if (!estaPausado)
        {
            estaPausado = true;
            Time.timeScale = 0f;
            texto.SetText("Continuar");
            return;
        }
        estaPausado = false;
        Time.timeScale = 1f;
        texto.SetText("Pausar");
    }
}
