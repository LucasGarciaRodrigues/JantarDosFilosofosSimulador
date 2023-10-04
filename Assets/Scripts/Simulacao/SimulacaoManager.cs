using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulacaoManager : MonoBehaviour
{
    public static SimulacaoManager main;
    public bool estaRodando { get; private set; }
    
    [SerializeField] 
    private Mesa mesa;
    [SerializeField] 
    private GameObject filosofoPrefab;
    [SerializeField] 
    private Transform filosofosTransform;
    [SerializeField] 
    private Transform filosofosPosicaoTransform;
    [SerializeField] 
    private Color[] filosofosColors;
    
    public Action<String> OnNovoLog;

    private void Awake()
    {
        main = this;
    }

    public void Start()
    {
        PopularMesa();
    }

    public void PopularMesa()
    {
        for (int i = 0; i < 2; i++)
        {
            AdicionarFilosofo();
        }
    }


    public void IniciarSimulacao()
    {
        estaRodando = true;
        mesa.InicializarMesa();
    }

    public void PararSimulacao()
    {
        estaRodando = false;
        mesa.PararMesa();
    }
    
    public void AdicionarFilosofo()
    {
        if(mesa.GetNumeroDeFilosofos() == 6) return;
        var filosofoGO = Instantiate(filosofoPrefab, filosofosTransform, true);
        var filosofo = filosofoGO.GetComponent<Filosofo>();
        var filosofoRenderer = filosofoGO.transform.GetChild(0).GetChild(1).GetComponent<SkinnedMeshRenderer>();
        filosofoGO.name = $"Filósofo {mesa.numeroDeFilosofos + 1}";
        filosofoRenderer.material = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        filosofoRenderer.material.color = filosofosColors[mesa.numeroDeFilosofos];
        
        mesa.AdicionaFilosofo(filosofo);
        
        var indice = filosofosPosicaoTransform.Find(mesa.GetNumeroDeFilosofos().ToString());
        for (int i = 0; i < indice.childCount; i++)
        {
            mesa.GetFilosofo(i).transform.position = indice.GetChild(i).transform.position;
            mesa.GetFilosofo(i).transform.rotation = indice.GetChild(i).transform.rotation;
        }
    }

    public void RemoveFilosofo()
    {
        if(mesa.GetNumeroDeFilosofos() == 2) return;
        mesa.RemoveFilosofo();
        var indice = filosofosPosicaoTransform.Find(mesa.GetNumeroDeFilosofos().ToString());
        
        for (int i = 0; i < indice.childCount; i++)
        {
            mesa.GetFilosofo(i).transform.position = indice.GetChild(i).transform.position;
            mesa.GetFilosofo(i).transform.rotation = indice.GetChild(i).transform.rotation;
        }
    }

    public Mesa GetMesa()
    {
        return mesa;
    }

    public void AdicionaLog(string log)
    {
        OnNovoLog?.Invoke(log);
    }
    
}
