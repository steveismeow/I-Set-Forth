using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EntityData : ScriptableObject
{
    public string entityName;

    public int baseAP;
    public int baseHealth;
    public int baseMana;
    public int baseAttack;
    public int baseMovementSpeed;
    public int baseVisionRadius;

    public Sprite entitySprite;
}
