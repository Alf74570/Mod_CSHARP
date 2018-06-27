using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Threading;
using System.Globalization;

namespace MyLibrary
{
   public class ApiRequest
   {
        public ApiRequest() { }

        WebRequest request = null;
        Stream dataStream = null;
        StreamReader reader = null;
        WebResponse response = null;
        string responseFromServer = "";

        public List<Lines> getLines(double longitude = 5.730258, double latitude = 45.159134)
        {
            List<Lines> listFromServer = null;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            try
            {
                // Create a request for the URL. 
                request = WebRequest.Create($"http://data.metromobilite.fr/api/linesNear/json?x={longitude}&y={latitude}&dist=500&details=true");
                // Get the response.
                response = request.GetResponse();
                // Display the status.
                //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                reader = new StreamReader(dataStream);
                //Read the content.
                responseFromServer = reader.ReadToEnd();
                listFromServer = JsonConvert.DeserializeObject<List<Lines>>(responseFromServer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                reader.Close();
                dataStream.Close();
                response.Close();
            }
            return listFromServer;
        }

        public List<LinesDescription> getLinesDescription(string lineId)
        {
            List<LinesDescription> listFromServer = null;

            try
            {
                request = WebRequest.Create($"http://data.metromobilite.fr/api/routers/default/index/routes?codes={lineId}");
                response = request.GetResponse();
                dataStream = response.GetResponseStream();
                reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
                listFromServer = JsonConvert.DeserializeObject<List<LinesDescription>>(responseFromServer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                reader.Close();
                dataStream.Close();
                response.Close();
            }
            return listFromServer;
        }
   }
}

