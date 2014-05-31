using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace SaG.Services
{
    public class ExceptionXElement : XElement
    {
	    public ExceptionXElement(Exception exception)
		    : this(exception, false)
	    { }

	    public ExceptionXElement(Exception exception, bool omitStackTrace)
		    : base(new Func<XElement>(() =>
		    {
			    if (exception == null)  
				    throw new ArgumentNullException("exception");  

			    var root = new XElement
				    (exception.GetType().ToString());

				root.Add(new XElement("Message", exception.Message));    

			    if (!omitStackTrace && exception.StackTrace != null)
			    {
				    root.Add
				    (
					    new XElement("StackTrace",
						    from frame in exception.StackTrace.Split('\n')
						    let prettierFrame = frame.Substring(6).Trim()
						    select new XElement("Frame", prettierFrame))
				    );
			    }

			    if (exception.Data.Count > 0)
			    {
				    root.Add
				    (
					    new XElement("Data",
						    from entry in
							    exception.Data.Cast<KeyValuePair<string, string>>()
						    let key = entry.Key
						    let value = entry.Value ?? "null"
						    select new XElement(key, value))
				    );
			    }

			    if (exception.InnerException != null)
			    {
				    root.Add
				    (
					    new ExceptionXElement
						    (exception.InnerException, omitStackTrace)
				    );
			    }  
			    return root;
		    })())
	    { }
    }
}
