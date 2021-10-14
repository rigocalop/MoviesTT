using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace sw.JAR
{
	public static class Execute
	{
		public static async Task<resJAR> mode0(string sURL, string sMETHOD = "GET", string sBODY = "", string sTokeyAutorization = "", string sKeyTokenAutorization = "Authorization")
		{
			resJAR xRET = new resJAR();
			if (xRET.MoreData == null) xRET.MoreData = new sw.JAR.MoreData();
			xRET.MoreData.Host = sURL;
			xRET.MoreData.Body = sBODY;
			xRET.MoreData.DTime_START = DateTime.UtcNow;

			using (var client = new HttpClient())
			{

				try
				{
					// 2. CONFIGURACION DE MEDIATYPE Y SUB SUBCONFIGURACIONES.
					string sMEDIATYPE = "application/json";
					if (sTokeyAutorization != "") client.DefaultRequestHeaders.Add(sKeyTokenAutorization, sTokeyAutorization);

					// 3. EJECUCIÓN DEL PROCESO.
					HttpResponseMessage response = null;
					switch (sMETHOD)
					{
						case "GET": response = await client.GetAsync(xRET.MoreData.Host); break;
						case "POST": response = await client.PostAsync(xRET.MoreData.Host, new StringContent(xRET.MoreData.Body, Encoding.UTF8, sMEDIATYPE)); break;
					}

					response.ReasonPhrase = response.ReasonPhrase;
					if (sMETHOD == "POST" || sMETHOD == "GET") xRET.ResponseJDATA = await response.Content.ReadAsStringAsync();

					xRET.StatusCode = (int)response.StatusCode;
				}
				catch (System.Net.WebException e)
				{
					xRET.StatusCode_Reason = e.Message;
					xRET.StatusCode = -1;
				}
				catch (Exception e)
				{
					xRET.StatusCode_Reason = e.Message;
					xRET.StatusCode = -1;
				}
			}
			xRET.MoreData.DTime_END = DateTime.UtcNow;
			return xRET;
		}
	}
	public class MoreData
	{
		public DateTime DTime_START { get; set; }
		public DateTime DTime_END { get; set; }
		public TimeSpan DTime_DURATION { get; set; }
		public string UserName { get; set; } = "";
		public string UserPass { get; set; } = "";
		public string Token { get; set; } = "";
		public string Host { get; set; } = "";
		public string Body { get; set; }
	}

	public class resJAR
	{
		public int StatusCode { get; set; }
		public string StatusCode_Reason { get; set; }
		public object ResponseOBJECT { get; set; }
		public string ResponseJDATA { get; set; }
		public MoreData MoreData;
	}
}
