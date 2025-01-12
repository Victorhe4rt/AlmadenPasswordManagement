using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlmadenApi.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? create_at { get; set; }
        public string? update_at { get; set; }


        public User()
        {
            create_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            update_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        }

    }




}