using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using travelia.Repository.Login;

namespace Guider.Controllers
{
    [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        ILoginRepository loginRepo = new LoginRepository();
        [System.Web.Http.HttpPost]
        [Route("Travelia/Login")]
        public IHttpActionResult Login([FromBody]userinfo userinfo)
        {
            
           int a= loginRepo.loginCheck(userinfo.usermail,userinfo.password);
            if(a==-1)
            {
                return NotFound();
            }
            else
            {
                string[] type = loginRepo.userType(userinfo.usermail.ToString());
                string email = type[0];
                string logtype = type[1];

                return Ok(type);
            }
        }
    }
}
