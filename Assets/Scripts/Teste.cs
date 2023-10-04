using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    public float tempo;
    public float frameTime;
    public int frameRate;
    
    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime;
        frameRate++;
        if (tempo > 1f)
        {
            frameTime = 1000f / frameRate;
            Debug.Log($"FPS: {frameRate} | FrameTime: {frameTime:N1} ms");
            tempo = 0;
            frameRate = 0;
        }
    }
}
