public abstract class Command
{
    protected IEntity _entity = null;

    public Command(IEntity entity)
    {
        _entity = entity;
    }

    public abstract void Execute();
    public abstract void Undo();
}
