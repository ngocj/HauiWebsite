using Haui.Application.Dtos.BaseDto;
using Haui.Applications.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Haui.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _apiUrl;
        public UserController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _apiUrl = _configuration["BaseUrl:ApiUrl"];
        }

        public async Task<IActionResult> Index()
        {
            
            var users = await _httpClient.GetFromJsonAsync<List<UserDto>>($"{_apiUrl}User");

        
            return View(users);
        }

        // function view create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserDto user)
        {
            var response = await _httpClient.PostAsJsonAsync(_apiUrl, user);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(user);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await _httpClient.GetFromJsonAsync<UserDto>($"{_apiUrl}/{id}");
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserDto user)
        {
            var response = await _httpClient.PutAsJsonAsync(_apiUrl, user);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(user);
        }
        public async Task<IActionResult> Delete(UserDto user1)
        {
            var user = await _httpClient.GetFromJsonAsync<UserDto>($"{_apiUrl}/{user1.Id}");
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{_apiUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
       
    }
}
