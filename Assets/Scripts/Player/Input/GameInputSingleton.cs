using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputSingleton : MonoBehaviour
{
    private GameInput gameInput;
    public GameInput GameInput { get => gameInput; set => gameInput = value; }
    public static GameInputSingleton Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            gameInput = new GameInput();
            return;
        }

        Destroy(this.gameObject);
    }
}
