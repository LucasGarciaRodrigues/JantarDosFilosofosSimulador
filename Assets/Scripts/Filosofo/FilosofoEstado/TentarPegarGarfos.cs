
using System.Collections;
using UnityEngine;


public class TentarPegarGarfos : FilosofoEstado 
{
    public TentarPegarGarfos(Filosofo filosofo) : base(filosofo)
    {
    }

    public override IEnumerator Executar()
    {
        filosofo.tempoDeEspera = 0f;
        filosofo.tempoDeEsperaMaximo = filosofo.GetTempoPensando() + filosofo.GetTempoComendo() * 2;
        filosofo.GetMesa().PedirGarfo(filosofo.GetID());
        filosofo.GetMesa().PedirGarfo(filosofo.GetID());
        SimulacaoManager.main.AdicionaLog($"Filósofo {filosofo.GetID()+1} está aguardando o garfo Esquerdo");
        
        while (!filosofo.possuiGarfoEsquerdo)
        {
            yield return null;
            filosofo.tempoDeEspera += Time.deltaTime;
            if(filosofo.tempoDeEspera >= filosofo.tempoDeEsperaMaximo)
            {
                filosofo.SetEstado(new FilosofoMortoDeFome(filosofo));
                yield break;
            }
        }
        filosofo.GetAnimator().SetTrigger("Garfo Esquerdo");
        SimulacaoManager.main.AdicionaLog($"Filósofo {filosofo.GetID()+1} pegou o garfo Esquerdo");
        
        filosofo.tempoDeEspera = 0f;
        
        SimulacaoManager.main.AdicionaLog($"Filósofo {filosofo.GetID()+1} está aguardando o garfo Direito");
        while (!filosofo.possuiGarfoDireito || filosofo.tempoDeEspera >= filosofo.tempoDeEsperaMaximo)
        {
            yield return null;
            filosofo.tempoDeEspera += Time.deltaTime;
            if(filosofo.tempoDeEspera >= filosofo.tempoDeEsperaMaximo)
            {
                filosofo.SetEstado(new FilosofoMortoDeFome(filosofo));
                yield break;
            }
        }
        filosofo.GetAnimator().SetTrigger("Dois Garfos");
        SimulacaoManager.main.AdicionaLog($"Filósofo {filosofo.GetID()+1} pegou o garfo Direito");

        if (filosofo.possuiGarfoEsquerdo && filosofo.possuiGarfoDireito) 
        {
            filosofo.SetEstado(new Comer(filosofo));
        }
    }
}