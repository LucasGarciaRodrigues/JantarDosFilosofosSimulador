using System.Collections;


public class Idle: FilosofoEstado
{
    public Idle(Filosofo filosofo) : base(filosofo)
    {
    }

    public override IEnumerator Executar()
    {
        filosofo.GetAnimator().Play("Filosofo_Idle");
        yield break;
    }
}
