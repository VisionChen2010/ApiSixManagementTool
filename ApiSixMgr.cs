/*
 * User:Vision Chen
 * Date: 2023/2/9
 * Time: 11:57
 * 
 * 
 */
using System;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;




namespace ApiSixUtify
{

	class ApiSixClient
	{
		public string IPPort;				//Apisix的ip端口
		public string User;				//Apisix的账号
		public string Password;				//Apisix的登陆密码
		private string _token;				//鉴权Token
		
		//登陆，获取Token
		public void Login()				
		{
		
			string Url=string.Format(@"http://{0}/apisix/admin/user/login",IPPort);
			//System.Windows.Forms.MessageBox.Show(Url);
			RestClient client = new RestClient(Url);
			client.Timeout = -1;
			var request = new RestRequest(Method.POST);
			request.AddHeader("Accept", "application/json");
			request.AddHeader("Accept-Language", "zh-CN,zh;q=0.9");
			request.AddHeader("Authorization", "");
			request.AddHeader("Content-Type", "application/json;charset=UTF-8");
			client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36";
			
			//请求的消息体
			var jobj = Newtonsoft.Json.Linq.JObject.FromObject(
                	new {
                    		username = User,
                    		password=Password
          
            		});
            		string Body=JsonConvert.SerializeObject(jobj);	
			request.AddParameter("application/json;charset=UTF-8", Body,  ParameterType.RequestBody);
			IRestResponse response = client.Execute(request);


			JObject jobject = (JObject)JsonConvert.DeserializeObject(response.Content);   
			_token=jobject["data"]["token"].ToString();
		}
		
		
		
		//获取路由
		public List<RouteInfo> GetRoute()				
		{
			string Url=string.Format(@"http://{0}/apisix/admin/routes?label=&page=1&page_size=100",IPPort);
			var client = new RestClient(Url);
			client.Timeout = -1;
			var request = new RestRequest(Method.GET);
			request.AddHeader("Accept", "*/*");
			request.AddHeader("Accept-Language", "zh-CN,zh;q=0.9");
			request.AddHeader("Authorization", _token);
			
			client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36";
			IRestResponse response = client.Execute(request);
			
			string HttpResult=response.Content;
			
			
			JObject jobject = (JObject)JsonConvert.DeserializeObject(HttpResult);  
            IList<JToken> results = jobject["data"]["rows"].Children().ToList(); 
            
            List<RouteInfo> Routes=new List<RouteInfo>();
            
            for(int i=0;i < results.Count;i++)
            {
                RouteInfo route=new RouteInfo();
                route.ID=results[i]["id"].ToString();
                route.Name=results[i]["name"].ToString();
                try
                {
                	route.Path=results[i]["uris"][0].ToString();
                }
                catch
                {
                 	route.Path=results[i]["uri"].ToString();
                }
                Routes.Add(route);
            }
            
            return Routes;


		}
		
		//删除路由
		public void DeleteRoute(string RouteID)
		{
			string Url=string.Format(@"http://{0}/apisix/admin/routes/{1}",IPPort,RouteID);
			var client = new RestClient(Url);
			client.Timeout = -1;
			var request = new RestRequest(Method.DELETE);
			request.AddHeader("Accept", "*/*");
			request.AddHeader("Accept-Language", "zh-CN,zh;q=0.9");
			request.AddHeader("Authorization", _token);
			client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36";
			IRestResponse response = client.Execute(request);
		
		}
		
		//导出路由
		public void ExportRoute(List<string> Routes)
		{
			string RouteIDS=string.Join(",",Routes);				
			string Url=string.Format(@"http://{0}/apisix/admin/export/routes/{1}",IPPort,RouteIDS);
			var client = new RestClient(Url);
			client.Timeout = -1;
			var request = new RestRequest(Method.GET);
			request.AddHeader("Accept", "*/*");
			request.AddHeader("Accept-Language", "zh-CN,zh;q=0.9");
			request.AddHeader("Authorization", _token);
			client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36";
			IRestResponse response = client.Execute(request);
			//Console.WriteLine(response.Content);
			
			string HttpResult=response.Content;
			JObject jobject = (JObject)JsonConvert.DeserializeObject(HttpResult);  
			string result = jobject["data"].ToString();
			
			string ExportFilePath=System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop)+"\\"+"APISIX_routes_"+IPPort.Split(':')[0]+"_"+DateTime.Now.ToString("yyyyMMddHHmmss")+".json";
			System.IO.File.WriteAllText(ExportFilePath,result);
			
		
		}
		
		//导入路由
		public void ImportRoute(string ConfigFile)
		{
			string Url=string.Format(@"http://{0}/apisix/admin/import/routes",IPPort);
			
			
			var client = new RestClient(Url);
			client.Timeout = -1;
			var request = new RestRequest(Method.POST);
			request.AddHeader("Accept", "application/json");
			request.AddHeader("Accept-Language", "zh-CN,zh;q=0.9");
			request.AddHeader("Authorization", _token);
			client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36";
			request.AddFile("file", ConfigFile);
			IRestResponse response = client.Execute(request);

		}
	}
	
	
	public struct RouteInfo
	{
		public string ID;				//路由ID
		public string Name;				//路由名字
		public string Path;				//路径

	
	}
	
	
}
