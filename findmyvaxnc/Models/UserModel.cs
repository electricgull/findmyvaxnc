using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace findmyvaxnc.Models
{

    public class ModelCollection
    {
        public List<LocationModel> locationView { get; set; }
        public List<TestingModel> testView { get; set; }
    }

    public class LocationModel
    {
        public string County { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Hours { get; set; }
        public string AppointmentType { get; set; }
        public string WebsiteName { get; set; }
        public string Website { get; set; }
        public string Verified { get; set; }
    }
    public class TestingModel
    {
        public string County { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string TestType { get; set; }
        public string ResultResponse { get; set; }
        public string AgeRequirement { get; set; }
        public string ScreeningRequirement { get; set; }
        public string AppointmentType { get; set; }
        public string WebsiteName { get; set; }
        public string Website { get; set; }
        public string Verified { get; set; }
    }
}