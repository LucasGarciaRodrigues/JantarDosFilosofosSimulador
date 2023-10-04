using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pagina : MonoBehaviour
{
    [SerializeField]
    private int id;
    [SerializeField]
    private GameObject paginaGameObject;

    public int GetId()
    {
        return id;
    }

    public void SetId(int id)
    {
        this.id = id;
    }
    
    public GameObject GetPagina()
    {
        return paginaGameObject;
    }

    public void SetPagina(GameObject paginaGameObject)
    {
        this.paginaGameObject = paginaGameObject;
    }
}
