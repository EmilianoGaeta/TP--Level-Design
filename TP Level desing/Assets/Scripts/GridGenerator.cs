using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {

    public BaseCube cubes;
    private Camera cam;

    public GameObject background;
    public GameObject puertaEnd;

    public List<List<BaseCube>> matrizCubes = new List<List<BaseCube>>();

    private Rules rules;
    private float gridWidth;
    private float gridheight;

    public float spawnSpeed = 0.01f;
	
	void Start ()
    {
        gridWidth = Modifiers.levelLenght * cubes.transform.localScale.y;
        gridheight = 8 *cubes.transform.localScale.x;
        MoverACorneDeCamara();

        StartCoroutine(CreateWorld());
        rules = new Rules();
    }

    private void MoverACorneDeCamara()
    {
        cam = Camera.main;
        float height = cam.orthographicSize;
        float width = height * cam.aspect;
        transform.position = new Vector3(cam.transform.position.x - width + cubes.transform.localScale.x / 2, cam.transform.position.y - height + cubes.transform.localScale.y / 2, 0);

        var cantCubesOnBack = background.GetComponent<SpriteRenderer>().bounds.size.x / cubes.GetComponent<Renderer>().bounds.size.x;

        var cantBack = gridWidth / cantCubesOnBack;

        var back = Instantiate(background);
        back.transform.position = new Vector3(cam.transform.position.x + (back.GetComponent<SpriteRenderer>().bounds.size.x / 2 - width),
            cam.transform.position.y, 0);

        var spawnPoint = new Vector3(back.transform.position.x + back.GetComponent<SpriteRenderer>().bounds.size.x, back.transform.position.y, back.transform.position.z);

        for (int i = 1; i <= cantBack + 1; i++)
        {
            back = Instantiate(background);
            back.transform.position = spawnPoint;
            spawnPoint = new Vector3(back.transform.position.x + back.GetComponent<SpriteRenderer>().bounds.size.x, back.transform.position.y, back.transform.position.z);
        }


    }

    //crea Mapa
    IEnumerator CreateWorld()
    {
        for (int i = 0; i < gridWidth; i++)
        {
            var column = new List<BaseCube>();
            for (int j = 0; j < gridheight; j ++)
            {
                var block = (BaseCube)Instantiate(cubes, Vector3.zero, cubes.transform.rotation);
                block.transform.parent = transform;
                block.transform.localPosition = new Vector3(i * cubes.transform.localScale.x, j * cubes.transform.localScale.y, 0);
                column.Add(block);
                if (i < Modifiers.Instance.initialspace && j == 0 || i >= gridWidth - Modifiers.finalSpace * cubes.transform.localScale.x && j == 0) { block.exists = true; }//Inicio y Final
                if (i == 2 && j == 1)
                {
                    block.exists = false;
                    var character = Instantiate((GameObject)Resources.Load("Character"));
                    character.transform.position = block.transform.position;
                }
                //Puerta Final
                if (i== gridWidth - 2 && j == 1)
                {
                    block.exists = false; var finalDoor = Instantiate(puertaEnd); finalDoor.transform.position = block.transform.position+ Vector3.up * cubes.transform.localScale.y / 2;
                }
                yield return new WaitForSeconds(spawnSpeed);
            }
            matrizCubes.Add(column);
            //Determina los tipos de cubo de la columna
            for (int k = 0; k < column.Count; k++)
            {
                if (i >= Modifiers.initialSpace && i < gridWidth - Modifiers.finalSpace * cubes.transform.localScale.x)
                {
                    if (k == 0) { rules.CreateFloor(i, column[k], matrizCubes); }
                    if (k > 2)
                    {
                        rules.CreatPlatform(i, k, column[k], matrizCubes);
                    }
                   
                }
                column[k].Initialice();
            }
        }
    }
}
