using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    static public WeatherManager instance;
    //private AudioManager theAudo;
    public ParticleSystem rain;
    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Rain()
    {
        rain.Play();
    }
    public void RainStop()
    {
        rain.Stop();
    }
        private void OnApplicationPause(bool pause)
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
