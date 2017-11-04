using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PhysicsController : MonoBehaviour {

    List<BasicObject> basicObjects = new List<BasicObject>();
    
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        

	}

    


    public void checkArea(BasicObject trigger)
    {
        for (int i = 0; i < basicObjects.Count; i++)
        {
            if (basicObjects[i] != null)
            {
                if (trigger != basicObjects[i] && !basicObjects[i].isTrigger)
                {
                    if (triggered(trigger, basicObjects[i]))
                    {
                        if (!trigger.objectsInside.Contains(basicObjects[i]))
                        {

                            trigger.TriggerEntered(basicObjects[i]);
                        }
                    }
                    else
                    {


                        if (trigger.objectsInside.Contains(basicObjects[i]))
                        {
                            trigger.TriggerExited(basicObjects[i]);
                        }
                    }
                }
            }
            else
            {
                basicObjects.RemoveAt(i);
            }

            


        }
    }

    public void singleObjectCheck(BasicObject trigger, BasicObject obj)
    {
        if (triggered(trigger, obj))
        {
            trigger.TriggerEntered(obj);
        }



    }

    

    bool triggered(BasicObject trigger, BasicObject basicObject)
    {
        bool collision = false;

        PhysicsLine[] lines1 = trigger.shape.lines.ToArray();
        PhysicsLine[] lines2 = basicObject.shape.lines.ToArray();

        foreach (PhysicsLine line1 in lines1)
        {
            foreach (PhysicsLine line2 in lines2)
            {
                if (intersects(
                    line1.startX + trigger.pos.x, line1.startY + trigger.pos.y,
                    line1.endX + trigger.pos.x, line1.endY + trigger.pos.y,
                    line2.startX + basicObject.pos.x, line2.startY + basicObject.pos.y,
                    line2.endX + basicObject.pos.x, line2.endY + basicObject.pos.y))
                {
                    
                    collision = true;
                    
                }
            }
        }
        

        if (!collision)
        {
            if (pointIsInside(trigger, basicObject))
            {
                
                collision = true;
            }
        }

        if (!collision)
        {
            if (pointIsInside(basicObject, trigger))
            {

                collision = true;
            }
        }



        return collision;
    }

    bool pointIsInside(BasicObject trigger, BasicObject basicObject)
    {
        bool isInside = false;

        List<Vector2> points = getPoints(trigger);

        int i;
        int j;

        Vector2 pos = basicObject.getPos();

        for (i = 0, j = points.Count - 1; i < points.Count; j = i++)
        {
            if ((points[i].y > pos.y) != (points[j].y > pos.y) &&
                (pos.x < (points[j].x - points[i].x) * (pos.y - points[i].y) / (points[j].y - points[i].y) + points[i].x))
            {
                
                isInside = !isInside;
            }
            
        }


        

        return isInside;

    }

    List<Vector2> getPoints(BasicObject trigger)
    {
        List<Vector2> points = new List<Vector2>();

        List<PhysicsLine> lines = trigger.shape.lines;


        for (int i = 0; i < lines.Count; i++)
        {
            points.Add(new Vector2(lines[i].startX + trigger.pos.x, lines[i].startY + trigger.pos.y));
        }
        

        return points;
    }


    bool intersects(float p0_x, float p0_y, float p1_x, float p1_y,
    float p2_x, float p2_y, float p3_x, float p3_y)
    {
        bool isCollision = false;
            float s1_x, s1_y, s2_x, s2_y;
            s1_x = p1_x - p0_x; s1_y = p1_y - p0_y;
            s2_x = p3_x - p2_x; s2_y = p3_y - p2_y;

            float s, t;
            s = (-s1_y * (p0_x - p2_x) + s1_x * (p0_y - p2_y)) / (-s2_x * s1_y + s1_x * s2_y);
            t = (s2_x * (p0_y - p2_y) - s2_y * (p0_x - p2_x)) / (-s2_x * s1_y + s1_x * s2_y);

            if (s >= 0 && s <= 1 && t >= 0 && t <= 1)
            {

                isCollision = true;
                
            }

            return isCollision; // No collision
    }
    
    

    public void addObject(BasicObject basicObject)
    {
        basicObjects.Add(basicObject);
    }

    public void removeObject(BasicObject basicObject)
    {
        basicObjects.Remove(basicObject);
    }

    
}
