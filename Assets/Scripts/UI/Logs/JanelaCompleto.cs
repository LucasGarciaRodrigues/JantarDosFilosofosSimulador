using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JanelaCompleto : MonoBehaviour
{
    [SerializeField]
    private List<TMP_Text> logs;
    [SerializeField]
    private TMP_Text logGO;
    [SerializeField]
    private GameObject container;
    [SerializeField]
    private LogSimulacao log;

    public void Start()
    {
        if(log.GetLogs().Count > 0) InicializaLog();
        log.OnNovoLog += AdicionaLog;
    }

    public void InicializaLog()
    {
        var logsSimulacao = log.GetLogs();
        
        for (int i = 0; i < logsSimulacao.Count ; i++)
        {
            AdicionaLog(logsSimulacao[i]);
        }
    }
    public void AdicionaLog(string log)
    {
        var novoLog = Instantiate(logGO, container.transform, true);
        novoLog.gameObject.SetActive(true);
        novoLog.SetText(log);
        var containerRect = container.GetComponent<RectTransform>();
        containerRect.sizeDelta += new Vector2(0, 50); 
        logs.Add(novoLog);
    }
    
    public void OnDestroy()
    {
        log.OnNovoLog -= AdicionaLog;
    }
    public void OnDisable()
    {
        for (int i = 0; i < container.transform.childCount; i++)
        {
            Destroy(container.transform.GetChild(i).gameObject);
        }
        var containerRect = container.GetComponent<RectTransform>();
        containerRect.sizeDelta = new Vector2(575, 0);
    }
}
