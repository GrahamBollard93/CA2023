using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcPhones.Data;
using MvcPhones.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace MvcPhones.Controllers
{
    public class PhonesController : Controller
    {
        private readonly MvcPhonesDbContext _context;
        private readonly IHttpClientFactory _clientFactory;
        private readonly UserManager<IdentityUser> _userManager;
        private IEnumerable<Phones>? allPhones;

        public PhonesController(MvcPhonesDbContext context, IHttpClientFactory clientFactory, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _clientFactory = clientFactory;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index(string? searchString, string sortOrder, int page = 1)
        {
            int pageSize = 6; // Number of products per page

            HttpClient client = _clientFactory.CreateClient(name: "PhonesApi");

            HttpRequestMessage request = new(
                method: HttpMethod.Get,
                requestUri: "api/v1/phones"
            );

            HttpResponseMessage response = await client.SendAsync(request);

            IEnumerable<Phones>? allProducts = await response.Content.ReadFromJsonAsync<IEnumerable<Phones>>();

            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : ""; // If the sortOrder variable is null or empty the retrun "name_desc", or else return nothing
              

            // Calculate the total number of pages
            int totalItems = allProducts!.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            // Ensure the requested page is within the valid range
            page = Math.Max(1, Math.Min(page, totalPages));

            // Retrieve the subset of products for the requested page
            IEnumerable<Phones>? phones = allPhones?
                .OrderBy(p => p.Brand)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var pagedResult = new PagedResult<Phones>
            {
                PageIndex = page,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPages,
                Items = phones
            };

             switch (sortOrder)
            {
                case "Brand":
                    allPhones = allPhones?.OrderByDescending(m => m.Brand);
                    break;
                case "League":
                    allPhones = allPhones?.OrderBy(m => m.Model);
                    break;
            }

            return View(pagedResult);
        }
    }

    
}