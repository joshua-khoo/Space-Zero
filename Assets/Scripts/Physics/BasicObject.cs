using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicObject : MonoBehaviour {

    public bool isSelected;

    public bool hasSpawnedSelection;

    public int size;

    public Vector3 moveToLocation;

    
    public PhysicsController physicsController;

    public Vector2 pos;

    public bool isTrigger;

    public PhysicsShape shape;

    public List<BasicObject> objectsInside;


    //todo change e1, e2, and e3 to empire names
    public enum EmpireType { player, e1, e2, e3, neutral, pirate};

    public EmpireType empireType;



    public virtual void TriggerEntered(BasicObject basicObject)
    {

    }

    public virtual void TriggerExited(BasicObject basicObject)
    {

    }

    public virtual void Created(BasicObject owner, int damage, int speed, float lifeTime)
    {

    }

    public virtual void Started()
    {

    }

    public virtual void Destroyed()
    {

    }

    public virtual void DestroyObject(BasicObject owner)
    {

    }

    public virtual Vector2 getPos()
    {
        return pos;
    }
}
