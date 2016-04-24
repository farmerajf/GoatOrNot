using System.Threading.Tasks;
using GoatOrNot.Models;

namespace GoatOrNot.Services
{
    /// <summary>
    /// A service providing goat API methods.
    /// </summary>
    public interface IGoatApiClient
    {
        /// <summary>
        /// Fetches a goat quote.
        /// </summary>
        /// <returns>The goat quote.</returns>
        Task<Quote> GetQuoteAsync();
    }
}
