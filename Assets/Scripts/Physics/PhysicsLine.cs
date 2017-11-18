using UnityEngine;
using System.Collections;

public class PhysicsLine{

    public float startX;
    public float startY;

    public float endX;
    public float endY;

	public PhysicsLine(float startX, float startY, float endX, float endY)
    {
        this.startX = startX;
        this.startY = startY;

        this.endX = endX;
        this.endY = endY;
    }
}
