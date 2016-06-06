using NReco.CF.Taste.Impl.Model.File;
using NReco.CF.Taste.Impl.Neighborhood;
using NReco.CF.Taste.Impl.Recommender;
using NReco.CF.Taste.Impl.Similarity;

namespace RL.Business.Iimplementation
{
    public class Test
    {
        public void Foo()
        {
            var model = new FileDataModel("data.csv");
            var similarity = new LogLikelihoodSimilarity(model);
            var neighborhood = new NearestNUserNeighborhood(3, similarity, model);
            var recommender = new GenericUserBasedRecommender(model, neighborhood, similarity);
            var recommendedItems = recommender.Recommend(userId, 5);
        }
    }
}
