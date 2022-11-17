using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JSON_Lab
{
    public class Book : IComparable
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("volumeInfo")]
        public VolumeInfo Information { get; set; }

        [JsonPropertyName("selfLink")]
        public string? SelfLink { get; set; }

        public int CompareTo(object? obj)
        {
            Book other = obj as Book;

            return this.Information.Title!.CompareTo(other.Information.Title);
        }

        public override string ToString()
        {
            return $"{Information.ToString()}\nBook Id: {Id}, Link: {SelfLink}\n\n";
        }
    }
    
    public class VolumeInfo
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("authors")]
        public List<string>? Authors { get; set; }

        public override string ToString()
        {
            return $"{Title} by {string.Join(", ", Authors!)}\nDescription: {Description}";
        }
    }
}
