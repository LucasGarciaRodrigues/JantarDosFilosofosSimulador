using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulacao : MonoBehaviour
{
    public static Simulacao main;
    
    public int numeroDeFilosofos = 2;
    public float tempoPensando = 5f;
    public float tempoComendo = 5f;
    public bool estaRodando { get; private set; }
    [SerializeField] 
    private Mesa mesa;
    [SerializeField] 
    private GameObject filosofoPrefab;
    [SerializeField] 
    private Transform filosofosTransform;
    [SerializeField] 
    private Transform filosofosPosicaoTransform;
    
    public Action<String> OnNovoLog;

    public void Start()
    {
        main = this;
        numeroDeFilosofos = 2;
    }

    public void IniciarSimulacao()
    {
        estaRodando = true;
        //mesa.InicializarMesa(tempoPensando, tempoComendo);
    }

    public void PararSimulacao()
    {
        estaRodando = false;
        mesa.PararMesa();
    }
    
    public void AdicionaFilosofo()
    {
        if(numeroDeFilosofos == 8) return;
        var filosofoGO = Instantiate(filosofoPrefab);
        var filosofo = filosofoGO.GetComponent<Filosofo>();
        filosofoGO.transform.SetParent(filosofosTransform);
        filosofoGO.transform.position += Vector3.right;
        mesa.AdicionaFilosofo(filosofo);
        numeroDeFilosofos++;
        
        var indice = filosofosPosicaoTransform.Find(numeroDeFilosofos.ToString());
        
        for (int i = 0; i < indice.childCount; i++)
        {
            mesa.GetFilosofo(i).transform.position = indice.GetChild(i).transform.position;
            mesa.GetFilosofo(i).transform.rotation = indice.GetChild(i).transform.rotation;
        }
    }
    
    public void RemoveFilosofo()
    {
        if(numeroDeFilosofos == 2) return;
        mesa.RemoveFilosofo();
        numeroDeFilosofos--;
        var indice = filosofosPosicaoTransform.Find(numeroDeFilosofos.ToString());
        
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
