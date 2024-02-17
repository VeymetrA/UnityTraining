using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Test", menuName = "Data/Waves")]

public class Waves : ScriptableObject
{
    public int[] enemiesCount = new int[] { 2, 4, 6, 8, 10 };
    public int[] timer = new int[] { 2, 4, 6, 8, 10 };
    public int enemyHealth = 30;
}
