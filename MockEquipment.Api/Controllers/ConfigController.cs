using Microsoft.AspNetCore.Mvc;
using MockEquipment.Api.Models;
using MockEquipment.Api.Services;

namespace MockEquipment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigController
    {
        private readonly IAssetService assetService;

        public ConfigController(IAssetService assetService)
        {
            this.assetService = assetService;
        }
        [HttpGet]
        [Route("/Assets")]
        public List<AssetInformation> GetAssets()
        {
            return assetService.GetAssets();
        }
    }
}
