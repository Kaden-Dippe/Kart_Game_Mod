using KartGame.KartSystems;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(ParticleSystem))]
public class EmitParticlesOnKartBounce : MonoBehaviour 
{
    ParticleSystem effect;
    KartBounce vehicleBounce;
    bool localBounceFlag = false;

    void Awake() 
    {
        effect = GetComponent<ParticleSystem>();
        vehicleBounce = GetComponentInParent<KartBounce>();

        Assert.IsNotNull(vehicleBounce, "This particle should be a child of a VehicleBounce!");
    }

    void Update()
    {
        
        
        if (localBounceFlag != vehicleBounce.BounceFlag) {
            Debug.Log("Bounce flag is true!!!");
        }

        if (vehicleBounce.BounceFlag)
        {
            effect.Play();
        }
    }
}
