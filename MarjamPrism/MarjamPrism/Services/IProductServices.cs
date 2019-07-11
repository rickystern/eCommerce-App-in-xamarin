using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MarjamPrism.Services
{
    public interface IProductServices
    {
        Task<ObservableCollection<Product>> GetProducts();
    }
}