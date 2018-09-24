using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public class Anime
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "Rating")]
        public string Rating { get; set; }

        [JsonProperty(PropertyName = "episode")]
        public int Episode { get; set; }

        [JsonProperty(PropertyName = "categorie")]
        public string Category { get; set; }

        [JsonProperty(PropertyName = "studio")]
        public string Studio { get; set; }

        [JsonProperty(PropertyName = "img")]
        public string Img { get; set; }
    }
}
