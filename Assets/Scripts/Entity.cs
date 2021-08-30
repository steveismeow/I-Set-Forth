using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected TurnManager turnManager;

    [SerializeField]
    private EntityData entityData;

    public int level;
    public int maxAP;
    public int maxHealth;
    public int maxMana;
    public int attack;
    public int movementSpeed;
    public int visionRadius;

    public int curAP;
    public int curHealth;
    public int curMana;

    private Vector3 curLocation;

    protected bool endOfTurn;

    private void Awake()
    {
        Initialize(entityData);

    }

    private void Start()
    {

    }

    public void Initialize(EntityData entityData)
    {
        this.maxHealth = entityData.baseHealth;
        this.maxAP = entityData.baseAP;
        this.maxMana = entityData.baseMana;
        this.attack = entityData.baseAttack;
        this.movementSpeed = entityData.baseMovementSpeed;
        this.visionRadius = entityData.baseVisionRadius;

        this.curHealth = entityData.baseHealth;
        this.curAP = entityData.baseAP;
        this.curMana = entityData.baseMana;
    }


    public virtual void StartTurn()
    {
        print("Player's turn has begun");
        endOfTurn = false;
    }

    public virtual bool EndOfTurnTrigger() => endOfTurn = true;

    public virtual bool GetEndOfTurnBool() => endOfTurn;
}
