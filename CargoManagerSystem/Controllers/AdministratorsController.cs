﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CargoClass;
using CargoManagerSystem.Models;

namespace CargoManagerSystem.Controllers
{
    public class AdministratorsController : Controller
    {
        private CargoContext db = new CargoContext();

        public async Task<ActionResult> EmployeeList()
        {

            return View(await db.Employees.ToListAsync());

        }

        [HttpGet]

        public ActionResult CreateEmployee() => View();

        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<ActionResult> CreateEmployee(Employee employee)
        {

            if (ModelState.IsValid)

            {

                db.Employees.Add(employee);

                await db.SaveChangesAsync();

                return RedirectToAction("EmployeeList");

            }

            return View(employee);

        }

        [HttpGet]

        public ActionResult UpdateEmployee(int id)

        {

            var emp = db.Employees.Find(id);

            if (emp == null) return HttpNotFound();

            return View(emp);

        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<ActionResult> UpdateEmployee(Employee emp)

        {

            if (ModelState.IsValid)

            {

                db.Entry(emp).State = EntityState.Modified;

                await db.SaveChangesAsync();

                return RedirectToAction("EmployeeList");

            }

            return View(emp);

        }

        // 🔹 Search Employee
        [HttpGet]
        public ActionResult SearchEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SearchEmployee(string searchQuery)
        {
            var employees = await db.Employees.Where(e => e.Name.Contains(searchQuery) || e.Email.Contains(searchQuery)).ToListAsync();
            return View("EmployeeList", employees);
        }

        public async Task<ActionResult> DeleteEmployee(int id)
        {

            Employee employee = await db.Employees.FindAsync(id);

            if (employee == null) return HttpNotFound();

            db.Employees.Remove(employee);

            await db.SaveChangesAsync();

            return RedirectToAction("EmployeeList");

        }
        ////customer management
        //public async Task<ActionResult> CustomerList()
        //{

        //    return View(await db.Customers.ToListAsync());

        //}

        //[HttpGet]

        //public ActionResult SearchCustomer()
        //{
        //    return View();

        //}

        //[HttpPost]

        //public async Task<ActionResult> SearchCustomer(string searchQuery)

        //{

        //    var customers = await db.Customers.Where(c => c.Name.Contains(searchQuery) || c.Email.Contains(searchQuery)).ToListAsync();

        //    return View("CustomerList", customers);

        //}
        ////

        

        // 🔹 Cargo Type Management

        // ===========================

        public async Task<ActionResult> CargoTypeList()

        {

            return View(await db.CargoTypes.ToListAsync());

        }

        [HttpGet]

        public ActionResult AddCargoType() => View();

        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<ActionResult> AddCargoType(CargoType cargoType)
        {

            if (ModelState.IsValid)

            {

                db.CargoTypes.Add(cargoType);

                await db.SaveChangesAsync();

                return RedirectToAction("CargoTypeList");

            }

            return View(cargoType);

        }

        [HttpGet]

        public async Task<ActionResult> UpdateCargoType(int id)

        {

            var cargoType = await db.CargoTypes.FindAsync(id);

            if (cargoType == null) return HttpNotFound();

            return View(cargoType);

        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<ActionResult> UpdateCargoType(CargoType cargoType)

        {

            if (ModelState.IsValid)

            {

                db.Entry(cargoType).State = EntityState.Modified;

                await db.SaveChangesAsync();

                return RedirectToAction("CargoTypeList");

            }

            return View(cargoType);

        }
        

// City Management

public async Task<ActionResult> CityList()
        {

            return View(await db.Cities.ToListAsync());

        }

        [HttpGet]

        public ActionResult AddCity() => View();

        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<ActionResult> AddCity(City city)
        {

            if (ModelState.IsValid)

            {

                db.Cities.Add(city);

                await db.SaveChangesAsync();

                return RedirectToAction("CityList");

            }

            return View(city);

        }

        [HttpGet]
        public async Task<ActionResult> UpdateCity(int id)
        {
            var city = await db.Cities.FindAsync(id);
            if (city == null) return HttpNotFound();
            return View(city);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateCity(City city)
        {
            if (ModelState.IsValid)
            {
                db.Entry(city).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("CityList");
            }
            return View(city);
        }

    }
}
