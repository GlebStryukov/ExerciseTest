using ClosedXML.Excel;
using ExerciseTest.Datas;
using ExerciseTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseTest.Controllers
{
    public class HomeController : Controller
    {

        private readonly BooksAuthorContext _context;
        DatabaseTable database = new DatabaseTable();

        public HomeController(BooksAuthorContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var booksAuthorContext = _context.BooksAuthors.Include(b => b.Author).Include(b => b.Book);
            return View(await booksAuthorContext.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Get data from database into datatable
        /// </summary>
        /// <returns>DataTable objects with data</returns>
        public DataTable GetData()
        {
            //Creating DataTable  
            DataTable dt = new DataTable();
            //Setiing Table Name  
            dt.TableName = "Books and Authors";
            //Add Columns  
            dt.Columns.Add("Book title", typeof(string));
            dt.Columns.Add("Book edition", typeof(string));
            dt.Columns.Add("Date published book", typeof(DateTime));
            dt.Columns.Add("Book description", typeof(string));
            dt.Columns.Add("Full name author", typeof(string));
            dt.Columns.Add("Author date of birth", typeof(DateTime));

            dt = database.GetRecord();
            return dt;
        }

        /// <summary>
        /// Export DataTable object with datas into xlsx file
        /// </summary>
        /// <returns>file</returns>
        public ActionResult ExportToExcel()
        {
            DataTable dtExport = GetData();
            //Name of File  
            string fileName = $"Books and Authors{ DateTime.Now.ToString()}.xlsx";
            using (XLWorkbook wb = new XLWorkbook())
            {
                //Add DataTable in worksheet with worksheetName
                wb.Worksheets.Add(dtExport, "Books and Authors");
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    //Return xlsx Excel File  
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                }
            }
        }
    }
}


