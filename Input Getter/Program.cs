using System;
using System.IO;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        string html = string.Empty;
        string url = @"https://adventofcode.com/2022/day/2/input";

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.CookieContainer = new CookieContainer();
        request.CookieContainer.Add(new Cookie("session", "53616c7465645f5ff9df14863b39f8802173cc8f32559be5684b2df4b0e405b7090b9f97e7658065823824e61cd2f3c785785dea89879ff5cd6b475ddfab20e0", "/"));
        request.AutomaticDecompression = DecompressionMethods.GZip;

        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            html = reader.ReadToEnd();
        }
        Console.WriteLine(html);
    }
}
