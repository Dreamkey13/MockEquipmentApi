using Microsoft.AspNetCore.Mvc;
using MockEquipment.Api.Models;
using MockEquipment.Api.Services;
using static MockEquipment.Api.Services.ConnectionService;

namespace MockEquipment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EquipmentController : ControllerBase
    {
        private ILogger<EquipmentController> logger;
        private readonly IConnectionService connService;
        private readonly IAssetService assetService;

        public EquipmentController(
            ILogger<EquipmentController> logger,
            IConnectionService connService,
            IAssetService assetService)
        {
            this.logger = logger;
            this.connService = connService;
            this.assetService = assetService;
        }

        [HttpGet]
        [Route("Connect/{serialNo}")]
        public Connection Connect(string serialNo)
        {
            return connService.CreateConnection(serialNo);
        }

        [HttpGet]
        [Route("Disconnect/{connectionId:Guid}")]
        public IActionResult Disconnect(Guid connectionId)
        {
            connService.RemoveConnection(connectionId);

            return Ok();
        }
        [HttpGet]
        [Route("Fetch/{connectionId:Guid}")]
        public IActionResult Fetch(Guid connectionId)
        {
            var connection = connService.GetConnection(connectionId);
            if (connection == null)
                return Unauthorized();

            var asset = assetService.GetAsset(connection.SerialNo);
            if (asset == null)
                return NotFound();

            return Ok(asset);
        }

    }
}