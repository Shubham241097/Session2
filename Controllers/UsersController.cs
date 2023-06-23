using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Session2.AppDbContext;
using Session2.Models;
using Session2.Services;

namespace Session2.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService,IMapper mapper) 
        { 
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var user = _userService.GetAllUsers();
            var users = _mapper.Map<User>(user);
            return View(users);
        }

        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(User user) 
        {
            if (ModelState.IsValid)
            {
                var userModel = _mapper.Map<User>(user);
                _userService.AddUser(userModel);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            else 
            {
                var userView = _mapper.Map<User>(user);
                return View(userView);
            }
        }

        [HttpPost]
        public IActionResult Edit(User user) 
        {
            if (ModelState.IsValid)
            {
                var userModel = _mapper.Map<User>(user);
                _userService.UpdateUser(userModel);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            var user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            var userView = _mapper.Map<User>(user);

            return View(userView);

        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id) 
        {
            _userService.DeleteUser(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UserDetails(int id) 
        {
            var user = _userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            var userView = _mapper.Map<User>(user);

            return View(userView);
        }
    }
}
