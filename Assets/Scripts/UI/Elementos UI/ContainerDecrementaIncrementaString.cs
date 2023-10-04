using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ContainerDecrementaIncrementaString : MonoBehaviour
{
    private int valorAtual;
    
    [SerializeField] 
    private string[] listaDeOpcoes;
    
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
        valorAtual = 0;
        display.SetText($"{listaDeOpcoes[valorAtual]}");
        botaoDecrementar.onClick.AddListener(OnBotaoDecrementarPressed);
        botaoIncrementar.onClick.AddListener(OnBotaoIncrementarPressed);
    }
    
    public void OnBotaoDecrementarPressed()
    {
        valorAtual--;
        if (valorAtual < 0) valorAtual = listaDeOpcoes.Length - 1;
        display.SetText($"{listaDeOpcoes[valorAtual]}");
        OnValorChanged?.Invoke(valorAtual);
    }
    
    public void OnBotaoIncrementarPressed()
    {
        valorAtual++;
        if (valorAtual > listaDeOpcoes.Length - 1) valorAtual = 0;
        display.SetText($"{listaDeOpcoes[valorAtual]}");
        OnValorChanged?.Invoke(valorAtual);
    }

    public void SetDescricao(string descricao)
    {
        descricaoTexto.SetText($"{descricao}");
    }
}
