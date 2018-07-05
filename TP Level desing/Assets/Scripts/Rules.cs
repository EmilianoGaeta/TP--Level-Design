using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules
{

    public void CreatPlatform(int i, int j, BaseCube block, List<List<BaseCube>> matrizCubes)
    {
        CheckPlatform(i, j, block, matrizCubes);
       
    }

    public void CreateFloor(int i,BaseCube block, List<List<BaseCube>> matrizCubes)
    {
        var gap = Random.Range(0, 100);// random para determinar si hay piso o no
        if (gap < Modifiers.floorGapChance)
        {
            block.exists = false;
            //fuerza a un piso si el hueco es muy grande
            bool ex = false;
            for (int j = 0; j < Modifiers.maxFloorGapSize; j++)
            {
                if (i - j < 0) { break; }
                if (!matrizCubes[i - j][0].exists)
                {
                    ex = true;
                }
                else
                {
                    ex = false;
                    break;

                }
            }
            block.exists = ex;
        }
        else
        {
            block.exists = true;
            var spikeChance = Random.Range(0, 100);//random para determinar si tiiene pinches
            if (spikeChance < Modifiers.spikeChance && matrizCubes[i - 1][0].exists)
            {
                block.Spike();
            }
        }
    }
    //se fija si a la izquierda hay un plataforma y si hay depende del tamaño de la platafoma si este bloque es bloque plataforma o no
    public void CheckPlatform(int i, int j, BaseCube block, List<List<BaseCube>> matrizCubes)
    {
        if (matrizCubes[i - 1][j].space > 0)
        {
            block.space = matrizCubes[i - 1][j].space - 1;
            return;
        }

        if (matrizCubes[i - 1][j].exists)
        {
            if (matrizCubes[i - 1][j].tamaño > 0 && !matrizCubes[i - 1][j - 1].exists
               && !matrizCubes[i - 1][j - 2].exists && !matrizCubes[i][j - 1].exists && !matrizCubes[i][j - 2].exists &&
               !matrizCubes[i - 2][j - 2].exists && !matrizCubes[i - 3][j - 2].exists)
            {
                block.tamaño = matrizCubes[i - 1][j].tamaño - 1;
                if (block.tamaño == 0)
                {
                    block.space = Modifiers.platformSpaceSize;
                }
                block.exists = true;
                block.GetComponent<MeshRenderer>().material.color = Color.blue;

                var spikeChance = Random.Range(0, 100);//random para determinar si tiiene pinches
                if (spikeChance < Modifiers.spikeChance && !matrizCubes[i - 1][j].spike /*&& block.tamaño!= 0*/)
                {
                    block.Spike();
                }
                else
                {
                    var coinChance = Random.Range(0, 100);//random para determinar si tiiene pinches
                    if (coinChance < Modifiers.spikeChance)
                    {
                        block.Coin();
                    }
                }
                return;
            }
        }

        var platformChance = Random.Range(0, 100);//random para determinar si es plataforma
        if (platformChance < Modifiers.platformBlockChance)
        {
            if (!matrizCubes[i - 1][j - 1].exists && !matrizCubes[i - 1][j - 2].exists && 
                !matrizCubes[i][j - 1].exists && !matrizCubes[i][j - 2].exists && 
                !matrizCubes[i - 2][j - 2].exists && !matrizCubes[i - 3][j - 2].exists)
            {
                block.tamaño = Random.Range(1, Modifiers.platfomrSize);
                block.exists = true;
                block.GetComponent<MeshRenderer>().material.color = Color.blue;
                return;
            }
        }
    }
}
