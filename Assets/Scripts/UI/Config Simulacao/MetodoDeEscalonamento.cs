using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetodoDeEscalonamento : MonoBehaviour
{
    [SerializeField]
    private ContainerDecrementaIncrementaString container;
    private void Start()
    {
        container.SetDescricao("Método de Escalonamento");
        container.OnValorChanged += OnValorChanged;
    }
    public void OnValorChanged(int valor)
    {
        SimulacaoManager.main.GetMesa().SetTipoDeEscalonamento((TipoDeEscalonamentoEnum)valor);
    }
}
