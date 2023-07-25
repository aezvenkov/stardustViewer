using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StardustViewer.Model;
using System.Collections.Generic;

public class Geolocation
{
    public double First { get; set; }
    public double Second { get; set; }
}

public class RatioValue
{
    public string First { get; set; }
    public int Second { get; set; }
}

public class Record
{
    [JsonProperty("dateTime")]
    public string DateTime { get; set; }

    [JsonProperty("deviceProcessorId")]
    public int DeviceProcessorId { get; set; }

    [JsonProperty("firstNoiseLevel")]
    public int FirstNoiseLevel { get; set; }

    [JsonProperty("geolocation")]
    public Geolocation Geolocation { get; set; }

    [JsonProperty("imageBase64")]
    public String Image { get; set; }

    [JsonProperty("measurementNumber")]
    private int MeasurementNumber { get; set; }

    [JsonProperty("measurementTitle")]
    public string MeasurementTitle { get; set; }

    [JsonProperty("ratioValues")]
    public List<RatioValue> RatioValues { get; set; }

    [JsonProperty("secondNoiseLevel")]
    public int SecondNoiseLevel { get; set; }

    [JsonProperty("signalValues")]
    public List<int> SignalValues { get; set; }

    [JsonProperty("syncStatus")]
    public bool SyncStatus { get; set; }

    [JsonProperty("verificationStatus")]
    public bool VerificationStatus { get; set; }

    [JsonProperty("verifiedTaggantName")]
    public string VerifiedTaggantName { get; set; }
}
