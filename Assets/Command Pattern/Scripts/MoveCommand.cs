using UnityEngine;

public class MoveCommand : Command
{
    private Vector3 _direction = Vector3.zero;

    public MoveCommand(IEntity entity, Vector3 direction) : base(entity)
    {
        _direction = direction;
    }

    public override void Execute()
    {
        _entity.transform.position += _direction * 0.1f;
    }

    public override void Undo()
    {
        _entity.transform.position -= _direction * 0.1f;
    }
}
