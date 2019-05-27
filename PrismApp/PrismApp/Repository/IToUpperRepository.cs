using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.Repository
{
    public interface IToUpperRepository
    {
        Task<string> ToUpperAsync(string input);
    }

    public class ToUpperRepository : IToUpperRepository
    {
        public async Task<string> ToUpperAsync(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("message", nameof(input));
            }

            await Task.Delay(3000);
            return input.ToUpper();
        }
    }
}
