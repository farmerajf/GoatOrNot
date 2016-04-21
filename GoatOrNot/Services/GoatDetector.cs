using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision;

namespace GoatOrNot.Services
{
    public class GoatDetector : IGoatDetector
    {
        private readonly IVisionServiceClient _visionServiceClient;

        public GoatDetector(IVisionServiceClient visionServiceClient)
        {
            _visionServiceClient = visionServiceClient;
        }

        public async Task<bool> IsGoat(string imageUri)
        {
            var analysisResult = await _visionServiceClient.GetTagsAsync(imageUri);
            return analysisResult.Tags.Any(tag => tag.Name.Equals("goat", StringComparison.InvariantCultureIgnoreCase));
        }
    }
}