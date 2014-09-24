using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;

namespace SecurityPipeline.Pipeline
{
	public class TestMiddleware
	{
		private Func<IDictionary<string,object>, Task> _next;
		public TestMiddleware(Func<IDictionary<string,object>, Task> next)
		{
			_next = next;
		}

		public async Task Invoke(IDictionary<string, object> env)
		{
			var context = new OwinContext(env);

			//authenticate Principal: this could be done at any stage of the pipeline.
			context.Request.User = 
				new GenericPrincipal(new GenericIdentity("bri"), new string[] { });

			Helper.Write("Middleware", context.Request.User);

			await _next(env);
		}
	}
}