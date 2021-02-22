using UnityEngine;

[CreateAssetMenu(fileName = "New Level Settings", menuName = "Level Settings")]
public class LevelSettings : ScriptableObject
{
    [Header("Level")]
    public int levelLength = 25;

    [Header("Ground gaps")]
    public float gapMin = 4;
    public float gapMax = 10;
    public float sidewaysDistance = 5f;

    [Header("Ground size")]
    public float widthMin = .6f;
    public float widthMax = 4f;
    public float lengthMin = 8f;
    public float lengthMax = 24f;
    public float thicknessMin = .15f;
    public float thicknessMax = .5f;
}
