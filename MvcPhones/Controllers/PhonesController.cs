using System.IO.Compression;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcPhones.Data;
using MvcPhones.Models;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;




namespace MvcPhones.Controllers
{
    public class PhonesController : Controller
    {
        private readonly MvcPhonesDbContext _context;
        private readonly IHttpClientFactory _clientFactory;

        private IEnumerable<Phones>? allPhones;

        public PhonesController(MvcPhonesDbContext context, IHttpClientFactory clientFactory)
        {
            _context = context;
            _clientFactory = clientFactory;
        }


        public async Task<IActionResult> Index()
        {
            HttpClient client = _clientFactory.CreateClient(name: "PhonesApi");
            HttpRequestMessage request = new(method: HttpMethod.Get, requestUri:
            "/api/v1/phones");
            HttpResponseMessage response = await client.SendAsync(request);
            IEnumerable<Phones>? model = await response.Content.ReadFromJsonAsync<IEnumerable<Phones>>();
            return View(model);
        }

        //Phone Details
        public async Task<IActionResult> Details(int? id)
        {

            HttpClient client = _clientFactory.CreateClient(name: "PhonesApi");
            string requestUri = $"/api/v1/phones/{id}";

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var product = await response.Content.ReadFromJsonAsync<Phones>();
                return View(product);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                // Handle other error cases
                return StatusCode((int)response.StatusCode);
            }
        }


        //Get: Phones/Create

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
         public async Task<IActionResult> Create(Phones phones)
        {
            HttpClient client = _clientFactory.CreateClient(name: "PhonesApi");
            string requestUri = "/api/v1/phones";

            HttpResponseMessage response = await client.PostAsJsonAsync(requestUri, phones);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }

            //Edit: Phones

            [Authorize(Roles = "Admin")]
          public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            HttpClient client = _clientFactory.CreateClient(name: "PhonesApi");
            string requestUri = $"/api/v1/phones/{id}";

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var product = await response.Content.ReadFromJsonAsync<Phones>();
                return View(product);
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }

         [HttpPost]
         [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, Phones phones)
        {
            if (id != phones.Id)
            {
                return BadRequest();
            }

            HttpClient client = _clientFactory.CreateClient(name: "PhonesApi");
            string requestUri = $"/api/v1/phones/{id}";

            HttpResponseMessage response = await client.PutAsJsonAsync(requestUri, phones);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Details", new { id = phones.Id });
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }

  
    }
}