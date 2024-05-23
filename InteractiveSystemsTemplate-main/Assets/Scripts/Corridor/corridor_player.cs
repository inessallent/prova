using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corridorPlayerCollider : MonoBehaviour
{
    public string tagFilter;
    public GameObject players;
    public GameObject hit_audio_play;


    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag(tagFilter)) 
        {
            Destroy(gameObject); 
        }
    }

    private void HitByHay()
    {
        corridor.Instance.PlayCorridorIntro();
    }
   

}
