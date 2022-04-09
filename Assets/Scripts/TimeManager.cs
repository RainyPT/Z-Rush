using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float Slowed = 0.05f;
    public float TimeInSlow = 5f;
    
    public void Update() {

        Time.timeScale += (1f / TimeInSlow) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    public void DoSlowTime() {

        Time.timeScale = Slowed;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}
