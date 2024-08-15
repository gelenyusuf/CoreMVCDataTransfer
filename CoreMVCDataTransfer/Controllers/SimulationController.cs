using Microsoft.AspNetCore.Mvc;
using CoreMVCDataTransfer.Models;
namespace CoreMVCDataTransfer.Controllers
{
    public class SimulationController : Controller
    {

        //Bütün DataTransfer yapıları ilkel tipleri ile çalışmaya uygundur.
        //Her ne kadar kompleks tiplere destek verselerde kompleks tipler ile kullanılmaları kesinlikle sağlıklı değildir.
        //ViewBag =>>> Sadece Controller içerisindeki Action'dan View 'ınıza veri gönderme görevi uygular.

        //Eğer model gönderme yöntemiyle veri göndermiyorsak o verinin karşılanmasına gerek yoktur.Zaten istesek de karşılayamayız.
        //ViewData => Actiondan View a veri gönderir.lakin verileri object tipte tutar.

        //TempData =>Diğer DataTransfer yapılarına ek olarak aynı zamanda Action'dan Actiona da veri gönderebilen bir DataTransfer yapısıdır.
        //Laki bu temporary bir datadır.(tek kullanımlıktır.)

        public IActionResult Index()
        {
            Kisi k = new Kisi() { 
             Ad= "Yusuf",
             Soyad="Gelen"
            };
            ViewBag.Mesaj = k;
            //Bu tarz yapıların kompleks yapılarla kullanılmaması gerekir.
            return View();
        }
        public IActionResult ViewDataUsage() {
            /*Kisi k = new Kisi() { 
             Ad= "Yusuf",
             Soyad="Gelen"
            };
            ViewData["mesaj"] = k;
             */

            ViewData["mesaj"] = 12;
            return View();
        
        }
        public IActionResult TempDataUsage() {

            TempData["sayi"] = 100;
            TempData.Keep("sayi"); //TempData yı bir yerde daha kullanılmasını sağlar.
            return View();
        }
        public IActionResult Deneme()
        {
            int sayi = Convert.ToInt32(TempData["sayi"]);
            
            return View();
        }
    }
}
