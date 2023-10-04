using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ContainerDecrementaIncrementaInt : MonoBehaviour
{
    private int valorAtual;
    [SerializeField]
    private int valorMinimo;
    [SerializeField]
    private int valorMaximo;
    
    [SerializeField] 
    private TMP_Text descricaoTexto;
    
    [SerializeField] 
    private TMP_Text display;
    
    [SerializeField] 
    private Button botaoDecrementar;
    [SerializeField] 
    private Button botaoIncrementar;

    [SerializeField]
    public UnityAction<int> OnValorChanged;

    private void Start()
    {
        valorAtual = valorMinimo;
        display.SetText($"{valorMinimo}");
        botaoDecrementar.interactable = valorAtual > valorMinimo;
        botaoIncrementar.interactable = valorAtual < valorMaximo;
        botaoDecrementar.onClick.AddListener(OnBotaoDecrementarPressed);
        botaoIncrementar.onClick.AddListener(OnBotaoIncrementarPressed);
    }

    public void OnBotaoDecrementarPressed()
    {
        valorAtual--;
        valorAtual = Mathf.Clamp(valorAtual, valorMinimo, valorMaximo);
        display.SetText($"{valorAtual}");
        botaoDecrementar.interactable = valorAtual > valorMinimo;
        botaoIncrementar.interactable = valorAtual < valorMaximo;
        OnValorChanged?.Invoke(valorAtual);
    }
    
    public void OnBotaoIncrementarPressed()
    {
        valorAtual++;
        valorAtual = Mathf.Clamp(valorAtual, valorMinimo, valorMaximo);
        display.SetText($"{valorAtual}");
        botaoDecrementar.interactable = valorAtual > valorMinimo;
        botaoIncrementar.interactable = valorAtual < valorMaximo;
        OnValorChanged?.Invoke(valorAtual);
    }

    public void SetDescricao(string descricao)
    {
        descricaoTexto.SetText($"{descricao}");
    }

}
