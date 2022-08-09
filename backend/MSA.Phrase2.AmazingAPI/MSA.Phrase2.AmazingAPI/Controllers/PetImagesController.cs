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

        public PetImagesController(IHttpClientFactory clientFactory)
        {
            if (clientFactory == null) { throw new ArgumentNullException(nameof(clientFactory)); }

            _httpClientCat = clientFactory.CreateClient("CatImages");
            _httpClientDog = clientFactory.CreateClient("DogImages");
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
            var res = await _httpClientCat.GetAsync("/v1/images/search");
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
            var res = await _httpClientDog.GetAsync("/api/breeds/image/random");
            var content = await res.Content.ReadAsStringAsync();
            return Ok(content);
        }

    }
}
