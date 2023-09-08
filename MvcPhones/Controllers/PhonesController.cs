using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcPhones.Data;
using MvcPhones.Models;



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


        public async Task<IActionResult> Index(int pg=1)
        {
            

            
            HttpClient client = _clientFactory.CreateClient(name: "PhonesApi");
            HttpRequestMessage request = new(method: HttpMethod.Get, requestUri:
            "/api/v1/phones");
            HttpResponseMessage response = await client.SendAsync(request);
            IEnumerable<Phones>? model = await response.Content.ReadFromJsonAsync<IEnumerable<Phones>>();
            return View(model);
        }
    

        
        //Get: Phones/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
    }
}