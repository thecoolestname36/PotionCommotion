using System;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using PotionCommotion.Entities;
using PotionCommotion.Components;
using PotionCommotion.Models;

namespace PotionCommotion.Controllers {
    public class DefaultController : Controller {

        public const string POTION_HTML_ID_PREFIX = "potion-";

        // GET: Default
        public ActionResult Index() {
            return View();
        }

        public ActionResult PotionsGrid() {

            var context = new PCContext();
            var potions = context.Potions.ToList();
            decimal cols = 12;
            decimal count = (decimal)potions.Count;
            int rows = (int)Math.Ceiling(count / cols);
            ViewBag.potionsGrid = new List<List<Potion>>(rows);
            int rowIndex = -1;
            for (int i = 0, iMax = potions.Count; i < iMax; i++) {

                if (i % cols == 0) {
                    rowIndex++;
                    ViewBag.potionsGrid.Add(new List<Potion>());
                }

                ViewBag.potionsGrid[rowIndex].Add(potions.ElementAt(0));
                potions.RemoveAt(0);

            }
            return PartialView("_PotionsGrid");
        }

        [HttpGet]
        public JsonResult SelectPotion(int id) {
            var context = new PCContext();
            var potion = context.Potions
                .Where(m => m.Id == id)
                .FirstOrDefault();
            if (potion != null) {
                WebSocketManager.Broadcast(new ServerMessage() {
                    Command = ServerMessage.Commands.Selected,
                    Content = POTION_HTML_ID_PREFIX + id
                });
                if (!potion.Selected) {
                    potion.Selected = true;
                    context.SaveChanges();
                }
                return Json(new JsonResponse<string>() {
                    Code = 200,
                    Result = potion.Description
                }, JsonRequestBehavior.AllowGet);
            } else {
                return Json(new JsonResponse<string>() {
                    Code = 404,
                    Result = "Not found"
                }, JsonRequestBehavior.AllowGet);
            }
        }
        
        [HttpGet]
        public JsonResult Reset() {

            Potion.ResetContext();
            WebSocketManager.Broadcast(new ServerMessage() {
                Command = ServerMessage.Commands.Reset
            });
            return Json(new JsonResponse<string>(){ 
                Code = 200,
                Result = "success"
            }, JsonRequestBehavior.AllowGet);
        }

    }

}
