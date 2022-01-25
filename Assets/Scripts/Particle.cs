using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public float particleTimeLife = 0.5f;
    private void Start()
    {
        Destroyparticle();
    }
    public void Destroyparticle() {
        StartCoroutine(enumerator());
    }
    IEnumerator enumerator()
    {
           yield return new WaitForSecondsRealtime(particleTimeLife);
        Destroy(gameObject);
    }
}
