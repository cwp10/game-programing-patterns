﻿using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(CommandProcessor))]
public class Entity : MonoBehaviour, IEntity
{
    private InputReader _inputReader = null;
    private CommandProcessor _commandProcessor = null;

    public void MoveFromTo(Vector3 startPosition, Vector3 endPosition)
    {
        throw new System.NotImplementedException();
    }

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _commandProcessor = GetComponent<CommandProcessor>();
    }

    private void Update()
    {
        var direction = _inputReader.ReadInput();
        if (direction != Vector3.zero)
        {
            var moveCommand = new MoveCommand(this, direction);
            _commandProcessor.ExecuteCommand(moveCommand);
        }
        if (_inputReader.ReadUndo())
        {
            _commandProcessor.Undo();
        }

        float scaleDirection = _inputReader.ReadScale();

        if (scaleDirection != 0f)
        {
            _commandProcessor.ExecuteCommand(new ScaleCommand(this, scaleDirection));
        }
    }
}
