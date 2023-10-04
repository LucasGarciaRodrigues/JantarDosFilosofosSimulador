using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Escalonador
{
    public Fila<Filosofo> filaDeFilosofos;

    public Escalonador()
    {
        filaDeFilosofos = new Fila<Filosofo>(20);
    }
}
