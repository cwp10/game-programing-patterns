using UnityEngine;

public class MoveToCommand : Command
{
    private Vector3 _destination = Vector3.zero;
    private Vector3 _originalPosition = Vector3.zero;

    public MoveToCommand(IEntity entity, Vector3 destination) : base(entity)
    {
        _destination = destination;
    }

    public override void Execute()
    {
        _originalPosition = _entity.transform.position;
        _entity.MoveFromTo(_originalPosition, _destination);
    }

    public override void Undo()
    {
        _entity.MoveFromTo(_entity.transform.position, _originalPosition);
    }
}
