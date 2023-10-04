using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumeroDeFilosofosOpcao : MonoBehaviour
{
    [SerializeField] 
    private ContainerDecrementaIncrementaInt container;

    private void Start()
    {
        container.SetDescricao("Número de Filósofos");
        container.OnValorChanged += OnValorChanged;
    }

    public void OnValorChanged(int valor)
    {
        if (valor < SimulacaoManager.main.GetMesa().GetNumeroDeFilosofos())
        {
            SimulacaoManager.main.RemoveFilosofo();
            return;
        }
        SimulacaoManager.main.AdicionarFilosofo();
    }
}
