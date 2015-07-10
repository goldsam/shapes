using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShapesMVC.Generator;

namespace ShapesMVC.Models
{
    public class ShapeParametersModel : ShapeParameters
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
}