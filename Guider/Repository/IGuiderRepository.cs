using Guider;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

using travelia.Repository.Generic;

namespace travelia.Repository.guider
{
    interface IGuiderRepository:IRepository<userinfo>
    {
        void updateGuiderInfo(userinfo info);
         
        List<travelplace> getTravelPlace(string email);

        void deleteMyTravelPlace(string id);

        List<travelplace> getTravelPlacebyId(string id);
        void updateTravelPlace(travelplace travelplace);
        string deleteTravelPlace(string id);

        void updatePicture(string[] info, System.Web.HttpPostedFileBase file);

        void insertTravelPlace(travelplace travelplace);

        List<userinfo> Getinformation(int id);

        string getemail(int id);

        List<travelplace> getTravelPlaceByDivision(string division);
    }
}
