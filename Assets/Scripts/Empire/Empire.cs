using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Empire : MonoBehaviour {


    List<Planet> ownedPlanets = new List<Planet>();

    public long money;

    public Color empireColor;
    public string empireName;


    public void SetUp(Color color, string name)
    {
        empireColor = color;
        empireName = name;
        money = 10000000000000000;

    }

    public virtual void SetUp()
    {
        SetUp(Color.black, "none");
    }

	
}
