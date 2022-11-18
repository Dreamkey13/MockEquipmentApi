using MockEquipment.Api.Models;

namespace MockEquipment.Api.Services
{
    public interface IAssetService
    {
        AssetInformation? GetAsset(string serialNo);
        List<AssetInformation> GetAssets();
    }
}