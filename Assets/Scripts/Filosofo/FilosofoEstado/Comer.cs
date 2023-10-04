using System.Collections;
using UnityEngine;


public class Comer : FilosofoEstado
{
    public Comer(Filosofo filosofo) : base(filosofo)
    {
    }

    public override IEnumerator Executar()
    {
        filosofo.GetAnimator().SetTrigger("Comer");
        SimulacaoManager.main.AdicionaLog($"Filósofo {filosofo.GetID() + 1} está comendo.");

        var macarraoConsumido = (int) filosofo.GetTempoComendo() * filosofo.GetConsumoDeMacarrao();

        while (macarraoConsumido > 0)
        {
            filosofo.GetPratoDeMacarrao().ComerMacarrao(filosofo.GetConsumoDeMacarrao());
            macarraoConsumido -= filosofo.GetConsumoDeMacarrao();
            yield return new WaitForSeconds(1f);
        }

        filosofo.GetMesa().DevolverGarfo(filosofo.GetID());
        filosofo.GetMesa().DevolverGarfo(filosofo.GetID() + 1);
        filosofo.possuiGarfoEsquerdo = false;
        filosofo.possuiGarfoDireito = false;
        SimulacaoManager.main.AdicionaLog($"Filósofo {filosofo.GetID() + 1} devolveu o garfo esquerdo.");
        SimulacaoManager.main.AdicionaLog($"Filósofo {filosofo.GetID() + 1} devolveu o garfo direito.");

        if (filosofo.GetPratoDeMacarrao().EstaVazio())
        {
            filosofo.SetEstado(new FilosofoCheio(filosofo));
        }else
        {
            filosofo.SetEstado(new Pensar(filosofo));
        }
    }
}
