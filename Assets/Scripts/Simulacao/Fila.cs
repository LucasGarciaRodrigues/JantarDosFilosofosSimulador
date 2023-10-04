using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public class Fila<T> where T : Object
{
    public int numeroDeElementos;
    public T[] fila;
    
    public Fila(int tamanho)
    {
        fila = new T[tamanho];
        numeroDeElementos = 0;
    }

    public void Enfileira(T elemento)
    {
        if(EstaCheia()) return;
        int i = 0;
        while (fila[i] != null) i++;
        fila[i] = elemento;
        numeroDeElementos++;
    }

    public T Desenfileira()
    {
        if(EstaVazia()) return null;
        T primeiroElemento = fila[0];
        for (int i = 1; i < numeroDeElementos - 1; i++)
        {
            fila[i - 1] = fila[i];
        }
        fila[numeroDeElementos - 1] = null;
        numeroDeElementos--;
        return primeiroElemento;
    }
    
    public T GetPrimeiroElementoDaFila()
    {
        if(EstaVazia()) return null;
        T primeiroElemento = fila[0];
        return primeiroElemento;
    }

    public bool EstaVazia()
    {
        return numeroDeElementos == 0;
    }

    public bool EstaCheia()
    {
        return numeroDeElementos == fila.Length;
    }
}
