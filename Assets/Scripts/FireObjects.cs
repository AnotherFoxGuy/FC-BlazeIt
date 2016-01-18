using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FireObjects : MonoBehaviour
{
    public FireSpawnner Pool;
    private float _live;
    public ParticleSystem ParticleSystem;
    private ParticleSystem.EmissionModule _emissionModule;
    public int On;
    // Use this for initialization

    public void Awake()
    {
        ParticleSystem = GetComponentInChildren<ParticleSystem>();
        _emissionModule = ParticleSystem.emission;
        ResetThis();
        ParticleSystem.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void ResetThis()
    {
        _live = Random.Range(10, 20);
        _emissionModule.rate = new ParticleSystem.MinMaxCurve(_live);
    }

    public void OnParticleCollision(GameObject other)
    {
        if (ParticleSystem.gameObject.activeSelf)
        {
            _live -= 0.05f;
            _emissionModule.rate = new ParticleSystem.MinMaxCurve(_live);
            if (_live < 0)
            {
                Pool.DestroyFire(this);
            }
        }
    }
}