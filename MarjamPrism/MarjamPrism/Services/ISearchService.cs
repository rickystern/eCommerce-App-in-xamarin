using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MarjamPrism.Services
{
    public interface ISearchService
    {
        Task<ObservableCollection<Product>> GetSearchResults(string SearchString);
    }
}