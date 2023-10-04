using System.Collections;
using UnityEngine;


public class Pensar: FilosofoEstado
{
    public Pensar(Filosofo filosofo) : base(filosofo)
    {
    }

    public override IEnumerator Executar()
    {
        filosofo.GetAnimator().SetTrigger("Pensar");
        SimulacaoManager.main.AdicionaLog($"Filósofo {filosofo.GetID() + 1} está pensando.");
        yield return new WaitForSeconds(filosofo.GetTempoPensando());
        filosofo.SetEstado(new TentarPegarGarfos(filosofo));
    }
}
