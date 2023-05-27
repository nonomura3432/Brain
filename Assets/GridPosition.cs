using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GridPosition
{

    public static readonly int numOfDivide = 4;
    
    
    public static Vector3 GridPosByRandom(float xRatio)
    {
        int rand = Random.Range(0, numOfDivide);
        return GridPosByIndex(xRatio, rand);
    }
    
/// <summary>
/// 縦に_numOfDivide分割したときの、xRatioに対応する座標を返す
/// </summary>
/// <param name="xRatio">画面の横に対する割合</param>
/// <param name="yIndex">分割時の下から数えた添え字</param>
/// <returns></returns>
    public static Vector3 GridPosByIndex(float xRatio, int yIndex)
    {
        int height = Screen.height;
        float unitHeight = height / numOfDivide;
        float posY = yIndex *unitHeight + 1/2.0f * unitHeight;
        var vector = new Vector3(xRatio * Screen.width, posY, 0);
        Vector2 screenPosY =  Camera.main.ScreenToWorldPoint(vector);  
        return screenPosY;
    }

}
