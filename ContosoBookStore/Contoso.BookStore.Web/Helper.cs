using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Contoso.BookStore.Web.Helper
{
    public class BookAPI
    {
        public HttpClient InitializeClient(IConfiguration configuration)
        {
            string _apiBaseURI = configuration["BookStoreAPI"];
            var client = new HttpClient();
            client.BaseAddress = new Uri(_apiBaseURI);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
            
    public class Book
    {
        private DateTime _datetime = DateTime.Now;

        public long BookId { get; set; }

        public string BookName { get; set; }

        public DateTime? PublishedDate { get { return _datetime; } set { _datetime = Convert.ToDateTime(value); } }

        public string Author { get; set; }

        public decimal Price { get; set; }
    }

    
}
