using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoilerMate.Models;

namespace BoilerMate.Services
{
    public class MockDataStore : IDataStore<JobReport>
    {
        List<JobReport> items;

        public MockDataStore()
        {
            items = new List<JobReport>();
            var mockItems = new List<JobReport>
            {
                //new JobReport { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                //new JobReport { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                //new JobReport { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                //new JobReport { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                //new JobReport { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                //new JobReport { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(JobReport item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(JobReport item)
        {
            var oldItem = items.Where((JobReport arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((JobReport arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<JobReport> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<JobReport>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        
    }
}