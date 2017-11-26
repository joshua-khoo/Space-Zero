using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipImage {

    
    public Sprite shipImage;

    public ShipImage(Texture2D texture, int width, int height)
    {
        shipImage = Sprite.Create(texture, new Rect(0, 0, width, height), new Vector2(0.5f, 0.5f));
        
    }


}
