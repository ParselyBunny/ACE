using JTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public float Volume
    {
        get => _volume;

        private set {
            _volume = value;
        } 
    }
    float _volume;

    void Start()
    {
        Vector3 size = GetComponent<MeshRenderer>().bounds.size;
        Volume = size.x * size.y;
    }

    void OnTriggerEnter(UnityEngine.Collider other)
    {
        float playerVolume = ImpactController.current.PlayerVolume;

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Blorbo tried to eat " + name);

            if (playerVolume > Volume)
            {
                Destroy(gameObject);
                ImpactController.current.EatTrash(Volume);
            }
            else
            {
                Debug.Log("Blorbo (vol: " + playerVolume + ") failed to eat garbage (vol: " 
                    + Volume + ") that was too big for it.");
            }
            
        }
    }
}
