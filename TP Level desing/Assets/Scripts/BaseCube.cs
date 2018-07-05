using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCube : MonoBehaviour {

    public bool exists;
    public int tamaño=0;// tamaño de la plataforma si es que es del tipo plataforma
    public int space=0;
    public bool spike;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Initialice()
    {
        if (!exists)
        {
            gameObject.SetActive(false);
        }
    }

    public void Spike()
    {
        var spike = Instantiate((GameObject)Resources.Load("Spike"));
        spike.transform.position = transform.position + Vector3.up * transform.localScale.y / 2;
        this.spike = true;
    }
    public void Coin()
    {
        var spike = Instantiate((GameObject)Resources.Load("Coin"));
        spike.transform.position = transform.position + Vector3.up * transform.localScale.y;
    }

}
