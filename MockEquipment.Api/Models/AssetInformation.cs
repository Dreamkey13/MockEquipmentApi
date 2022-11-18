using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MockEquipment.Api.Models
{
    public class AssetInformation
    {
        public string SerialNo { get; set; } = string.Empty;

        public List<KeyValuePair<string, double>> DataPoints { get; set; } = new List<KeyValuePair<string, double>>();

        [JsonIgnore]
        public List<KeyValuePair<string, double>> NormalPoints { get; set; } = new List<KeyValuePair<string, double>>();

    }

}
