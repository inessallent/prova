using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corridor_player : MonoBehaviour
{
    public string tagFilter;
    public GameObject players;
    public GameObject hit_audio_play;


 /*   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagFilter))
        {
            
        }
    }*/
    private void HitByHay()
    {
        corridor.Instance.PlayCorridorIntro();
    }
   

}
