using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("Состояния")]
    [SerializeField] private CameraState normalState;
    
    public static CameraMove singleton { get; private set; }
    public GameObject purpose {get; private set;}
    private CameraState currentState;

    private void Start()
    {
        singleton = this;
        purpose = GameObject.FindGameObjectsWithTag("Player")[0];
        currentState = normalState;
        currentState.camera = this;
        currentState.Init();
    }
    private void Update()
    {
        currentState.Run();
    }
    public void NewPurpose(GameObject obj)
    {
        purpose = obj;
    }
}
