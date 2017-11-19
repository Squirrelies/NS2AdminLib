using System.IO;
using System.Net;
using System.Text;

namespace NS2AdminLib.Common
{
    public static class JSON
    {
        public static string PostJSONData(string url, string requestJSON, NetworkCredential credentials = null, bool useDefaultCredentials = true)
        {
            byte[] requestJSONBytes = Encoding.UTF8.GetBytes(requestJSON);

            HttpWebRequest hwr = WebRequest.CreateHttp(url);
            hwr.UseDefaultCredentials = useDefaultCredentials;
            hwr.Credentials = credentials;
            hwr.Method = "POST";
            hwr.ContentType = "application/json";
            hwr.ContentLength = requestJSONBytes.Length;

            using (Stream streamWriter = hwr.GetRequestStream())
            {
                streamWriter.Write(requestJSONBytes, 0, requestJSONBytes.Length);
            }

            using (HttpWebResponse response = (HttpWebResponse)hwr.GetResponse())
            using (StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return streamReader.ReadToEnd();
            }
        }

        public static string GetJSONData(string url, NetworkCredential credentials = null, bool useDefaultCredentials = true)
        {
            HttpWebRequest hwr = WebRequest.CreateHttp(url);
            hwr.UseDefaultCredentials = useDefaultCredentials;
            hwr.Credentials = credentials;
            hwr.Method = "GET";
            hwr.ContentType = "application/json";
            hwr.ContentLength = 0;

            using (HttpWebResponse response = (HttpWebResponse)hwr.GetResponse())
            using (StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}
