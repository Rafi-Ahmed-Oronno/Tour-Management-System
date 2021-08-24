using Guider;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http;

using travelia.Repository.Generic;

namespace travelia.Repository.guider
{
    public class GuiderRepository:Repository<userinfo>,IGuiderRepository
    {
        traveliaEntitiesContext context;
        public GuiderRepository()
        {
            context = new traveliaEntitiesContext();
        }

        public void deleteMyTravelPlace(string id)
        {
            int placeid = Int32.Parse(id);
            var place = context.travelplaces.Where(x => x.id == placeid).First();
            context.travelplaces.Remove(place);
            context.SaveChanges();
        }
        public string getemail(int id)
        {
            var mail = context.users.Where(x => x.id == id).Select(x => x.usermail).SingleOrDefault();
            return mail;
        }


        public string deleteTravelPlace(string id)
        {
            int ids = Int32.Parse(id);
            var info = context.travelplaces.Where(x => x.id == ids).First();
            string imagepath = info.division + "/" + info.pictures;
            return imagepath;
        }

        public List<travelplace> getTravelPlace(string email)
        {
            return context.travelplaces.Where(x => x.travelguidermail == email).ToList();

        }

        public List<travelplace> getTravelPlaceByDivision(string division)
        {
            List<travelplace> l= context.travelplaces.Where(x => x.division == division).ToList();
            return l;
        }

        public List<travelplace> getTravelPlacebyId(string id)
        {
            int ids = Int32.Parse(id);
            List<travelplace> l = context.travelplaces.Where(x => x.id == ids).ToList();
            //travelplace trvplace = place as travelplace;
            return l;
        }

        public void insertTravelPlace(travelplace travelplace)
        {
            travelplace place = new travelplace
            {
                travelplace1=travelplace.travelplace1,
                division=travelplace.division,
                location=travelplace.location,
                description=travelplace.description,
                pictures=null,
                travelguidermail=travelplace.travelguidermail,
                status="pending"
            };
            //string image = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Assets/images/travelplace/" + info[1] + "/"), info[0] + ".jpg");
           // file.SaveAs(image);
            context.travelplaces.Add(place);
            context.SaveChanges();

        }

        public void updateGuiderInfo(userinfo info)
        {
            context.Entry(info).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void updatePicture(string[] info, System.Web.HttpPostedFileBase file)
        {
            string ids = info[0];
            var place = context.travelplaces.Where(x => x.id.ToString() == ids).First();
            place.pictures = info[1];
            string image = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Assets/images/travelplace/"+place.division+"/"), info[1] + ".jpg");
            file.SaveAs(image);
            context.SaveChanges();
        }

        public void updateTravelPlace(travelplace travelplace)
        {
            string ids = travelplace.id.ToString();
            var place = context.travelplaces.Where(x => x.id.ToString() == ids).First();
            place.travelplace1 = travelplace.travelplace1;
            place.division = travelplace.division;
            place.location = travelplace.location;
            place.description = travelplace.description;

            context.SaveChanges();
        }
        public List<userinfo> Getinformation(int id)
        { 
            List<userinfo> l = context.userinfoes.Where(x => x.id == id).ToList();
            return l;
        }
       
    }
}