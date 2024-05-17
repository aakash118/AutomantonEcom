
using Newtonsoft.Json;
using System.Text.Json;

namespace Catalog.API.Data
{
    public class InitializeCatalogdata : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var storesession = store.LightweightSession();
            if (await storesession.Query<Product>().AnyAsync())
            {
                return;
            }
            storesession.Store(GetProductSeedData());
            await storesession.SaveChangesAsync();
          
        }
        public IEnumerable<Product> GetProductSeedData()
        {
            List<Product> products = new();            
            //File path needs to handled better.
            using (StreamReader r = new StreamReader(@"C:\Users\91932\source\repos\AutomantonEcom\AutomantonEcom\Services\Catalog\Catalog.API\Data\ProductSeedData.json"))
            {
                string json = r.ReadToEnd();
                products = JsonConvert.DeserializeObject<List<Product>>(json)!;
            }
            return products;
        }
    }
}
