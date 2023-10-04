using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaginaController : MonoBehaviour
{
    [SerializeField] 
    private Pagina[] listaDePaginas;    
    [SerializeField] 
    private Pagina paginaAtual;
    [SerializeField] 
    private int numeroDePaginas;
    void Start()
    {
        Inicializar();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow)) SetPaginaAtiva(GetPagina(paginaAtual.GetId() - 1));
        if(Input.GetKeyDown(KeyCode.RightArrow)) SetPaginaAtiva(GetPagina(paginaAtual.GetId() + 1));
    }

    public void Inicializar()
    {
        numeroDePaginas = listaDePaginas.Length;
        for (int i = 0; i < numeroDePaginas; i++)
        {
            listaDePaginas[i].SetId(i);
        }
        SetPaginaAtiva(listaDePaginas[0]);
    }
    
    public Pagina GetPagina(int indice)
    {
        indice = Math.Clamp(indice, 0, numeroDePaginas - 1);
        return listaDePaginas[indice];
    }
    public Pagina GetPaginaAtual()
    {
        return paginaAtual;
    }

    public int GetNumeroDePaginas()
    {
        return numeroDePaginas;
    }

    public void SetPaginaAtiva(Pagina novaPagina)
    {
        paginaAtual = novaPagina;
        for (int i = 0; i < numeroDePaginas; i++)
        {
            if (listaDePaginas[i] != paginaAtual)
            {
                listaDePaginas[i].GetPagina().SetActive(false);
            }
        }
        paginaAtual.GetPagina().SetActive(true);
    }
}
