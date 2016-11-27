using UnityEngine;
using System.Collections;

public class Objects
{
    private BasicItem objectVal = new BasicItem();
    private Spawner spawn = new Spawner();

    public void SetObjectState()
    {

    }
    
    public void GetObjectState()
    {

    }

    public void DestroyGameObject(GameObject p_GameObjectInstance)
    {

    }

    public void InstantiateAtLocation(GameObject p_GameObjectInstance, Transform p_SpawnPoint)
    {
        spawn.SpawnObjectAtSpot(p_SpawnPoint, p_GameObjectInstance);
    }
}
