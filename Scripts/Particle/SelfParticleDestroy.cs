using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfParticleDestroy : MonoBehaviour
{
    ParticleSystem particle;
    void Start()
    {
        particle = this.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (particle.isStopped)
        {
            Destroy(this.gameObject);
        }
    }
}
