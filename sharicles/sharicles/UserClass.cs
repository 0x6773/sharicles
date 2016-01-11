﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharicles
{
    public class User
    {
        /// <summary>
        /// First Name of User
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last Name of User
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Email of User
        /// </summary>
        public string Email { get; set; }
        
        public string Name
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        /// <summary>
        /// Set Temporary values to the values
        /// </summary>
        public void SetTempValues()
        {
            FirstName = "FirstName";
            LastName = "LastName";
            Email = "google@live.com";
        }


    }

    public static class MyExtensions
    {
        public static string ToProperCase(this string str)
        {
            return str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();
        }
    }

}
