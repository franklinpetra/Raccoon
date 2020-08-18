using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller

        // ==================================
        //     Starting Route
        // ==================================
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("Fullness") == null){
                HttpContext.Session.SetInt32("Fullness", 20);
            }
            if (HttpContext.Session.GetInt32("Happiness") == null){
                HttpContext.Session.SetInt32("Happiness", 20);
            }
            if (HttpContext.Session.GetInt32("Meals") == null){
                HttpContext.Session.SetInt32("Meals", 3);
            } 
            if (HttpContext.Session.GetInt32("Energy") == null){
                HttpContext.Session.SetInt32("Energy", 50);
            }
            if (HttpContext.Session.GetString("Image")==null){ 
                HttpContext.Session.SetString("Image","Raccoon.jpg");
            } 
            if (HttpContext.Session.GetInt32("Energy")>100 &&  
                HttpContext.Session.GetInt32("Fullness")>100 &&
                HttpContext.Session.GetInt32("Energy")>100)
                {
                    ViewBag.Status = "Win";
                    ViewBag.EndMessage = "Success!  Congratulations! Your Dojodashi is blissed out! Let's chill!";
                    ViewBag.Image = "chillingtenor.gif";
                } 
            
            if (HttpContext.Session.GetInt32("Happiness")<=0 ||
                HttpContext.Session.GetInt32("Fullness")<=0 )
                
                {

                    HttpContext.Session.SetString("Image","burryingandrevives.gif");                        
                    ViewBag.Status = "Lose";
                    ViewBag.EndMessage = "Sadly, Dashi Raccoon has passed away. A moment of silence please.";
                } 

            ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");
            ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
            ViewBag.Meals = HttpContext.Session.GetInt32("Meals");
            ViewBag.Energy = HttpContext.Session.GetInt32("Energy");
            ViewBag.Image = HttpContext.Session.GetString("Image");
            ViewBag.Message = HttpContext.Session.GetString("Message");
            // HttpContext.Session.SetString("Image","raccoon.jpg");
            // ViewBag.Image = "raccoon.jpg";
            return View();
        }

        // ==================================
        //     Feed Route
        // ==================================

        [HttpPost("Feed")]
        public IActionResult Feed()
        {
            
            Random rand = new Random();
            int? FullnessCount = HttpContext.Session.GetInt32("Fullness");
            int NewFullnessCount = FullnessCount ?? default(int);
            int? MealsCount = HttpContext.Session.GetInt32("Meals");
            int NewMealsCount = MealsCount ?? default(int);
            int AmountFullness = rand.Next(5,11);

            if (NewMealsCount > 0)
            {
                HttpContext.Session.SetInt32("Fullness", NewFullnessCount + AmountFullness);
                HttpContext.Session.SetInt32("Meals", NewMealsCount -1);
                HttpContext.Session.SetString("Message", $"Dashi Raccoon has eaten and has gained {AmountFullness}.");
                HttpContext.Session.SetString("Image", "eating.gif");
                HttpContext.Session.SetString("Image2", "yummygrapes.gif");
                HttpContext.Session.SetString("Image3", "pomegranateEatingRaccoon.gif");
                
                return RedirectToAction ("Index");
            }
            else
            {
                HttpContext.Session.SetString("Message","Dashi Raccoon does not have enough food to Eat! Perhaps he could work a bit to earn a few meals and try again.");
                HttpContext.Session.SetString("Image","hungry.gif");
                return RedirectToAction ("Index");
            }
        }

        // ==================================
        //     Sleep Route
        // ==================================

        [HttpPost("Sleep")]
        public IActionResult Sleep()
        {
            int? HappinessCount = HttpContext.Session.GetInt32("Happiness");
            int NewHappinessCount = HappinessCount ?? default(int);
            int? FullnessCount = HttpContext.Session.GetInt32("Fullness");
            int NewFullnessCount = FullnessCount ?? default(int);
            int? EnergyCount = HttpContext.Session.GetInt32("Energy");
            int NewEnergyCount = EnergyCount ?? default(int);
            {
                HttpContext.Session.SetInt32("Happiness", (int)HappinessCount - 5);
                HttpContext.Session.SetInt32("Fullness", (int)FullnessCount - 5);
                HttpContext.Session.SetInt32("Energy", (int)EnergyCount + 15);
                HttpContext.Session.SetString("Image","sleepy.gif");
                HttpContext.Session.SetString("Image2","sleepingRaccoon.jpg");
                HttpContext.Session.SetString("Image3","sleepBasketRaccoon.jpg");
                HttpContext.Session.SetString("Message","Dashi Raccoon slept soundly and has 15 more Energy!");
                
                return RedirectToAction("Index");
            }
        }
        // ==================================
        //     Work Route
        // ==================================

        [HttpPost("Work")]
        public IActionResult Work()
        {
            Random rand = new Random();
            int? EnergyCount = HttpContext.Session.GetInt32("Energy");
            int NewEnergyCount = EnergyCount ?? default(int);
            int? MealsCount = HttpContext.Session.GetInt32("Meals");
            int NewMealsCount = MealsCount ?? default(int);
            int AmountFood = rand.Next(1,3);

            HttpContext.Session.SetInt32("Energy", NewEnergyCount -5);
            HttpContext.Session.SetInt32("Meals", NewMealsCount + AmountFood);
            HttpContext.Session.SetString("Message", $"Dashi Raccoon has finished working, {AmountFood} was added to the meal supply.");
            HttpContext.Session.SetString("Image", "offtowortenor.gif");
            HttpContext.Session.SetString("Image2", "answeringphone.jpg");
            HttpContext.Session.SetString("Image3", "sweeping.gif");
            return RedirectToAction("Index");
        }


        // ==================================
        //     Play Route
        // ==================================
        
        [HttpPost("Play")]
        public IActionResult Play()
        {
            Random rand = new Random();
            int? EnergyCount = HttpContext.Session.GetInt32("Energy");
            int NewEnergyCount = EnergyCount ?? default(int);
            int? HappinessCount = HttpContext.Session.GetInt32("Happiness");
            int NewHappinessCount = HappinessCount ?? default(int);
            int AmountHappiness = rand.Next(5, 10);

            if (EnergyCount > 5)
            {
                HttpContext.Session.SetInt32("Energy", NewEnergyCount - 5);
                HttpContext.Session.SetInt32("Happiness", NewHappinessCount + AmountHappiness);
                HttpContext.Session.SetString("Message", $"Dashi Raccoon has finished playing. Happiness increased by {AmountHappiness}!");
                HttpContext.Session.SetString("Image","bicycle.gif");
                HttpContext.Session.SetString("Image2","pianoRaccoon.gif");
                HttpContext.Session.SetString("Image3","mathyRaccoon.gif");
                HttpContext.Session.SetString("Image4","waterRaccoon.gif");
                HttpContext.Session.SetString("Image4","waterRaccoon.gif");
                // ViewBag.Energy = HttpContext.Session.GetInt32("Energy");
                // ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
                return RedirectToAction("Index");
            }
            else
                ViewBag.NoPlayMessage = "Dashi raccoon needs more Energy before he can go play.";
                return View ("Index");
        }
        
        // ==================================
        //     Restart Route
        // ==================================

        [HttpPost("Restart")]
        
        public IActionResult Restart() 
            {
                HttpContext.Session.Clear();
                HttpContext.Session.SetString("Image","raccoon.gif");
                return RedirectToAction("Index");
            }    
    }
}
