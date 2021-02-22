using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public LevelSettings settings;
    public GameObject groundPrefab;
    public GameObject finishPrefab;
    public List<Material> goundMaterials;
    
    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        float distanceInLevel = 0;
        float currentX = 0;

        for (int i = 0; i < settings.levelLength; i++)
        {
            GameObject newGround = Instantiate(groundPrefab, this.transform);
            Material randomMat = goundMaterials[Random.Range(0, goundMaterials.Count)];
            newGround.GetComponent<MeshRenderer>().material = randomMat;
            newGround.name = string.Format("Ground {0}", i);

            Vector3 newPos;
            float gap = Random.Range(settings.gapMin, settings.gapMax);

            // First ground
            if (i == 0)
            {
                // Fisrt plane should be at spawn.
                newPos = Vector3.zero;
                newGround.transform.localScale = new Vector3(3, .2f, 50);
                distanceInLevel += (newGround.transform.localScale.z / 2) + gap;
            }
            // Last Ground
            else if (i == settings.levelLength - 1)
            {
                newGround.transform.localScale = new Vector3(3, .2f, 50);
                newPos = new Vector3(
                    currentX + Random.Range(-settings.sidewaysDistance, settings.sidewaysDistance),
                    0,
                    distanceInLevel + newGround.transform.localScale.z / 2
                );

                // Spawn Finish
                Instantiate(finishPrefab, newPos, Quaternion.identity);
            }
            // Other grounds
            else
            {
                newGround.transform.localScale = getRandomSize();
                newPos = new Vector3(
                    currentX + Random.Range(-settings.sidewaysDistance, settings.sidewaysDistance),
                    0,
                    distanceInLevel + newGround.transform.localScale.z / 2
                );
                distanceInLevel += newGround.transform.localScale.z + gap;
            }

            currentX = newGround.transform.position.x;
            newGround.transform.position = newPos;
        }
    }

    Vector3 getRandomSize()
    {
        float width = Random.Range(settings.widthMin, settings.widthMax);
        float Thickness = Random.Range(settings.thicknessMin, settings.thicknessMax);
        float length = Random.Range(settings.lengthMin, settings.lengthMax);
        return new Vector3(width, Thickness, length);
    }

}
