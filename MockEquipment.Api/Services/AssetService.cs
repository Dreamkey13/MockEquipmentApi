using MockEquipment.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockEquipment.Api.Services
{
    public class AssetService : IAssetService
    {
        private List<AssetInformation> assets;

        public AssetService()
        {
            assets = new List<AssetInformation>();

            LoadAssets();
        }

        private void LoadAssets()
        {
            assets.Clear();
            assets.Add(new AssetInformation()
            {
                SerialNo = "MX53-923-43-AX",
                NormalPoints = new List<KeyValuePair<string, double>> {
                    new KeyValuePair<string, double>("Temperature", 27.2) }
            });
            assets.Add(new AssetInformation()
            {
                SerialNo = "12FG-2453422345-2",
                NormalPoints = new List<KeyValuePair<string, double>> {
                    new KeyValuePair<string, double>("Temperature", 22.0) }
            });
            assets.Add(new AssetInformation()
            {
                SerialNo = "BTA2354573453467",
                NormalPoints = new List<KeyValuePair<string, double>> {
                    new KeyValuePair<string, double>("Temperature", 32.0),
                    new KeyValuePair<string, double>("Cyles", 1530.0),
                    new KeyValuePair<string, double>("RPM", 2750.0)
                }
            });
            assets.Add(new AssetInformation()
            {
                SerialNo = "DHDF-24535674-434",
                NormalPoints = new List<KeyValuePair<string, double>> {
                    new KeyValuePair<string, double>("Cyles", 1530.0),
                    new KeyValuePair<string, double>("PSI", 2750.0)
                }
            });
            assets.Add(new AssetInformation()
            {
                SerialNo = "3453434224EFHF4FR4",
                NormalPoints = new List<KeyValuePair<string, double>> {
                    new KeyValuePair<string, double>("Cyles", 1530.0),
                    new KeyValuePair<string, double>("RPM", 652),
                    new KeyValuePair<string, double>("PSI", 2750.0)
                }
            });
            assets.Add(new AssetInformation()
            {
                SerialNo = "23534FDDF45Y645",
                NormalPoints = new List<KeyValuePair<string, double>> {
                    new KeyValuePair<string, double>("Temperature", 245.0),
                    new KeyValuePair<string, double>("Seconds", 96),
                }
            });
            assets.Add(new AssetInformation()
            {
                SerialNo = "23534SDSDG543564",
                NormalPoints = new List<KeyValuePair<string, double>> {
                    new KeyValuePair<string, double>("Temperature", 245.0),
                    new KeyValuePair<string, double>("Seconds", 96),
                }
            });
        }

        public AssetInformation? GetAsset(string serialNo)
        {
            var asset = assets.FirstOrDefault(m => m.SerialNo == serialNo);
            if (asset != null)
            {
                GenerateDataPoints(asset);
            }

            return asset;
        }

        public List<AssetInformation> GetAssets()
        {
            foreach (var asset in assets)
            {
                asset.DataPoints.Clear();
                foreach (var pair in asset.NormalPoints)
                {
                    asset.DataPoints.Add(pair);
                }
            }

            return assets;
        }

        private void GenerateDataPoints(AssetInformation asset)
        {
            asset.DataPoints.Clear();
            foreach (var pair in asset.NormalPoints)
            {
                var r = new Random().Next(100);

                if (r > 95)
                    asset.DataPoints.Add(GeneratePoint(pair, .1, .5));
                else if (r > 80)
                    asset.DataPoints.Add(GeneratePoint(pair, .05, .1));
                else
                    asset.DataPoints.Add(GeneratePoint(pair, 0, .05));

            }

        }

        private KeyValuePair<string, double> GeneratePoint(KeyValuePair<string, double> source, double min, double max)
        {
            var min_v = source.Value * min * 100;
            var max_v = source.Value * max * 100;
            var variance = new Random().Next((int)min_v, (int)max_v) / 100;

            var r = new Random().Next(100);
            if (r < 50)
                variance = variance * -1;

            return new KeyValuePair<string, double>(source.Key, source.Value + variance);
        }
    }
}
