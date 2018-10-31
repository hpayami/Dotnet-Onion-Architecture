namespace App.Domain.Interfaces.Framework
{
    public interface IPaginated
    {
        bool HasNextPage { get; }
        bool HasPreviousPage { get; }
        int PageIndex { get; }
        int TotalCount { get; }
        int TotalPages { get; }
    }
}