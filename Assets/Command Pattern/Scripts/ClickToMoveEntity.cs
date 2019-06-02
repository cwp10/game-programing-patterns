using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ClickInputReader))]
[RequireComponent(typeof(CommandProcessor))]
public class ClickToMoveEntity : MonoBehaviour, IEntity
{
    private ClickInputReader _clickInputReader = null;
    private CommandProcessor _commandProcessor = null;
    private Coroutine _coroutine = null;

    private void Awake()
    {
        _clickInputReader = GetComponent<ClickInputReader>();
        _commandProcessor = GetComponent<CommandProcessor>();
    }

    private void Update()
    {
        var position = _clickInputReader.GetClickPosition();
        if (position != null)
        {
            _commandProcessor.ExecuteCommand(new MoveToCommand(this, position.Value));
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            _commandProcessor.Undo();
        }
    }

    public void MoveFromTo(Vector3 startPosition, Vector3 endPosition)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(MoveFromToAsync(startPosition, endPosition));
    }

    private IEnumerator MoveFromToAsync(Vector3 startPosition, Vector3 endPosition)
    {
        float elapsed = 0;

        while (elapsed < 1f)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsed);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = endPosition;
    }
}
