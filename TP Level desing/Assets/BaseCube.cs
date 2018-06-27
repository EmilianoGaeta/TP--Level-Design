using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCube : MonoBehaviour {

    public bool floor;
    public int tamaño;// tamaño de la plataforma si es que es del tipo plataforma

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Ini()
    {
        if (!floor)
        {
            gameObject.SetActive(false);
        }
    }
}
