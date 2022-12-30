using LEDMatrix.Client;
using LEDMatrix.Client.Client;
using LEDMatrix.Client.Api;
using LEDMatrix.Client.Model;

namespace LEDMatrix.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new ApiClient("http://10.10.0.88:5050");
            var directInvocationAPI = new DirectInvocationApi(client,client, new Configuration()
            {
                //BasePath
            }); 
            //directInvocationAPI.
        }
    }
}