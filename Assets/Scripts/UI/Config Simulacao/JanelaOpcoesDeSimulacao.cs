using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JanelaOpcoesDeSimulacao : MonoBehaviour
{
    [SerializeField] 
    private Janela janela;
    
    [SerializeField] 
    private Button botaoIniciarSimulacao;
    [SerializeField] 
    private TMP_Text textoDoBotao;
    
    [SerializeField] 
    private GameObject canvas;
    void Start()
    {
        InicializarCabeçalho();
        InicializarConteudo();
        InicializarRodape();
    }
    
    
    void Update()
    {
        
    }

    public void InicializarCabeçalho()
    {
        janela.SetTitulo("Opções de Simulação");
    }
    
    public void InicializarConteudo()
    {
        
    }
    public void InicializarRodape()
    {
        textoDoBotao.SetText("Iniciar Simulação");
        botaoIniciarSimulacao.onClick?.AddListener(() => transform.parent.gameObject.SetActive(false));
        botaoIniciarSimulacao.onClick?.AddListener(() => canvas.SetActive(true));
        botaoIniciarSimulacao.onClick?.AddListener(SimulacaoManager.main.IniciarSimulacao);
    }


}
