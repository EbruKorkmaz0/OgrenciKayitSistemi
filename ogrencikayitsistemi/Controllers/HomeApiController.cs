﻿using ogrencikayitsistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ogrencikayitsistemi.Controllers
{
    public class HomeApiController : ApiController
    {
        public IEnumerable<Ogrenci> Get()
        {
            MvcContext db = new MvcContext();
            List<Ogrenci> ogrenciler = db.Ogrenci.ToList();
            return ogrenciler;
        }

        public HttpResponseMessage Post(Ogrenci ogrenci)
        {
            try
            {
                MvcContext db = new MvcContext();
                db.Ogrenci.Add(ogrenci);
                if (db.SaveChanges() > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, ogrenci.ad + " " + ogrenci.soyad + " adlı kullanıcı eklendi.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ogrenci.ad + " " + ogrenci.soyad + " adlı kullanıcı eklenemedi.");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public HttpResponseMessage Put(Ogrenci ogrenci)
        {
            
            try
            {
                MvcContext db = new MvcContext();
                Ogrenci k = db.Ogrenci.Where(x => x.id == ogrenci.id).SingleOrDefault();
                if (k == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "id : " + ogrenci.id);
                }

                k.ad = ogrenci.ad;
                k.soyad = ogrenci.soyad;
                k.telefon = ogrenci.telefon;
                k.adres = ogrenci.adres;
                k.sinif = ogrenci.sinif;

                if (db.SaveChanges() > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, " Öğrenci bilgileri düzenlendi.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Öğrenci bilgileri düzenlenemedi.");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public HttpResponseMessage Delete(int id)
        {
            
            try
            {
                MvcContext db = new MvcContext();
                Ogrenci k = db.Ogrenci.Where(x => x.id == id).SingleOrDefault();
                if (k == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "id : " + id);
                }

                db.Ogrenci.Remove(k);

                if (db.SaveChanges() > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Öğrenci silindi.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Öğrenci silinemedi.");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }


    }
}
       
        
            
    
