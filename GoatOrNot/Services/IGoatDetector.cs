using System;
using System.Threading.Tasks;

namespace GoatOrNot.Services
{
    public interface IGoatDetector
    {
        Task<bool> IsGoat(string imageUri);
    }
}
