using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SoccerStarsConfigs")]
public class SoccerStarsConfigs : ScriptableObject
{
    public int teamsSize;
    public List<Material> sprites;
    public List<Vector3> teamVectors;
    public List<Vector3> opponentVectors;
    public int turnTimer;
}

