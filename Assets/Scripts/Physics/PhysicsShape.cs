using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhysicsShape
{

    




    //Polygon variables
    public List<PhysicsLine> lines = new List<PhysicsLine>();






    public void setUpPolygon(List<PhysicsLine> lines)
    {
        this.lines = lines;

        
    }

   
}
