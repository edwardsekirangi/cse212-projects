using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using System.Linq;
using System.Net.Http;
public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>

    //Converted the return value of the function to a string
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE
        //First create the set to store the values
        var set1 = new HashSet<string>();
        var result = new List<string>();

        //Next we want to iterate through the letters in words
        foreach (string word in words)
        {
            //Let us compute the reverse word that may exist. 
            //To prevent creating another for loop and getting O(n^2), we went for direct code
            string reverse = new string(new char[] { word[1], word[0] });

            //If the reverse exists, we found a symmetrical pair
            if (set1.Contains(reverse))
            {
                //Format the pair as "word1 & word2"
                //result.Add(word);
                //result.Add(reverse);

                string pair = $"{word} & {reverse}";
                result.Add(pair);
            }

            //Add the word to the set
            set1.Add(word);
        }
        //Convert our list to an array to prevent problems in other parts of our code
        string[] results = result.ToArray();
        return results;
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE
            // For this, we will access the 3rd index and update the dictionary with it
            //And we will make sure it is the key to make the values inside the dict unique

            string degree = fields[3].Trim();

            //Now for the int value, we simply want an increasing value for the count
            degrees[degree] = degrees.GetValueOrDefault(degree) + 1;
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        //First we remove the spaces an convert to lowercase
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        // If lengths differ, they can't be anagrams
        if (word1.Length != word2.Length)
            return false;

        //Use dictionary to count characters in word1
        Dictionary<char, int> charCount = new Dictionary<char, int>();


        // Count characters in word1
        foreach (char c in word1)
        {
            if (charCount.ContainsKey(c))
                charCount[c]++;
            else
                charCount[c] = 1;
        }

        // Subtract counts for word2
        foreach (char c in word2)
        {
            if (!charCount.ContainsKey(c) || charCount[c] == 0)
                return false;
            charCount[c]--;
        }

        // Check if all counts are zero
        foreach (var count in charCount.Values)
        {
            if (count != 0)
                return false;
        }

        return true;

    }



    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>

    public class FeatureCollection
    {
        [JsonPropertyName("features")]
        public Feature[] Features { get; set; }
    }

    public class Feature
    {
        [JsonPropertyName("properties")]
        public Properties Properties { get; set; }
    }

    public class Properties
    {
        [JsonPropertyName("place")]
        public string Place { get; set; }

        [JsonPropertyName("mag")]
        public double Mag { get; set; }
    }
        public static string[] EarthquakeDailySummary()
        {
            const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
            using var client = new HttpClient();
            using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
            using var reader = new StreamReader(jsonStream);
            var json = reader.ReadToEnd();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

            // Check if featureCollection or Features is null or empty
            if (featureCollection?.Features == null || featureCollection.Features.Length == 0)
            {
                return Array.Empty<string>();
            }

            // Extract place and magnitude, format as "[place] - Mag [magnitude]"
            var summaries = featureCollection.Features
                .Select(f => $"{f.Properties.Place ?? "Unknown location"} - Mag {f.Properties.Mag:F2}")
                .ToArray();

            return summaries;
        }
    
}
        
    