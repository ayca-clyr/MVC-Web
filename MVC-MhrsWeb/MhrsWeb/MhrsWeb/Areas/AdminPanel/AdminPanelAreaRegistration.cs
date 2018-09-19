using System.Web.Mvc;

namespace MhrsWeb.Areas.AdminPanel
{
    public class AdminPanelAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AdminPanel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {


            context.MapRoute(
            "Klinik-islemleri",
            "admin-panel/klinik-islemleri",
            new { controller = "Klinik", action = "Index" },
            namespaces: new[] { "MhrsWeb.Areas.AdminPanel.Controllers" }
            );

            context.MapRoute(
            "Klinik-islemleri-Ekle",
            "admin-panel/klinik-islemleri/ekle",
            new { controller = "Klinik", action = "Create" },
            namespaces: new[] { "MhrsWeb.Areas.AdminPanel.Controllers" }
            );

            context.MapRoute(
            "Klinik-islemleri-Guncelle",
            "admin-panel/klinik-islemleri/guncelle/{SeoText}/{Id}",
            new { controller = "Klinik", action = "Edit", id = UrlParameter.Optional },
            namespaces: new[] { "MhrsWeb.Areas.AdminPanel.Controllers" }
            );


            context.MapRoute(
            "Yontici-islemleri",
            "admin-panel/yonetici-islemleri",
            new { controller = "Command", action = "Index" },
            namespaces: new[] { "MhrsWeb.Areas.AdminPanel.Controllers" }
            );

            context.MapRoute(
            "Yönetici-islemleri-Ekle",
            "admin-panel/yönetici-islemleri/ekle",
            new { controller = "Command", action = "Create" },
            namespaces: new[] { "MhrsWeb.Areas.AdminPanel.Controllers" }
            );

            context.MapRoute(
            "Yönetici-islemleri-Guncelle",
            "admin-panel/yönetici-islemleri/guncelle/{SeoText}/{Id}",
            new { controller = "Command", action = "Edit", id = UrlParameter.Optional },
            namespaces: new[] { "MhrsWeb.Areas.AdminPanel.Controllers" }
            );


            context.MapRoute(
            "Doktor-islemleri",
            "admin-panel/doktor-islemleri",
            new { controller = "Doctor", action = "Index" },
            namespaces: new[] { "MhrsWeb.Areas.AdminPanel.Controllers" }
            );


            context.MapRoute(
            "Doktor-islemleri-Ekle",
            "admin-panel/doktor-islemleri/ekle",
            new { controller = "Doctor", action = "Create" },
            namespaces: new[] { "MhrsWeb.Areas.AdminPanel.Controllers" }
            );

            context.MapRoute(
            "Doktor-islemleri-Guncelle",
            "admin-panel/doktor-islemleri/guncelle/{SeoText}/{Id}",
            new { controller = "Doctor", action = "Edit", id = UrlParameter.Optional },
            namespaces: new[] { "MhrsWeb.Areas.AdminPanel.Controllers" }
            );

            context.MapRoute(
            "DoktorTarih-islemleri",
            "admin-panel/doktor-tarih-islemleri",
            new { controller = "Tarih", action = "Index" },
            namespaces: new[] { "MhrsWeb.Areas.AdminPanel.Controllers" }
            );

            context.MapRoute(
            "DoktorTarih-islemleri-Ekle",
            "admin-panel/doktor-tarih-ekle",
            new { controller = "Tarih", action = "TarihleriKaydet" },
            namespaces: new[] { "MhrsWeb.Areas.AdminPanel.Controllers" }
            );

            context.MapRoute(
            "DoktorSaat-islemleri",
            "admin-panel/doktor-saat-islemleri",
            new { controller = "RandevuSaati", action = "Index" },
            namespaces: new[] { "MhrsWeb.Areas.AdminPanel.Controllers" }
            );

            context.MapRoute(
            "DoktorSaat-islemleri-Ekle",
            "admin-panel/doktor-saat-islemleri",
            new { controller = "RandevuSaati", action = "TarihleriKaydet" },
            namespaces: new[] { "MhrsWeb.Areas.AdminPanel.Controllers" }
            );

            context.MapRoute(
            "Admin-kullanici-bilgileri",
            "admin-panel/admin-kullanici-bilgileri",
            new { controller = "Home", action = "KullaniciBilgileri" },
            namespaces: new[] { "MhrsWeb.Areas.AdminPanel.Controllers" }
            );

            context.MapRoute(
            "Admin-sifremi-unuttum",
            "admin-panel/admin-sifremi-unuttum",
            new { controller = "Login", action = "SifremiUnuttum" },
            namespaces: new[] { "MhrsWeb.Areas.AdminPanel.Controllers" }
            );


            context.MapRoute(
                "AdminPanel_default",
                "AdminPanel/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "MhrsWeb.Areas.AdminPanel.Controllers" }
            );
        }
    }
}