using System;
using UnityEngine;

public class Filosofo : MonoBehaviour
{ 
    [SerializeField]
    private int id;
    [SerializeField]
    private float tempoPensando = 1f;
    [SerializeField]
    private float tempoComendo = 1f;
    [SerializeField]
    private int consumoDeMacarrao = 100;
    
    public bool possuiGarfoEsquerdo;
    public bool possuiGarfoDireito;
    
    private FilosofoEstado estadoAtual;

    public float tempoDeEspera = 0f;
    public float tempoDeEsperaMaximo = 3f;
    
    [SerializeField]
    private Animator animator;

    [SerializeField] 
    private PratoDeMacarrao pratoDeMacarrao;
    [SerializeField] 
    private Mesa mesa;

    public void SetEstado(FilosofoEstado novoEstado)
    {
        if(estadoAtual != null) StopAllCoroutines();
        estadoAtual = novoEstado;
        StartCoroutine(estadoAtual.Executar());
    }
    
    public bool FilosofoTemDoisGarfos()
    { 
        return possuiGarfoEsquerdo && possuiGarfoDireito;
    }

    public int GetID()
    {
        return id;
    }

    public void SetID(int id)
    {
        this.id = id;
    }

    public float GetTempoPensando()
    {
        return tempoPensando;
    }

    public void SetTempoPensando(float tempoPensando)
    {
        this.tempoPensando = tempoPensando;
    }
    
    public float GetTempoComendo()
    {
        return tempoComendo;
    }
    
    public void SetTempoComendo(float tempoComendo)
    {
        this.tempoComendo = tempoComendo;
    }
    
    public int GetConsumoDeMacarrao()
    {
        return consumoDeMacarrao;
    }
    
    public void SetConsumoDeMacarrao(int consumoDeMacarrao)
    {
        this.consumoDeMacarrao = consumoDeMacarrao;
    }

    public PratoDeMacarrao GetPratoDeMacarrao()
    {
        return pratoDeMacarrao;
    }
    public Animator GetAnimator()
    {
        return animator;
    }
    
    public void SetAnimator(Animator animator)
    {
        this.animator = animator;
    }
    
    public Mesa GetMesa()
    {
        return mesa;
    }
    
    public void SetMesa(Mesa mesa)
    {
        this.mesa = mesa;
    }
    
}
