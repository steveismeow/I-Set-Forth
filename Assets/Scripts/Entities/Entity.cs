using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public TileManager tileManager { get; private set; }
    public ActionManager actionManager;

    [SerializeField]
    private EntityData entityData;
    [SerializeField]
    private EntityUIFrameData frame;

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

    //TurnManager bool indicating turn status
    protected bool myTurn;
    //State Machine trigger to end entity turn
    protected bool exitTurnState;

    //List of available actions
    public List<Action> availableActions = new List<Action>();


    #region State Variables
    public EntityStateMachine StateMachine { get; set; }

    //public TurnState turnState { get; private set; }
    //public WaitState aitState { get; private set; }
    public MoveState moveState { get; private set; }

    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        Initialize(entityData);

        //State Machine Setup
        StateMachine = this.gameObject.GetComponent<EntityStateMachine>();

        tileManager = GameObject.FindWithTag("TileManager").GetComponent<TileManager>();

    }

    private void Start()
    {
        print(StateMachine.name);

        moveState = new MoveState(this, StateMachine);
    }

    private void Update()
    {

    }

    #endregion

    /// <summary>
    /// Fetches starting stats based on entityData values
    /// </summary>
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

    /// <summary>
    /// Sets up entity for the beginning of it's turn.
    /// </summary>
    public virtual void StartTurn()
    {
        curAP = maxAP;
        myTurn = true;
        exitTurnState = false;


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


    public virtual bool ExitTurnState() => exitTurnState = true;
    public virtual bool GetExitTurnState() => exitTurnState;



    /// <summary>
    /// Get function to determine current position.
    /// </summary>
    /// <returns>curLocation</returns>
    public virtual Vector3 GetPostion() => curLocation;

}
