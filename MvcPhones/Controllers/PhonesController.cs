using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcPhones.Data;
using MvcPhones.Models;

namespace MvcPhones.Controllers
{
    public class PhonesController : Controller
    {
        private readonly MvcPhonesDbContext _context;

        private readonly IHttpClientFactory _clientFactory;
        
        public PhonesController(MvcPhonesDbContext context, IHttpClientFactory clientFactory)
        {
            _context = context;
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            HttpClient client = _clientFactory.CreateClient(name: "PhonesApi");
       
            HttpRequestMessage request = new(method: HttpMethod.Get, 
            requestUri: "/api/v1/phones"
            );

            HttpResponseMessage response = await client.SendAsync(request);

            IEnumerable<Phones>? model = await response.Content.ReadFromJsonAsync<IEnumerable<Phones>>();

            return View (model);
        }

        
        
    }
}