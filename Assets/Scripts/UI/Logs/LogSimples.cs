using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class LogSimples: MonoBehaviour
{
    [SerializeField]
    private TMP_Text[] logs;

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
        
        int j = 0;
        
        for (int i = logsSimulacao.Count - 1; j < 4; i--)
        {
            logs[j].SetText(logsSimulacao[i]);
            j++;
        }
    }

    public void AdicionaLog(string log)
    {
        int i = 0;
        while (i < logs.Length-1)
        {
            logs[i].SetText(logs[i + 1].text);
            i++;
        }
        logs[i].SetText($"{log}");
    }
    
    public void OnDisable()
    {
        foreach (var mensagem in logs)
        {
            mensagem.SetText("");
        }
    }
    
    public void OnDestroy()
    {
        log.OnNovoLog -= AdicionaLog;
    }
}
