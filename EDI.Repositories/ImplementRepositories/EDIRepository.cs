using EDI.Contracts.Repository;
using EDI.Entities.Entities;
using Microsoft.Azure.Cosmos;

namespace EDI.Repositories.ImplementRepositories
{
    public class EDIRepository : IEDIRepository
    {
        private Container _context;

        public EDIRepository(CosmosClient dbClient, string databaseName, string containerName)
        {
            _context = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task<Tuple<Item, bool>> AddAsync(Item entity)
        {
            try
            {
                var result = await _context.CreateItemAsync(entity, new PartitionKey(entity.Id));
                return Tuple.Create(new Item(), true);
            }
            catch (CosmosException)
            {
                throw;
            }
            
        }

        public async Task<List<Item>> GetAllAsync()
        {
            try
            {
                var result = _context.GetItemLinqQueryable<Item>().GetEnumerator();
                return result as List<Item>;
            }
            catch (CosmosException)
            {
                throw;
            }
        }

        public async Task<List<Item>> GetByFilterAsync(string queryString)
        {
            try
            {
                var query = _context.GetItemQueryIterator<Item>(new QueryDefinition(queryString));
                List<Item> results = new List<Item>();
                while (query.HasMoreResults)
                {
                    var response = await query.ReadNextAsync();
                    results.AddRange(response.ToList());
                }
                return results;
            }
            catch (CosmosException)
            {
                throw;
            }
        }

        public async Task<Item> GetByIdAsync(string id)
        {
            try
            {
                ItemResponse<Item> response = await _context.ReadItemAsync<Item>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException)
            {
                throw;
            }
        }

        public async Task<bool> UpdateAsync(string id, Item item)
        {
            try
            {
                ItemResponse<Item> response = await _context.UpsertItemAsync<Item>(item, new PartitionKey(id)); ;
                return true;
            }
            catch (CosmosException)
            {
                throw;
            }
        }
    }
}
