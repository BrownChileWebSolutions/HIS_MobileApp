using GoogleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GoogleAPI.Controllers
{
    public class MapController : ApiController
    {
        public IEnumerable<Hotel> Get()
        {
            return new List<Hotel> {
                new Hotel {Name="Cambay Grand",Address="Thaltej - SG Road",Latitute=23.022505, Longitude=72.571362,Description="Cambay Grand, Ahmedabad is a splendid property with all the lavish facilities and accommodation. It has an exquisite Orient Spa for the soul stirring experience of wellness with the rejuvenating"}, //Ahmedabad
                new Hotel {Name="Courtyard",Address="Satellite",Latitute=22.700000, Longitude=72.866700,Description="Courtyard by Marriott, Ahmedabad is an aesthetically designed lavish resort in the capital city of Ahmedabad. The hotel offers fascinating classy facilities to make the vacation an unforgettable experience. "},    //Nadiad
                new Hotel {Name="Eastin Hotel",Address="Prahlad Nagar - SG Road",Latitute=22.566700, Longitude=72.933300,Description="Eastin Hotel Ahmedabad will be located on the main SG road and is situated in an important commercial location of Ahmedabad. All 156-room will consist of superior rooms, deluxe rooms"},     //Anand
                new Hotel {Name="The Fern",Address="Thaltej - SG Road",Latitute=22.307159, Longitude= 73.181219,Description="The Fern, Ahmedabad is a luxurious property that aims to conserve the environment. The hotel offers eco friendly rooms designed with stylish and lavish furnishings. Its calming and classic ambience"},   //Baroda
                new Hotel {Name="Fortune Landmark",Address="Usmanpura - City Centre",Latitute=21.705136, Longitude= 72.995875,Description="Fortune Hotel Landmark, Ahmedabad is a lavish and marvelous property with world class services. The hotel is furnished with stylish and luxurious fixtures and interiors. Its soothing and classic ambience"},  //Bharuch
                new Hotel {Name="Inder Residency",Address="Ellis Bridge",Latitute=21.195000, Longitude= 72.819444,Description="Add pride to your trip to Ahmadabad by making a luxurious stay at the Hotel Inder Residency that boasts of being the first five-star hotel in the city. "},    //Surat
                new Hotel {Name="Narayani Heights",Address="Airport Gandhi Nagar Highway.",Latitute=20.945263, Longitude= 72.934245,Description="Narayani Heights, Ahmedabad is an opulent hotel that delivers a prolific ground for envisaging the real gist of ease, expediency and treat. Coalescing first class relaxation with classy taste and"},  //Navsari
                new Hotel {Name="Novotel",Address="Iskcon Circle - SG Road",Latitute=20.599235, Longitude= 72.934245,Description="Novotel, Ahmedabad is a 5-star property offering a perfect blend of great comfort, luxury and warm hospitality. An all-day dining restaurant, well-equipped gymnasium, banquet facilities and conference rooms, make it"},   //Valsad
                new Hotel {Name="The Pride Hotel",Address="Bodakdev - SG Road",Latitute=20.359690, Longitude= 72.893800,Description="Situated close to the city's renowned SG highway, The Pride Hotel in Ahmedabad is a haven of luxury. As a top-class business hotel, Pride hotel offers a convenient option for"},     //Vapi
                new Hotel {Name="Radisson Blu Hotel",Address="Ambavadi - City centre",Latitute= 19.075984 , Longitude= 72.877656,Description="Radisson Blu, Ahmedabad is a magnificent hotel offering an astonishing range of facilities and services. The place is perfectly suited for leisure as well as corporate travelers. Some of the"}  //Mumbai

            };
        }
    }
}
