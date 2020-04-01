using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class ResponseObject
    {
        private string responseMessage;
        private object response;

        public string ResponseMessage
        {
            get { return responseMessage; }
            set { responseMessage = value; }
        }

        public object Response
        {
            get { return response; }
            set { response = value; }
        }

        public ResponseObject()
        {
            
        }

        public ResponseObject(string mensaje, object objetoRespuesta)
        {
            ResponseMessage = mensaje;
            Response = objetoRespuesta;
        }
    }
}
