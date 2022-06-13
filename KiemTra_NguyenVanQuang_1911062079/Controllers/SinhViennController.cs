using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiemTra_NguyenVanQuang_1911062079.Models;


namespace KiemTra_NguyenVanQuang_1911062079.Controllers
{
    public class SinhViennController : Controller
    {
        Test01 data = new Test01();
        // GET: SinhVien
        public ActionResult ListSinhVien()
        {
            var sinhvien = from s in data.SinhViens select s;
            return View(sinhvien);
        }
        public ActionResult Details(string id)
        {
            var sinhvien = data.SinhViens.Where(s => s.MaSV == id).First();
            return View(sinhvien);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien s)
        {
            var hoten = collection["hoten"];
            var gioitinh = collection["gioitinh"];
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["ngaysinh"]);
            var hinh = collection["hinh"];
            var manganh = collection["manganh"];

            if (string.IsNullOrEmpty(hoten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.HoTen = hoten.ToString();
                s.GioiTinh = gioitinh.ToString();
                s.NgaySinh = DateTime.Parse(ngaysinh);
                s.Hinh = hinh.ToString();
                s.MaNganh = manganh.ToString();
                data.SinhViens.Add(s);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
        //Edit
        public ActionResult Edit(string id)
        {
            var sinhVien = data.SinhViens.First(s => s.MaSV == id);
            return View(sinhVien);
        }
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var masv = data.SinhViens.First(s => s.MaSV == id);
            var hoten = collection["hoten"];
            var gioitinh = collection["gioitinh"];
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["ngaysinh"]);
            var hinh = collection["hinh"];
            var manganh = collection["manganh"];
            masv.MaSV = id;
            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                masv.HoTen = hoten.ToString();
                masv.GioiTinh = gioitinh.ToString();
                masv.NgaySinh = DateTime.Parse(ngaysinh);
                masv.Hinh = hinh.ToString();
                masv.MaNganh = manganh.ToString();
                UpdateModel(masv);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }

        //Delete
        public ActionResult Delete(string id)
        {
            var sinhvien = data.SinhViens.First(s => s.MaSV == id);
            return View(sinhvien);
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var sinhvien = data.SinhViens.Where(s => s.MaSV == id).First();
            data.SinhViens.Remove(sinhvien);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}