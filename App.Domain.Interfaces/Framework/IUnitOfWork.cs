namespace App.Domain.RepoInterfaces.Framework
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
