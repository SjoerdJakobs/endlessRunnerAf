using UnityEngine;
using System.Collections;

public class LaserHandeler : MonoBehaviour {

    private int randomPatern;
    private int laserSpawned;
    public GameObject laser;

	void Update (){

        if (laserSpawned == 0 && Random.Range(0, 500) == 0)
        {
            if (Random.Range(0, 10) < 5)
            {
                patern1();
            }
            else patern2();
            
            laserSpawned++;
        }

        if (laserSpawned != 0) laserSpawned++;
        if (laserSpawned == 500) laserSpawned = 0;
    }

    void patern1()
    {
        Instantiate(laser, new Vector2(35f, 20f), Quaternion.identity);
        Instantiate(laser, new Vector2(55f, 20f), Quaternion.identity);
    }

    void patern2()
    {
        Instantiate(laser, new Vector2(45f, 20f), Quaternion.identity);
    }

}
