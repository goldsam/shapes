using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShapesMVC.Models
{
    public class ShapeModel
    {
        public ShapeParametersModel Parameters { get; set; } 

        public string RenderedShape{ get; set; }
    }
}