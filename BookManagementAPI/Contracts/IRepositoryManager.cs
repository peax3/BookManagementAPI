using System.Threading.Tasks;

namespace BookManagementAPI.Contracts
{
    public interface IRepositoryManager
    {
        IBookRepository Book { get; }
        IAuthorRepository Author { get; }

        Task SaveChangesToDbAsync();
    }
}