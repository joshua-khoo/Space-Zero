using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Random = System.Random;


public class Planet : MonoBehaviour {

    private Polyhedra surface;
    private Random globalRandom;

    public int randomSeed;
    public int subdivisionLevel = 2;
    public float distortionLevel;
    public float oxygenLevel;

    public float PlanetScale {
        get {
            return this.transform.localScale.x;
        }
    }

    private void Awake() {
        // Generate
    }

    public void Generate() {
        this.globalRandom = new Random(randomSeed);
        this.surface = GeneratePlanetPolyhedra();
        this.surface.GeneratePlanetTopology();
        this.GeneratePlanetElevation();
        this.GeneratePlanetMesh();
    }
	
	void Update () {

    }

    private Polyhedra GeneratePlanetPolyhedra() {
        var mesh = Utils.GenerateSubdividedIcosahedron(this.subdivisionLevel);
        mesh.planet = this;
        var totalDistortion = Math.Ceiling(mesh.edges.Count * this.distortionLevel);
        var remainingIterations = 6;
        int i;
        while (remainingIterations > 0) {
            var iterationDistortion = (int)Math.Floor(totalDistortion / remainingIterations);
            totalDistortion -= iterationDistortion;
            mesh.DistortMesh(iterationDistortion, globalRandom);
            mesh.RelaxMesh(0.5f);
            --remainingIterations;
        }

        var averageNodeRadius = Math.Sqrt(4 * Math.PI / mesh.nodes.Count);
        var minShiftDelta = averageNodeRadius / 50000 * mesh.nodes.Count;
        var maxShiftDelta = averageNodeRadius / 50 * mesh.nodes.Count;

        float priorShift, shiftDelta;
        var currentShift = mesh.RelaxMesh(0.5f);

        do {
            priorShift = currentShift;
            currentShift = mesh.RelaxMesh(0.5f);
            shiftDelta = System.Math.Abs(currentShift - priorShift);
        } while (shiftDelta >= minShiftDelta);

        for (i = 0; i < mesh.faces.Count; ++i) {
            var face = mesh.faces[i];
            var p0 = mesh.nodes[face.n[0]].p;
            var p1 = mesh.nodes[face.n[1]].p;
            var p2 = mesh.nodes[face.n[2]].p;
            face.centroid = Utils.CalculateFaceCentroid(p0, p1, p2).normalized;
        }

        for (i = 0; i < mesh.nodes.Count; ++i) {
            var node = mesh.nodes[i];
            var faceIndex = node.f[0];
            for (var j = 1; j < node.f.Count - 1; ++j) {
                faceIndex = Utils.FindNextFaceIndex(mesh, i, faceIndex);
                var k = node.f.IndexOf(faceIndex);
                node.f[k] = node.f[j];
                node.f[j] = faceIndex;
            }
        }
        this.surface = mesh;
        return mesh;
    }

    private void GeneratePlanetMesh() {

    }

    #region PlanetElevation
    void GeneratePlanetElevation() {

    }
    #endregion
}
