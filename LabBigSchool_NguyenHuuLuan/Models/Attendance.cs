using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabBigSchool_NguyenHuuLuan.Models
{
    public class Attendance//thêm bảng nhiều nhiều
    {
        public Course Course { get; set; }
        [Key]
        [Column(Order=1)]// CourseID ở cột 1
        public int CourseId { get; set; }
        public ApplicationUser Attendanee { get; set; }

        [Key]
        [Column(Order = 2)]// CourseID ở cột 2
        public string AttendaneeId { get; set; }

    }
}