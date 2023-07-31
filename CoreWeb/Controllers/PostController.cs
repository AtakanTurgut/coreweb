﻿using BL;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.Controllers
{
    public class PostController : Controller
    {
        PostManager postManager = new PostManager();

        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                return View(postManager.GetAll());
            }
            else
            {
                return View(postManager.GetAll(c => c.CategoryId == id));
            }

        }

        public IActionResult Detail(int id)
        {
            return View(postManager.Find(id));
        }
    }
}
