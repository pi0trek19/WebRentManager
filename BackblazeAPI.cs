using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebRentManager
{
    public class BackblazeAPI
    {
        readonly string bucketId = "354d31f11667bde877380c15"; //testbucket
        public string AutorizationToken { get; set; }
        public string ApiUrl { get; set; }
        public string DownloadUrl { get; set; }

        static public string b2UrlEncode(string str)
        {
            if (str == "/")
            {
                return str;
            }
            return Uri.EscapeDataString(str);
        }
        static public string b2UrlDecode(string str)
        {
            if (str == "+")
            {
                return " ";
            }
            return Uri.UnescapeDataString(str);
        }
        public void AutorizeAccount()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://api.backblazeb2.com/b2api/v2/b2_authorize_account");
            string credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes("0025d1167d878c50000000001" + ":" + "K002/cI5NIPB7lH2uNyVG1bKkmkPtlU"));
            webRequest.Headers.Add("Authorization", "Basic " + credentials);
            webRequest.ContentType = "application/json; charset=utf-8";
            WebResponse response = (HttpWebResponse)webRequest.GetResponse();
            string json = new StreamReader(response.GetResponseStream()).ReadToEnd();
            response.Close();
            BackblazeAutorizeResponse autorizeResponse = JsonConvert.DeserializeObject<BackblazeAutorizeResponse>(json);
            AutorizationToken = autorizeResponse.authorizationToken;
            ApiUrl = autorizeResponse.apiUrl;
            DownloadUrl = autorizeResponse.downloadUrl;           
        }
        public BakcblazeGetUploadUrlResponse GetUploadUrl()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(ApiUrl + "/b2api/v2/b2_get_upload_url");
            string body = "{\"bucketId\":\"" + bucketId + "\"}";
            var data = Encoding.UTF8.GetBytes(body);
            webRequest.Method = "POST";
            webRequest.Headers.Add("Authorization", AutorizationToken);
            webRequest.ContentType = "application/json; charset=utf-8";
            webRequest.ContentLength = data.Length;
            using (var stream = webRequest.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
                stream.Close();
            }
            WebResponse response = (HttpWebResponse)webRequest.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            response.Close();
            BakcblazeGetUploadUrlResponse urlResponse = JsonConvert.DeserializeObject<BakcblazeGetUploadUrlResponse>(responseString);
            return urlResponse;
        }
        public string UploadFile(string fileName,byte[] file,string contentType, BakcblazeGetUploadUrlResponse urlResponse)
        {
            string sha1Str;                     
            SHA1 sha1 = SHA1.Create();
            // NOTE: Loss of precision. You may need to change this code if the file size is larger than 32-bits.
            byte[] hashData = sha1.ComputeHash(file, 0, file.Length);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashData)
            {
                sb.Append(b.ToString("x2"));
            }
            sha1Str = sb.ToString();

            // Send over the wire
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(urlResponse.UploadUrl);
            webRequest.Method = "POST";
            webRequest.Headers.Add("Authorization", urlResponse.AuthorizationToken);
            webRequest.Headers.Add("X-Bz-File-Name", b2UrlDecode(fileName));
            webRequest.Headers.Add("X-Bz-Content-Sha1", sha1Str);
            webRequest.ContentType = contentType;
            using (var stream = webRequest.GetRequestStream())
            {
                stream.Write(file, 0, file.Length);
                stream.Close();
            }
            WebResponse response = (HttpWebResponse)webRequest.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            response.Close();
            JObject obj = JObject.Parse(responseString);
            string fileId = (string)obj["fileId"];
            return fileId;
        }
        public byte[] DownloadFileById(string fileId)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(DownloadUrl + "/b2api/v2/b2_download_file_by_id");
            string body = "{\"fileId\":\"" + fileId + "\"}";
            var data = Encoding.UTF8.GetBytes(body);
            webRequest.Method = "POST";
            webRequest.Headers.Add("Authorization", AutorizationToken);
            webRequest.ContentType = "application/json; charset=utf-8";
            webRequest.ContentLength = data.Length;
            using (var stream = webRequest.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
                stream.Close();
            }
            WebResponse response = (HttpWebResponse)webRequest.GetResponse();
            Stream responseStream = response.GetResponseStream();
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(responseStream))
            {
                fileBytes = br.ReadBytes(500000);
                br.Close();
            }
            responseStream.Close();
            response.Close();
            return fileBytes;
        }
    }
}
