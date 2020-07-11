using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyClass : ScriptableObject
{
    public new string name;
    public int health;
    public float speed;
    public float decreasePerKey;
    public int keyCarryCount;
    public Sprite sprite;
}
