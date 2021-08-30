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

    protected bool myTurn;

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

    private void Update()
    {
        
    }

    /// <summary>
    /// Sets up entity for the beginning of it's turn.
    /// </summary>
    public virtual void StartTurn()
    {
        myTurn = true;
    }

    /// <summary>
    /// Finishes entity turn.
    /// </summary>
    public virtual void EndOfTurnTrigger() => myTurn = false;

    /// <summary>
    /// Get function to access myTurn from this class.
    /// </summary>
    /// <returns>myTurn</returns>
    public virtual bool GetTurnStatus() => myTurn;

    public virtual Vector3 GetPostion() => curLocation;
}
