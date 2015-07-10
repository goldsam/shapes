using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Web.Http;
using ShapesMVC;
using ShapesMVC.Controllers;
using ShapesMVC.Models;
using ShapesMVC.Generator;
using ShapesMVC.Tests.Models;
using System.Web.Http.Results;

namespace ShapesMVC.Tests.Controllers
{
    /// <summary>
    /// Unit tests for the ShapesController class.
    /// </summary>
    [TestClass]
    public class ShapesControllerTest
    {
        private static readonly int TEST_ID = 3;

        [TestMethod]
        public void PostShape_ShouldReturnSameShape()
        {
            ShapesController controller = new ShapesController(new TestShapesContext());
            ShapeParametersModel shapeParameters = CreateShapeParameters(1);
            CreatedAtRouteNegotiatedContentResult<ShapeModel> result =
                controller.PostShape(shapeParameters) as CreatedAtRouteNegotiatedContentResult<ShapeModel>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.Content.Parameters.Id, shapeParameters.Id);
            Assert.AreEqual(result.RouteValues["id"], result.Content.Parameters.Id);
            Assert.AreEqual(result.Content.RenderedShape, GenerateShape(shapeParameters));
        }

        [TestMethod]
        public void GetShape_ShouldReturnProductWithSameID()
        {
            TestShapesContext context = CreateTestContext();

            ShapesController controller = new ShapesController(context);
            OkNegotiatedContentResult<ShapeModel> result = 
                controller.GetShape(TEST_ID) as OkNegotiatedContentResult<ShapeModel>;

            Assert.IsNotNull(result);
            Assert.AreEqual(TEST_ID, result.Content.Parameters.Id);
        }

        [TestMethod]
        public void GetShapes_ShouldReturnFirstPageOfProducts()
        {
            TestShapesContext context = CreateTestContext();

            ShapesController controller = new ShapesController(context);
            OkNegotiatedContentResult<PagedCollection<ShapeModel>> result = 
                controller.GetShapes() as OkNegotiatedContentResult<PagedCollection<ShapeModel>>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Page, 1);
            Assert.AreEqual(result.Content.PageSize, 5);
            Assert.AreEqual(result.Content.TotalCount, 11);
            Assert.AreEqual(result.Content.Data.ElementAt(0).Parameters.Id, 11);
            Assert.AreEqual(result.Content.Data.ElementAt(4).Parameters.Id, 7);
        }

        /// <summary>
        /// Helper method which returns a "rendered" shape string from a given set of shape parameters.
        /// </summary>
        /// <param name="shapeParameters">shape parameters</param>
        /// <returns>Rendered shape string</returns>
        private string GenerateShape(ShapeParametersModel shapeParameters)
        {
            return ShapeGeneratorFactory.GetShapeGenerator(shapeParameters.Type).GetShapeString(shapeParameters);
        }

        /// <summary>
        /// Creates a set of shape parameters used by testing.
        /// </summary>
        /// <param name="id">shape parameter record identifier</param>
        /// <returns>shape parameters</returns>
        private ShapeParametersModel CreateShapeParameters(int id)
        {
            return new ShapeParametersModel
            {
                Id = id,
                Type = "triangle",
                Height = id * 10,
                Label =  id.ToString(),
                LabelRow = id + 4
            };
        }

        /// <summary>
        /// Create a mock database context used for testing which contains a 
        /// number of pregenerated shape parameters.
        /// </summary>
        /// <returns>mock database context used for testing</returns>
        private TestShapesContext CreateTestContext() {
            TestShapesContext context = new TestShapesContext();
            for( int i = 1; i <= 11; i++) {
                context.ShapeParameters.Add(CreateShapeParameters(i));
            }

            return context;
        }
    }
}
