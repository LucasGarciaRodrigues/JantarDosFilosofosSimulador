using UnityEngine;

public class PratoDeMacarrao : MonoBehaviour
{
    private int quantidadeDeMacarrao = 1000;
    [SerializeField]
    private GameObject macarraoGO;
    public GameObject garfoEsquerdo;

    public void ComerMacarrao(int quantidade)
    {
        quantidadeDeMacarrao -= quantidade;
        if (EstaVazio())
        {
            quantidadeDeMacarrao = 0;
        }
    }

    public bool EstaVazio()
    {
        return quantidadeDeMacarrao <= 0;
    }
    
    public int GetQuantidadeDeMacarrao()
    {
        return quantidadeDeMacarrao;
    }
    
    public void SetQuantidadeDeMacarrao(int quantidade)
    {
        this.quantidadeDeMacarrao = quantidade;
    }
    
    public void SetMacarraoActive(bool estaAtivo)
    {
        macarraoGO.SetActive(estaAtivo);
    }
}
