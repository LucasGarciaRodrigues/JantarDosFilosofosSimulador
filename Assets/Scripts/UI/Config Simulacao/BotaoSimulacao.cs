using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BotaoSimulacao : MonoBehaviour
{
    [SerializeField] 
    private Button botao;
    [SerializeField] 
    private TMP_Text texto;
    [SerializeField] 
    private Simulacao simulacao;
    
    void Start()
    {
        botao = GetComponent<Button>();
        botao.onClick?.AddListener(OnBotaoPressionado);
        texto.SetText("Iniciar Simulação");
    }

    public void OnBotaoPressionado()
    {
        simulacao.IniciarSimulacao();
    }
}
