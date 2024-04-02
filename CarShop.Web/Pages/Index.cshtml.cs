using CarShop.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarShop.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly HttpClient _httpClient;

        public List<Car> Cars { get; set; } = new List<Car>();

        public IndexModel(ILogger<IndexModel> logger, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            HttpClient _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7171/api/");
            List<Car>? cars = await _httpClient.GetFromJsonAsync<List<Car>>("car/cars");

            this.Cars = cars ?? new List<Car>();
        }
    }
}
