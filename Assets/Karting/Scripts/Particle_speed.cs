using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using KartGame.KartSystems;

public class Particle_speed : MonoBehaviour
{

    GameObject[] particlePrefab;
    ArcadeKart[] karts;
    float baseSimulationSpeed = .81F;
    float topSimulationSpeed = 1.04F;
    float finalGravMod = .71F;
    float startGravMod = 1.5F;
    float topRateOverTime = 11.1F;
    float baseRateOverTime = 5;


    // Start is called before the first frame update
    void Start()
    {
        particlePrefab = GameObject.FindGameObjectsWithTag("Particles");
        karts = FindObjectsOfType<ArcadeKart>();
    }

    // Update is called once per frame
    void Update()
    {
        // change the speed of the animation based on 
        foreach (var kart in karts)
        {
            //var scalingFactor = kart.LocalSpeed() / kart.baseStats.TopSpeed;
            //Debug.Log(kart.LocalSpeed());
            ChangeParticleSpeed(kart.LocalSpeed());
        }
    }

    private void ChangeParticleSpeed(float localSpeed)
    {
        foreach (var particleSystem in particlePrefab)
        {
            var psMain = particleSystem.GetComponent<ParticleSystem>().main;
            psMain.gravityModifier = startGravMod + (finalGravMod - startGravMod) * localSpeed;
            psMain.simulationSpeed = baseSimulationSpeed + (topSimulationSpeed - baseSimulationSpeed) * localSpeed;

            var psEm = particleSystem.GetComponent<ParticleSystem>().emission;
            psEm.rateOverTime = baseRateOverTime + (topRateOverTime - baseRateOverTime) * localSpeed;
        }
    }
}
