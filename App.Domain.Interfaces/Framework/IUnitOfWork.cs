namespace App.Domain.Interfaces.Framework
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
