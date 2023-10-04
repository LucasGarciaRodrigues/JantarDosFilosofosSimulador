using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class FilosofoEstado
{
    protected Filosofo filosofo;

    public FilosofoEstado(Filosofo filosofo)
    {
        this.filosofo = filosofo;
    }

    public virtual IEnumerator Executar()
    {
        yield break;
    }
}
