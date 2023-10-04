using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoPararSimulacao : MonoBehaviour
{
    [SerializeField] 
    private Button botaoParar;

    private void Start()
    {
        botaoParar.onClick?.AddListener(SimulacaoManager.main.PararSimulacao);
    }
}
