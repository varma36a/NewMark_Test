using AzureBlobIntegration.Services;
using AzureBlobIntegration.Utils;
using Microsoft.AspNetCore.Mvc;

namespace AzureBlobIntegration.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController : ControllerBase
    {
        private readonly BlobService _blobService;

        public PropertiesController(BlobService blobService)
        {
            _blobService = blobService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProperties()
        {
            try
            {
                var jsonData = await _blobService.GetJsonDataAsync();
                var properties = CommonUtil.ParseJsonData(jsonData);
                return Ok(properties);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
