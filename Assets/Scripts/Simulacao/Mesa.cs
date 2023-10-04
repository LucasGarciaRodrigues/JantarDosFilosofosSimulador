
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Mesa : MonoBehaviour
{
    public int numeroDeFilosofos;
    private Filosofo[] listaDeFilosofos;
    private bool[] listaDeGarfos;
    private TipoDeEscalonamentoEnum tipoDeEscalonamento;
    [SerializeField]
    private Queue<Filosofo> filaDeFilosofos;

    private void Start()
    {
        listaDeFilosofos = new Filosofo[6];
        listaDeGarfos = new bool[6];
    }
    
    public void InicializarMesa()
    {
        StartCoroutine(InicializarMesaCoroutine());
    }
    
    public IEnumerator InicializarMesaCoroutine()
    {
        filaDeFilosofos = new Queue<Filosofo>(20);
        StartCoroutine(MesaCourotine());
        for (int i = 0; i < numeroDeFilosofos; i++)
        {
            listaDeFilosofos[i].SetEstado(new Pensar(listaDeFilosofos[i]));
            listaDeFilosofos[i].GetPratoDeMacarrao().SetQuantidadeDeMacarrao(1000);
            listaDeGarfos[i] = true;
            yield return new WaitForSeconds(1f);
        }
    }
    
    public void PararMesa()
    {
        for (int i = 0; i < numeroDeFilosofos; i++)
        {
            listaDeFilosofos[i].SetEstado(new Idle(listaDeFilosofos[i]));
            listaDeFilosofos[i].GetPratoDeMacarrao().SetMacarraoActive(true);
        }

        filaDeFilosofos = null;
    }
    
    public IEnumerator MesaCourotine()
    {
        while (SimulacaoManager.main.estaRodando)
        {
            if (filaDeFilosofos.Count != 0)
            {
                PegarGarfo();
            }
            yield return new WaitForSeconds(1f);
        }
    }
    
    public void AdicionaFilosofo(Filosofo filosofo)
    {
        filosofo.SetID(numeroDeFilosofos);
        filosofo.SetMesa(this);
        listaDeFilosofos[numeroDeFilosofos] = filosofo;
        numeroDeFilosofos++;
    }

    public void RemoveFilosofo()
    {
        Destroy(listaDeFilosofos[numeroDeFilosofos - 1].gameObject);
        listaDeFilosofos[numeroDeFilosofos - 1] = null;
        numeroDeFilosofos--;
    }
    
    public void PedirGarfo(int idFilosofo)
    {
        var filosofo = listaDeFilosofos[idFilosofo];
        filaDeFilosofos.Enqueue(filosofo);
    }
    
    public void PegarGarfo()
    {
        var filosofo = filaDeFilosofos.First();
        var posicaoDoGarfo = filosofo.GetID();
        if (!filosofo.possuiGarfoEsquerdo)
        {
            if (listaDeGarfos[posicaoDoGarfo])
            {
                filosofo.possuiGarfoEsquerdo = true;
                listaDeGarfos[posicaoDoGarfo] = false;
                filaDeFilosofos.Dequeue();
            }
        }else if (!filosofo.possuiGarfoDireito)
        {
            if (posicaoDoGarfo + 1 == numeroDeFilosofos)
            {
                posicaoDoGarfo = 0;
            }
            else
            {
                posicaoDoGarfo++;
            }
            if (listaDeGarfos[posicaoDoGarfo])
            {
                filosofo.possuiGarfoDireito = true;
                listaDeGarfos[posicaoDoGarfo] = false;
                filosofo.GetPratoDeMacarrao().garfoEsquerdo.SetActive(false);
                listaDeFilosofos[posicaoDoGarfo].GetPratoDeMacarrao().garfoEsquerdo.SetActive(false);
                filaDeFilosofos.Dequeue();
            }
        }
    }
    
    
    public void DevolverGarfo(int posicaoDoGarfo)
    {
        if (posicaoDoGarfo == numeroDeFilosofos) posicaoDoGarfo = 0;
        listaDeGarfos[posicaoDoGarfo] = true;
        listaDeFilosofos[posicaoDoGarfo].GetPratoDeMacarrao().garfoEsquerdo.SetActive(true);
    }
    
    
    #region Getter e Setters
    public int GetNumeroDeFilosofos()
    {
        return numeroDeFilosofos;
    }
    
    public Filosofo GetFilosofo(int indice)
    {
        return listaDeFilosofos[indice];
    }
    
    public void SetTipoDeEscalonamento(TipoDeEscalonamentoEnum tipoDeEscalonamento)
    {
        this.tipoDeEscalonamento = tipoDeEscalonamento;
    }

    public void SetTempoPensado(int tempoPensando)
    {
        for (int i = 0; i < numeroDeFilosofos; i++)
        {
            listaDeFilosofos[i].SetTempoPensando(tempoPensando);
        }
    }
    
    public void SetTempoComendo(int tempoComendo)
    {
        for (int i = 0; i < numeroDeFilosofos; i++)
        {
            listaDeFilosofos[i].SetTempoComendo(tempoComendo);
        }
    }
    
    #endregion
}
