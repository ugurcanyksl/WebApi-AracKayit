using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Client.Controllers
{
    public class CarController : ApiController
    {
        CarDBEntities db = new CarDBEntities();

        //listeleme işlemi
        [HttpGet]
        public IHttpActionResult Listele()
        {
            return Ok(db.Cars.ToList());
        }

        //ID'ye göre istenileni getir...
        public HttpResponseMessage GetById(int id)
        {
            Car car = db.Cars.Find(id);
            if (car==null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"{id} numaralı Araç kaydı bulunamadı.");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, car);
            }
        }

        public HttpResponseMessage Post(Car car)
        {
            try
            {
                db.Cars.Add(car);
                if (db.SaveChanges()>1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Araç Eklendi");
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Araç Ekleme Başarısız");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            var car = db.Cars.Find(id);
            if (car==null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"{id} numaralı araç bulunamadı");
            }
            else
            {
                db.Cars.Remove(car);
                if (db.SaveChanges()>0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Veri Silme Başarılı");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Aracanız Silinemedi, Başarısız...");
                }
                
            }
        }

        public HttpResponseMessage PutCar(int id, Car car)
        {
            var updated = db.Cars.Find(id);
            if (updated==null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Düzenlenecek Kayıt Bulunamadı!");
            }
            else
            {
                updated.Marka = car.Marka;
                updated.Model = car.Model;
                updated.Yakit = car.Yakit;
                updated.Renk = car.Renk;
                updated.VitesTip = car.VitesTip;
                updated.Kasa = car.Kasa;
                updated.ModelYil = car.ModelYil;

                if (db.SaveChanges()>0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, updated);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Düzenlenecek kayıt bulunamadı");
                }
            }
        }





    }
}
