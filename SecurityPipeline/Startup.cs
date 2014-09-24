using Owin;
using SecurityPipeline.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SecurityPipeline
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			//this is the new global.ascx
			var configuraiton = new HttpConfiguration();
			configuraiton.Routes.MapHttpRoute(
				"default",
				"api/{controller}");

			//to add this globally
			//configuraiton.Filters.Add(TestAuthenticationFilterAttribute f)
			//otherwise use it on the controller itself.

			app.Use(typeof(TestMiddleware));

			app.UseWebApi(configuraiton);
		}
	}
}