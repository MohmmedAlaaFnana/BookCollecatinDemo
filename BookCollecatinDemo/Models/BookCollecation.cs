using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookCollecatinDemo.Models
{
    public class BookCollecation
    {

            public int Id { get; set; }

            [Required(ErrorMessage = "هذا الحقل مطلوب")]
            public string Title { get; set; }

            [Required(ErrorMessage = "هذا الحقل مطلوب")]
            public string Authorname { get; set; }

            [Required(ErrorMessage = "هذا الحقل مطلوب")]
            public DateTime ReleaseDate { get; set; }

            [Required(ErrorMessage = "هذا الحقل مطلوب")]
            public string Rating { get; set; }
        }
    }


