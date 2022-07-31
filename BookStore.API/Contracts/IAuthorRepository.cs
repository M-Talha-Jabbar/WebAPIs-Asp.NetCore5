using BookStore.API.ViewModels;
using System.Threading.Tasks;

namespace BookStore.API.Contracts
{
    public interface IAuthorRepository
    {
        Task<AuthorViewModel> GetAuthorByIdAsync(int id);
        Task<int> AddAuthorAsync(AuthorViewModel authorViewModel);
        Task<AuthorBooksViewModel> GetAuthorBooksAsync(int id);
    }
}
