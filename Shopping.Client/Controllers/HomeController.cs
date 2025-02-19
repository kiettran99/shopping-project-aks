using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Shopping.Client.Models;

namespace Shopping.Client.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HttpClient _httpClient;

    public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClient = httpClientFactory.CreateClient("ShoppingAPIClient");
    }

    public async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetAsync("/product");
        if (response.IsSuccessStatusCode)
        {
            var products = await response.Content.ReadFromJsonAsync<IEnumerable<Product>>();
            return View(products);
        }

        return View(new List<Product>());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
