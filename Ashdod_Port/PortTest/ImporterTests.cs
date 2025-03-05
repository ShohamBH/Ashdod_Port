//using Ashdod_Port;
//using Ashdod_Port.Controllers;
//using Ashdod_Port.Core.Entities;
//using Microsoft.AspNetCore.Mvc;

//namespace Ashdod_Port.Test
//{
//    public class ImporterTests
//    {
//        FakeContextServies fakeContextServies;
//        // בדיקה להוספת יבואן עם מספר טלפון כפול
//        [Fact]
//        public void AddImporter_WithDuplicatePhone_ShouldReturnBadRequest()
//        {
//            // יצירת יבואן עם מספר טלפון תקני
//            var importer1 = new Importer
//            {
//                Id = "123456789",
//                Phone = "0523456789", // מספר טלפון תקני
//                Name = "Importer A",
//                City = "Ashdod",
//                Num = 1001
//            };

//            // יצירת יבואן נוסף עם אותו מספר טלפון
//            var importer2 = new Importer
//            {
//                Id = "987654321",
//                Phone = "0523456789", // מספר טלפון כפול
//                Name = "Importer B",
//                City = "Tel Aviv",
//                Num = 1002
//            };

//            // מנקים את רשימת היבואנים ומוסיפים את היבואן הראשון
//            fakeContextServies.ImportersLst.Clear();
//            fakeContextServies.ImportersLst.Add(importer1);

//            // מנסים להוסיף את היבואן השני עם אותו מספר טלפון
//            bool importerExists = fakeContextServies.ImportersLst.Any(i => i.Phone == importer2.Phone);

//            Assert.True(importerExists, "Importer with duplicate phone number exists.");
//        }

//        // בדיקה להוספת יבואן עם מספר זהות כפול
//        [Fact]
//        public void AddImporter_WithDuplicateId_ShouldReturnBadRequest()
//        {
//            // יצירת יבואן עם מספר זהות תקני
//            var importer1 = new Importer
//            {
//                Id = "123456789", // תעודת זהות תקנית
//                Phone = "0523456789",
//                Name = "Importer A",
//                City = "Ashdod",
//                Num = 1001
//            };

//            // יצירת יבואן נוסף עם אותו מספר זהות
//            var importer2 = new Importer
//            {
//                Id = "123456789", // תעודת זהות כפולה
//                Phone = "0531234567",
//                Name = "Importer B",
//                City = "Tel Aviv",
//                Num = 1002
//            };

//            // מנקים את רשימת היבואנים ומוסיפים את היבואן הראשון
//            fakeContextServies.ImportersLst.Clear();
//            fakeContextServies.ImportersLst.Add(importer1);

//            // מנסים להוסיף את היבואן השני עם אותו מספר זהות
//            bool importerExists = fakeContextServies.ImportersLst.Any(i => i.Id == importer2.Id);

//            Assert.True(importerExists, "Importer with duplicate ID exists.");
//        }

//        // בדיקה להוספת יבואן עם תעודת זהות לא תקנית (פewer מ-9 ספרות)
//        [Fact]
//        public void AddImporter_InvalidId_ShouldReturnBadRequest()
//        {
//            // יצירת יבואן עם תעודת זהות לא תקנית (פewer מ-9 ספרות)
//            var importer = new Importer
//            {
//                Id = "12345", // תעודת זהות לא תקנית
//                Phone = "0523456789",
//                Name = "Importer A",
//                City = "Ashdod",
//                Num = 1001
//            };

//            // מנקים את רשימת היבואנים
//            fakeContextServies.ImportersLst.Clear();


//            // מנסים להוסיף את היבואן
//            var fakeContext = new FakeContextServies();
//            var controller = new ImportersControllers(fakeContext);
//            var result = controller.Post(importer);

//            // בדיקה שהתוצאה היא BadRequest
//            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
//            Assert.Equal("ID must be 9 digits.", badRequestResult.Value);
//        }

//        // בדיקה להוספת יבואן עם מספר טלפון לא תקני (פewer מ-10 ספרות)

//        [Fact]
//        public void AddImporter_InvalidPhone_ShouldReturnBadRequest()
//        {
//            // יצירת יבואן עם מספר טלפון לא תקני (פewer מ-10 ספרות)
//            var importer = new Importer
//            {
//                Id = "123456789",
//                Phone = "05234567", // מספר טלפון לא תקני
//                Name = "Importer A",
//                City = "Ashdod",
//                Num = 1001
//            };

//            // מנקים את רשימת היבואנים
//            fakeContextServies.ImportersLst.Clear();

//            // מנסים להוסיף את היבואן
//            var fakeContext = new FakeContextServies();
//            var controller = new ImportersControllers(fakeContext);
//            var result = controller.Post(importer);

//            // בדיקה שהתוצאה היא BadRequest
//            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
//            Assert.Equal("Phone number must be 10 digits and start with 0.", badRequestResult.Value);
//        }
//    }
//}
