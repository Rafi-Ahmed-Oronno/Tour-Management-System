using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using travelia.Repository.Generic;
using travelia.Repository.guider;

namespace Guider.Controllers
{
    [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
    public class GuiderController : ApiController
    {
        IGuiderRepository guiRepo = new GuiderRepository();

        [Route("Travelia/Guider/{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(guiRepo.Get(id));
        }
        [System.Web.Http.HttpGet]
        [Route("Travelia/Travelplaces/{id}")]
        public IHttpActionResult Mytravelplace(int id)
        {
            
            string mail= guiRepo.getemail(id);
            return Ok(guiRepo.getTravelPlace(mail));
        }
        [System.Web.Http.HttpGet]
        [Route("Travelia/EditMyTravelplaces/{id}")]
        public IHttpActionResult gettravel(int id)
        {
            string ids = id.ToString();
            return Ok(guiRepo.getTravelPlacebyId(ids));
        }
        [System.Web.Http.HttpPut]
        [Route("Travelia/EditMyTravelplaces/{id}")]
        public IHttpActionResult settravel(int id,[FromBody]travelplace travelplace)
        {
            travelplace.id = id;
            guiRepo.updateTravelPlace(travelplace);
            return Ok();
        }
        [System.Web.Http.HttpPost]
        [Route("Travelia/AddTravelplaces/{id}")]
        public IHttpActionResult AddPlace(int id,[FromBody]travelplace travelplace)
        {
            guiRepo.insertTravelPlace(travelplace);
            return Ok();
        }
        [System.Web.Http.HttpDelete]
        [Route("Travelia/DeleteTravelplaces/{id}")]
        public IHttpActionResult Delete(int id)
        {
            guiRepo.deleteMyTravelPlace(id.ToString());
            return Ok();
        }
        [System.Web.Http.HttpGet]
        [Route("Travelia/Myinfo/{id}")]
        public IHttpActionResult Getinformation(int id)
        {
            
            return Ok(guiRepo.Getinformation(id));
        }
        [System.Web.Http.HttpPut]
        [Route("Travelia/Myinfo/{id}")]
        public IHttpActionResult Myinformation(int id,[FromBody]userinfo info)
        {
            info.id = id;
            guiRepo.updateGuiderInfo(info);
            return Ok();
        }
        [System.Web.Http.HttpGet]
        [Route("Travelia/Division/{id}")]
        public IHttpActionResult GetTravelPlaceBydivision(int id)
        {
            if (id == 0) return Ok(guiRepo.getTravelPlaceByDivision("Dhaka"));
            if (id == 1) return Ok(guiRepo.getTravelPlaceByDivision("Mymensing"));
            if (id == 2) return Ok(guiRepo.getTravelPlaceByDivision("Chittagong"));
            if (id == 3) return Ok(guiRepo.getTravelPlaceByDivision("Cumilla"));
            if (id == 4) return Ok(guiRepo.getTravelPlaceByDivision("Borishal"));
            if (id == 5) return Ok(guiRepo.getTravelPlaceByDivision("Rangpur"));
            if (id == 6) return Ok(guiRepo.getTravelPlaceByDivision("Rajshahi"));
            else return NotFound();

        }


    }
}
