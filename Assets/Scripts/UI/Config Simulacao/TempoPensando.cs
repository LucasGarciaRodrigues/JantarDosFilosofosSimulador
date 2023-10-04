using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TempoPensando : MonoBehaviour
{
    [SerializeField] 
    private ContainerDecrementaIncrementaInt container;
    
    private void Start()
    {
        container.SetDescricao("Tempo Pensando");
        container.OnValorChanged += OnValorChanged;
    }

    public void OnValorChanged(int valor)
    {
        SimulacaoManager.main.GetMesa().SetTempoPensado(valor);
    }
}
