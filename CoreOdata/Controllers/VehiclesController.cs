//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using CoreOdata.Models;
//using Microsoft.AspNet.OData;
//using Microsoft.AspNet.OData.Query;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace CoreOdata.Controllers
//{
//    public class VehiclesController : ODataController
//    {
//        private readonly MyContext _context;

//        public VehiclesController(MyContext context)
//        {
//            _context = context;
//        }

//        [HttpGet]
//        public async Task<IActionResult> Get(ODataQueryOptions<Vehicle> options)
//        {
//            var results = options.ApplyTo(_context.Vehicles);
//            return Ok(results);
//        }
//    }
//}