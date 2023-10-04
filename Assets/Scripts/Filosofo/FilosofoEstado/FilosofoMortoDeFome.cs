using System.Collections;
using System.Collections.Generic;

public class FilosofoMortoDeFome : FilosofoEstado
{
    public FilosofoMortoDeFome(Filosofo filosofo) : base(filosofo)
    {
    }
    
    public override IEnumerator Executar()
    {
        filosofo.GetAnimator().SetTrigger("Morto De Fome");
        SimulacaoManager.main.AdicionaLog($"Filósofo {filosofo.GetID()+1} morreu de fome");
        
        yield break;
    }
}
