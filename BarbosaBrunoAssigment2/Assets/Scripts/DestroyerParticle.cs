using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerParticle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //destroy after 3 seconds to not crowd the game
        Destroy(gameObject, 3f);
    }
}
