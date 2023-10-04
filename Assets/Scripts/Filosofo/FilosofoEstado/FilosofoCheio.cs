using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilosofoCheio : FilosofoEstado
{
    public FilosofoCheio(Filosofo filosofo) : base(filosofo)
    {
    }

    public override IEnumerator Executar()
    {
        filosofo.GetPratoDeMacarrao().SetMacarraoActive(false);
        filosofo.GetAnimator().SetTrigger("Idle");
        SimulacaoManager.main.AdicionaLog($"Filósofo {filosofo.GetID() + 1} terminou o seu prato de macarrão.");
        yield return null;
    }
}
