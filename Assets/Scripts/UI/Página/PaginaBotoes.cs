using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaginaBotoes : MonoBehaviour
{
    [SerializeField] 
    private Button botaoPaginaAnterior;
    [SerializeField] 
    private Button botaoProximaPagina;
    [SerializeField] 
    private PaginaController paginaController;
    
    void OnEnable()
    {
        botaoPaginaAnterior.onClick?.AddListener(OnBotaoPaginaAnteriorPressed);
        botaoProximaPagina.onClick?.AddListener(OnBotaoProximaPaginaPressed);
        SetBotaoPaginaAnteriorVisivel(false);
        SetBotaoProximaPaginaVisivel(true);
    }

    public void OnBotaoPaginaAnteriorPressed()
    {
         paginaController.SetPaginaAtiva(paginaController.GetPagina(paginaController.GetPaginaAtual().GetId() - 1));
         SetBotaoPaginaAnteriorVisivel(paginaController.GetPaginaAtual().GetId() > 0);
         SetBotaoProximaPaginaVisivel(paginaController.GetPaginaAtual().GetId() < 
                               paginaController.GetNumeroDePaginas() - 1);
    }
    
    public void  OnBotaoProximaPaginaPressed()
    {
        paginaController.SetPaginaAtiva(paginaController.GetPagina(paginaController.GetPaginaAtual().GetId() + 1));
        SetBotaoPaginaAnteriorVisivel(paginaController.GetPaginaAtual().GetId() > 0);
        SetBotaoProximaPaginaVisivel(paginaController.GetPaginaAtual().GetId() < 
                                         paginaController.GetNumeroDePaginas() - 1);
    }

    public void SetBotaoPaginaAnteriorVisivel(bool ehVisivel)
    {
        botaoPaginaAnterior.interactable = ehVisivel;
    }
    
    public void SetBotaoProximaPaginaVisivel(bool ehVisivel)
    {
        botaoProximaPagina.interactable = ehVisivel;
    }
    
    void OnDisable()
    {
        botaoPaginaAnterior.onClick?.RemoveListener(OnBotaoPaginaAnteriorPressed);
        botaoProximaPagina.onClick?.RemoveListener(OnBotaoPaginaAnteriorPressed);
        paginaController.SetPaginaAtiva(paginaController.GetPagina(0));
    }
}
