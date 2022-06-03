using LabBigSchool_NguyenHuuLuan.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace LabBigSchool_NguyenHuuLuan.ViewModels
{
    public class CourseViewModel
    {
        string a= "dd/M/yyyy";
        string b = "HH:mm";

        [Required]
        public string Place { get; set; }
        [Required]
        [FutureDate]
        public string Date { get; set; }
        [Required]
        [ValidTime]
        public string Time { get; set; }
        [Required]
        public byte Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public DateTime GetDateTime()
        {
            return DateTime.ParseExact(string.Format("{0} {1}", Date, Time),string.Format("{0} {1}",a,b), CultureInfo.InvariantCulture);
        }
    }
}