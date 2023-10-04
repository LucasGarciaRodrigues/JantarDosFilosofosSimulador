
using TMPro;
using UnityEngine;

public class Janela : MonoBehaviour
{
    [SerializeField] 
    private Transform areaDaJanela;
    
    [Header("Cabeçalho")] 
    [SerializeField]
    private Transform areaDoCabecalho;

    [SerializeField] private TMP_Text titulo;
    
    [Header("Conteúdo")] 
    [SerializeField]
    private Transform areaDoConteudo;
    
    [Header("Rodapé")] 
    [SerializeField]
    private Transform areaDoRodape;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTitulo(string novoTitulo)
    {
        titulo.SetText(novoTitulo);
    }
}
