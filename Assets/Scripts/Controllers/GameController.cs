using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public EmpireA empireAPrefab;
    public EmpireB empireBPrefab;
    public EmpireC empireCPrefab;
    List<Empire> empires = new List<Empire>();

    Galaxy galaxy;

    bool hasSetUpEmpires = false;

	// Use this for initialization
	void Start () {

        galaxy = FindObjectOfType<Galaxy>();

        empires.Add(Instantiate(empireAPrefab));
        empires.Add(Instantiate(empireBPrefab));
        empires.Add(Instantiate(empireCPrefab));

    }
	
	// Update is called once per frame
	void Update () {
        if (!hasSetUpEmpires && galaxy.hasGenerated)
        {
            hasSetUpEmpires = false;

            foreach (Empire e in empires)
            {
                e.SetUp();
            }
        }
	}
}
