using DBMapper.Model;
using PortalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/contact")]
    public class ContactController : ApiController
    {
        /// <summary>
        /// Fetch contact details for all
        /// </summary>
        /// <returns>list of contact information</returns>
        [HttpGet]
        [Route("GetAllContacts")]
        public HttpResponseMessage GetContacts()
        {
            List<ContactInfo> result = new List<ContactInfo>();
            result = PortalHelper.GetContacts();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// fetch contact details by ID
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns>single object of contact</returns>
        [HttpGet]
        [Route("GetContactInfoById/{ID}")]
        public HttpResponseMessage GetContactById(int ID)
        {
            ContactInfo result = new ContactInfo();
            result = PortalHelper.GetContactById(ID);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Add/Updates contact information
        /// Add or Update is decided on the ID sent in the model, if it exists contact information for that id is updated
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddUpdateContactInfo")]
        public HttpResponseMessage AddUpdateContact(ContactInfo model)
        {
            var result = PortalHelper.AddUpdateContact(model);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}