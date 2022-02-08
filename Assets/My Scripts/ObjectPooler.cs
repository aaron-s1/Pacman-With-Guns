using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPooler : MonoBehaviour
{
    [SerializeField] GameObject objectToPool;
    [SerializeField] int amountToPool;
    [SerializeField] List<GameObject> pool;
    

    void Start() {
        pool = new List<GameObject>();
        GameObject pooledObjectsContainer = new GameObject("Pooled Bullets");

        for (int i = 0; i < amountToPool; i++) {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            pool.Add(obj);
            obj.transform.SetParent(pooledObjectsContainer.transform);

            obj.SetActive(false);
        }
    }

    public GameObject GetPooledObject(string objName = "") {
        for (int i = 0; i < pool.Count; i++) {
            var bullet = pool[i];

            if (!bullet.activeInHierarchy)                    
                return pool[i];
        }

        return null;
    }
}
    // [SerializeField] GameObject bulletFlashPool;

        // bulletFlashPool = new List<GameObject>();

            // obj = (GameObject)Instantiate(bulletFlashToPool);
            // obj.SetActive(false);
            // bulletFlashPool.Add(obj);

                // if (!bulletPool[i].activeInHierarchy) {                    
                //     return bulletPool[i];
                // }


        // else if (objName == "BulletFlash") {
        //     for (int i = 0; i < bulletFlashPool.Count; i++) {
        //         var bulletFlash = bulletFlashPool[i];

        //         if (!bulletFlash.activeInHierarchy)
        //             return bulletFlashPool[i];
        //     }
        // }    x