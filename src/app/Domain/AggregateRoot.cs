using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Domain
{
    public class AggregateRoot : IAggregateRoot
    {
        ISubject _subject;

        public AggregateRoot(ISubject subject)
        {
            _subject = subject;    
        }

        public string GetResponse(IDictionary<String,Object> parameters)
        {
            Int32 id;

            String response = "default";

            if (parameters["id"] == null || !Int32.TryParse(parameters["id"].ToString(), out id))
            {
                response = "cannot parse id";
            }
            else if (_subject == null)
            {
                response = ToString();
            }
            else
            { 
                response = _subject.ToString() + ":" + _subject.Get(id).ToString();
            }

            return response;
        }
    }
}
