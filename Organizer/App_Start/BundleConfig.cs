using System.Web;
using System.Web.Optimization;

namespace Organizer
{
    public class BundleConfig
    {
        //Дополнительные сведения об объединении см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.2.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.js"));
            
            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство сборки на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                      "~/Scripts/modernizr-*"));

            // для работы с bootstrap datetimepicker
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/moment.min.js",
                      "~/Scripts/moment-with-locales.min.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/bootstrap-datetimepicker.js",
                      "~/Scripts/bootstrap-datetimepicker.min.js"));

            // Скрипты для работы элементов программы:
            // для представлений создания/редактирования записей ежедневника (notes) и контактов (contacts),
            // для инициализации работы элементов datetimepicker,
            // fix для jquery.validate.globalize.js для работы с датой. 
            bundles.Add(new ScriptBundle("~/bundles/organizer").Include(
                       "~/Scripts/organizer/contacts-create-edit.js",
                       "~/Scripts/organizer/notes-create-edit.js",
                       "~/Scripts/organizer/datetimepicker.js",
                       "~/Scripts/organizer/datetime-validator-method.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/bootstrap-datetimepicker.css"));
        }
    }
}
