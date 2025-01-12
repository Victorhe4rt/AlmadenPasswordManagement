using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlmadenApi.Model
{
    public class Folder
    {
             
        [Key]
        public int Id { get; set; }

        public string ?Name { get; set; }

        public string ?create_at { get; set; }

        public string ? update_at { get; set; }


        public Folder()
        {
            create_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            update_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        }


    }
}