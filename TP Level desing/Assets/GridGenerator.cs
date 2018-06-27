using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {

    public BaseCube cubes;
    private Camera cam;
    public float gridWidth;
    public float gridheight;

    public List<List<BaseCube>> matrizCubes = new List<List<BaseCube>>();

    public float spawnSpeed = 0;
	
	void Start ()
    {
        gridWidth *= cubes.transform.localScale.y;
        gridheight *= cubes.transform.localScale.x;
        MoverACorneDeCamara();
        StartCoroutine(CreateWorld());
    }

    private void MoverACorneDeCamara()
    {
        cam = Camera.main;
        float height = cam.orthographicSize;
        float width = height * cam.aspect;
        transform.position = new Vector3(cam.transform.position.x - width + cubes.transform.localScale.x / 2, cam.transform.position.y - height + cubes.transform.localScale.y / 2, 0);
    }

    //crea Mapa
    IEnumerator CreateWorld()
    {
        for (float i = 0; i < gridWidth; i += cubes.transform.localScale.y)
        {
            var pra = new List<BaseCube>();
            yield return new WaitForSeconds(spawnSpeed);
            for (float j = 0; j < gridheight; j += cubes.transform.localScale.x)
            {
                var block = (BaseCube)Instantiate(cubes, Vector3.zero, cubes.transform.rotation);
                block.transform.parent = transform;
                block.transform.localPosition = new Vector3(i, j, 0);

                pra.Add(block);
                yield return new WaitForSeconds(spawnSpeed);
            }
                matrizCubes.Add(pra);
            //Determina los tipos de cubo de la columna
            for (int k = 0; k < pra.Count; k++)
            {
                DetermineCubeType(i, k * cubes.transform.localScale.x, pra[k]);
                pra[k].Ini();
            }


        }
    }

    private void DetermineCubeType(float i ,float j, BaseCube block)
    {
        var auxI = (int)(i / cubes.transform.localScale.y);
        var auxJ = (int)(j / cubes.transform.localScale.x);
        int primerasColumnas = 3;

        if (j == 0)//si esta en la pos piso
        {
            if (auxI < primerasColumnas)// si esta en las primeras columnas
            {
                block.floor = true;
                return;
            }

            var sa = Random.Range(0, 10);// random para determinar si hay piso o no
            if (sa > 1)
                block.floor = true;
            else
                block.floor = false;
            return;
        }
        else//aca trabajo con los cubos que no son piso
        {
            if (auxI < primerasColumnas)//si esta en las primeras columnas no debe haber plataformas
            {
                block.floor = false;
                return;
            }

            if (j > cubes.transform.localScale.y)//si hay un bloque entre el piso y este bloque
            {


                if (auxI > 0)// si esta en rango de la matriz
                {
                    if (CheckIfFloor(auxI,auxJ,block))
                    {
                        block.floor = true;
                        block.GetComponent<MeshRenderer>().material.color = Color.blue;
                        return;
                    }
                }
                var sa = Random.Range(0, 5);//random para determinar si es plataforma
                if (sa == 3 && auxI > 0 && auxJ > 0)// me fijo si esta en rango de la matriz
                {
                    if (matrizCubes[auxI][auxJ - 1] == null || !matrizCubes[auxI][auxJ-1].floor)//me fijo si el bloque de abajo es plataforma o piso
                    {
                        block.floor = true;
                        block.GetComponent<MeshRenderer>().material.color = Color.blue;
                        int r = Random.Range(0, 3);
                        block.tamaño = r;
                        return;
                    }
                }
            }
            block.floor = false;
        }
    }
    //se fija si a la izquierda hay un plataforma y si hay depende del tamaño de la platafoma si este bloque es bloque plataforma o no
    public bool CheckIfFloor(int i, int j , BaseCube cube)
    {
        if (matrizCubes[i - 1][j].floor)
        {
            if (matrizCubes[i - 1][j].tamaño > 0 && (matrizCubes[i][j - 1] == null || !matrizCubes[i][j - 1].floor))
            {
                cube.tamaño = matrizCubes[i - 1][j].tamaño - 1;
                return true;
            }
        }
        return false;
    }
}
