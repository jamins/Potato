using PotatoApi.Services;
using PotatoApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace PotatoApi.Controllers
{
    public class HomeController : Controller

    {
        private readonly PotatoServices _potatoService;
        private readonly CroppedPotatoServices _croppedPotatoServices;

        public HomeController(PotatoServices potatoService,CroppedPotatoServices croppedPotatoServices)
        {
            _potatoService = potatoService;
            _croppedPotatoServices = croppedPotatoServices;
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Cropped()
        {

            return View();
        }

        public IActionResult Create(PotatoViewModel potato)
        {
            PotatoQ potato1 = new PotatoQ { };
            if (potato.Img != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(potato.Img.OpenReadStream()))
                {
                    
                    imageData = binaryReader.ReadBytes((int)potato.Img.Length);
                    
                }
                // установка массива байтов
                potato1.Name = potato.Img.FileName;
                potato1.Base64 = Convert.ToBase64String(imageData);
            }
            if (potato.IsPotato == true)
                potato1.IsPotato = true;
            else
                potato1.IsPotato = false;
            _potatoService.Create(potato1);
            return RedirectToAction("Index");
        }
        public IActionResult CreateCropped(CroppedPotatoViewModel potato)
        {
            CroppedPotato potato1 = new CroppedPotato { };
            if (potato.Img != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(potato.Img.OpenReadStream()))
                {

                    imageData = binaryReader.ReadBytes((int)potato.Img.Length);

                }
                // установка массива байтов
                potato1.Name = potato.Img.FileName;
                potato1.Base64 = Convert.ToBase64String(imageData);
            }
            _croppedPotatoServices.Create(potato1);
            return RedirectToAction("Cropped");
        }

    }
}
