using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VaidarCFDI
{
    class Program
    {
        static void Main(string[] args)
        {
            SATWS.ConsultaCFDIService clienteWS = new SATWS.ConsultaCFDIService();
            SATWS.Acuse acuseWS = new SATWS.Acuse();
            SAT.ConsultaCFDIServiceClient client = new SAT.ConsultaCFDIServiceClient();
            SAT.Acuse acuse = new SAT.Acuse();
        // Use the 'client' variable to call operations on the service.
           acuse= client.Consulta("?re=ACG1208232X5&rr=PHJ061113D27&tt=0000004350.000000&id=16EBEAB1-AB78-4D50-A07E-C4C58E851B34");
           Console.WriteLine(acuse.CodigoEstatus);
           Console.WriteLine(acuse.Estado);
           Console.WriteLine(acuse.ExtensionData.ToString());
           Console.WriteLine(acuse.ToString());
           acuseWS = clienteWS.Consulta("?re=ACG1208232X5&rr=PHJ061113D27&tt=0000004350.000000&id=16EBEAB1-AB78-4D50-A07E-C4C58E851B34");
           Console.WriteLine(acuseWS.CodigoEstatus);
           Console.WriteLine(acuseWS.Estado);
           Console.WriteLine(acuseWS);
           Console.WriteLine(acuseWS.ToString());
         //   client.
        // Always close the client.
        client.Close();
        CanSAT.CancelaCFDBindingClient cancelar = new CanSAT.CancelaCFDBindingClient();
        cancelar.CancelaCFD();



        Console.ReadKey();
            //SATWS.ConsultaCFDIService client
    
          //  "?re=ACG1208232X5&rr=PHJ061113D27&tt=0000004350.000000&id=16EBEAB1-AB78-4D50-A07E- C4C58E851B34";

        }
    }
}
