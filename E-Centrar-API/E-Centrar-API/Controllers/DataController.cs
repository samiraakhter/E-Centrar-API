using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ServiceLayer.Model;
using ServiceLayer.Services;
using ServiceLayer.Utility;
using ServiceLayers;
using ServiceLayers.Model;
using ServiceLayers.Services;

namespace E_Centrar_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IDataService _dataService;


        public DataController(ApplicationDbContext context, IDataService dataService)
        {
            _dataService = dataService;
            _context = context;

        }
       
        // GET: api/Data
        [HttpGet]
        public IEnumerable<Data> GetData()
        {
            return _context.Data;
        }

        // GET: api/Data/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var data = await _context.Data.FindAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        // PUT: api/Data/5
        /*  [HttpPut("{id}")]
          public async Task<IActionResult> PutData([FromRoute] int id, [FromBody] Data data)
          {
              if (!ModelState.IsValid)
              {
                  return BadRequest(ModelState);
              }

              if (id != data.Id)
              {
                  return BadRequest();
              }

              _context.Entry(data).State = EntityState.Modified;

              try
              {
                  await _context.SaveChangesAsync();
              }
              catch (DbUpdateConcurrencyException)
              {
                  if (!DataExists(id))
                  {
                      return NotFound();
                  }
                  else
                  {
                      throw;
                  }
              }

              return NoContent();
          }
          */
        [HttpPut("Add")]
        public IActionResult Put([FromBody] List<Data> datas)
        {
            Logger.Debug(JsonConvert.SerializeObject(datas));//converts whole object intro string to print in log
            Logger.Debug(MethodBase.GetCurrentMethod().Name + " -----> started"); //indicate the function start in log with function name

            try
            {
                foreach (var data in datas)
                {
                    _context.Data.Add(data);
                    _context.SaveChanges();
                }
                return Ok(datas);
            }
            catch (Exception ex)
            {
                Logger.Fatal(ex.Message);
                Logger.Fatal(ex.Source);
                Logger.Fatal(ex.StackTrace);
                if (ex.InnerException != null)
                {
                    Logger.Fatal(ex.InnerException.Message);
                    Logger.Fatal(ex.InnerException.Source);
                    Logger.Fatal(ex.InnerException.StackTrace);
                }
                return BadRequest();
            }
        }

        [HttpPost("AddOrders")]
        public IActionResult PostOrder([FromBody] List<Order> orders, List<OrderLines> orderLines)
        {
            Logger.Debug(JsonConvert.SerializeObject(orders));//converts whole object intro string to print in log
            Logger.Debug(JsonConvert.SerializeObject(orderLines));//converts whole object intro string to print in log
            Logger.Debug(MethodBase.GetCurrentMethod().Name + " -----> started"); //indicate the function start in log with function name

            try
            {
                foreach (var order in orders)
                {
                    _context.Order.Add(order);
                    _context.SaveChanges();
                }
                foreach (var orderLine in orderLines)
                {
                    _context.OrderLines.Add(orderLine);
                    _dataService.UpdateStock(orderLine.ProductIdFk, orderLine.Quantity);
                    _context.SaveChanges();
                }
                return Ok(orders);
            }
            catch (Exception ex)
            {
                Logger.Fatal(ex.Message);
                Logger.Fatal(ex.Source);
                Logger.Fatal(ex.StackTrace);
                if (ex.InnerException != null)
                {
                    Logger.Fatal(ex.InnerException.Message);
                    Logger.Fatal(ex.InnerException.Source);
                    Logger.Fatal(ex.InnerException.StackTrace);
                }
                return BadRequest();
            }
        }

        // POST: api/Data/ 
        [HttpPost("Create")]
        public async Task<IActionResult> PostData([FromBody] Data data)
        {
            Logger.Debug(JsonConvert.SerializeObject(data));//converts whole object intro string to print in log
            Logger.Debug(MethodBase.GetCurrentMethod().Name + " -----> started"); //indicate the function start in log with function name


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Data.Add(data);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetData", new { id = data.Id }, data);
            }

            catch (Exception ex)
            {
                Logger.Fatal(ex.Message);
                Logger.Fatal(ex.Source);
                Logger.Fatal(ex.StackTrace);
                if (ex.InnerException != null)
                {
                    Logger.Fatal(ex.InnerException.Message);
                    Logger.Fatal(ex.InnerException.Source);
                    Logger.Fatal(ex.InnerException.StackTrace);
                }
                return BadRequest();

            }

        }

        [HttpGet("GetRoute")]
        public  ActionResult GetRoute(int userId)
        {
            try
            {

                List<Customer_> customer_s = new List<Customer_>();
                var routes = _context.Route.Where(r => r.SalesPerson == userId).ToList();
                foreach (var r in routes)
                {
                    customer_s.AddRange(_context.Customer.Where(x=>x.FK_RouteId==r.Id).Select(x => Mapper<Customer_>.Map(x)).ToList());
                }
               
                return Ok(customer_s);


            }
            catch (Exception ex)
            {

                Logger.Fatal(ex.Message);
                Logger.Fatal(ex.Source);
                Logger.Fatal(ex.StackTrace);
                if (ex.InnerException != null)
                {
                    Logger.Fatal(ex.InnerException.Message);
                    Logger.Fatal(ex.InnerException.Source);
                    Logger.Fatal(ex.InnerException.StackTrace);
                }
                return BadRequest();
            }

        }

        //[HttpGet("Download")]
        //public async Task<ActionResult> DownloadData(int userId)
        //{
        //    try
        //    {
        //        var inventories = DownloadVM.inventories.ToList();
        //        var products = _context.Product
        //        var customers = DownloadVM.Customers.ToList();
        //        foreach (var data in inventories)
        //        {
        //            foreach ()
        //        }
        //        return downloadData.toListAsync();


        //    }
        //    catch (Exception ex)
        //    {

        //        Logger.Fatal(ex.Message);
        //        Logger.Fatal(ex.Source);
        //        Logger.Fatal(ex.StackTrace);
        //        if (ex.InnerException != null)
        //        {
        //            Logger.Fatal(ex.InnerException.Message);
        //            Logger.Fatal(ex.InnerException.Source);
        //            Logger.Fatal(ex.InnerException.StackTrace);
        //        }
        //    }

        //}

        // DELETE: api/Data/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var data = await _context.Data.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            _context.Data.Remove(data);
            await _context.SaveChangesAsync();

            return Ok(data);
        }

        /* private bool DataExists(int id)
         {
             return _context.Data.Any(e => e.Id == id);
         }*/
    }
}