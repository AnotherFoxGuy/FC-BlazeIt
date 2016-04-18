// This file is part of FC-BlazeIt
// 
// Copyright (c) 2016 sietze greydanus
// 
// FC-BlazeIt is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License version 3, as
// published by the Free Software Foundation.
// 
// FC-BlazeIt is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with FC-BlazeIt. If not, see <http://www.gnu.org/licenses/>.
// 

using UnityEngine;

public class FireObjects : MonoBehaviour
{
    private ParticleSystem.EmissionModule _emissionModule;
    private float _live;
    public int On;
    public ParticleSystem ParticleSystem;
    public FireSpawnner Pool;
    // Use this for initialization

    public void Awake()
    {
        ParticleSystem = GetComponentInChildren<ParticleSystem>();
        _emissionModule = ParticleSystem.emission;
        ResetThis();
        ParticleSystem.gameObject.SetActive(false);
    }


    // Update is called once per frame
    private void Update()
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