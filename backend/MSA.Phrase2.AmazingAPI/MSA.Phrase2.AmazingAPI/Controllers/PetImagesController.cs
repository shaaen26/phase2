using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MSA.Phrase2.AmazingAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PetImagesController : ControllerBase
    {
        private readonly HttpClient _httpClientCat;
        private readonly HttpClient _httpClientDog;

        private readonly IConfiguration _configuration;

        public PetImagesController(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            if (clientFactory == null) { throw new ArgumentNullException(nameof(clientFactory)); }

            if (configuration == null) { throw new ArgumentNullException(nameof(configuration)); }

            _configuration = configuration;

            _httpClientCat = clientFactory.CreateClient(_configuration["CatClientName"]);
            _httpClientDog = clientFactory.CreateClient(_configuration["DogClientName"]);
        }

        /// <summary>
        /// return a json object contains a random cat image url
        /// </summary>
        /// <returns>json object</returns>

        [HttpGet]
        [Route("randomCat")]
        [ProducesResponseType(typeof(string), 200)]
        public async Task<IActionResult> GetRandomCatImage()
        {
            var res = await _httpClientCat.GetAsync(_configuration["CatRequestUrl"]);
            var content = await res.Content.ReadAsStringAsync();
            return Ok(content);
        }

        /// <summary>
        /// return a json object contains a random dog image url
        /// </summary>
        /// <returns>json object</returns>
        [HttpGet]
        [Route("randomDog")]
        [ProducesResponseType(typeof(string), 200)]
        public async Task<IActionResult> GetRandomDogImage()
        {
            var res = await _httpClientDog.GetAsync(_configuration["DogRequestUrl"]);
            var content = await res.Content.ReadAsStringAsync();
            return Ok(content);
        }

    }
}
