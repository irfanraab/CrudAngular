﻿using CrudProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudProject.Controllers
{
    public class PlayerController : Controller
    {
        private CrudContext _context = null;

        public PlayerController()
        {
            _context = new CrudContext();
        }
        // GET: Player
        public JsonResult GetPlayers()
        {
            List<Player> listPlayer = _context.Players.ToList();
            return Json(new { list = listPlayer },JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPlayerById(int id)
        {
            Player player = _context.Players.Where(c => c.PlayerId == id).SingleOrDefault();
            return Json(new { player = player },JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddPlayer(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
            return Json(new { status = "Player added successfully" });
        }

        public JsonResult UpdatePlayer(Player player)
        {
            _context.Entry(player).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return Json(new { status = "Player updated successfully" });
        }

        public JsonResult Deleteplayer(int id)
        {
            Player player = _context.Players.Where(c => c.PlayerId == id).SingleOrDefault();
            _context.Players.Remove(player);
            _context.SaveChanges();
            return Json(new { status = "Player deleted successfully" });
        }
    }
}