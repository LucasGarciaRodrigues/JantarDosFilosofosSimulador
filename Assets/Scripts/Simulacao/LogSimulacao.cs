using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSimulacao : MonoBehaviour
{
    [SerializeField]
    private List<string> logs;
    
    public Action<String> OnNovoLog;
    
    void Start()
    {
        SimulacaoManager.main.OnNovoLog += AdcionaLog;
        logs = new List<string>();
    }

    public void AdcionaLog(string log)
    {
        logs.Add(log);
        OnNovoLog?.Invoke(log);
    }

    public List<string> GetLogs()
    {
        return logs;
    }

    public void OnDisable()
    {
        logs = new List<string>();
    }
}
