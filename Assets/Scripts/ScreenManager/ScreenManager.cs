using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public Stack<IScreen> _screenStack;

    static public ScreenManager Instance;

    void Awake()
    {
        Instance = this;

        _screenStack = new Stack<IScreen>();
    }

    private void Update()
    {
       

    }

    public void Pop()
    {
        if (_screenStack.Count <= 1) return; //Dejo uno para que siempre este el juego 
        

        _screenStack.Pop().Free();

        if (_screenStack.Count >= 1)
        {
            _screenStack.Peek().Activate();
        }
    }

    public void Push(IScreen newScreen)
    {
        if (_screenStack.Count > 0)
        {
            _screenStack.Peek().Deactivate();
        }

        _screenStack.Push(newScreen);

        newScreen.Activate();
    }

    public void Push(Transform screen, Transform parent = null)
    {
        screen.SetParent(parent);
        Push(screen.GetComponent<IScreen>());
    }
}
