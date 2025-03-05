//using Ashdod_Port;
//using Ashdod_Port.Controllers;
//using Ashdod_Port.Core.Entities;
//using Microsoft.AspNetCore.Mvc;

//namespace Ashdod_Port.Test
//{
//    public class ContainersControllerTests
//    {

//        FakeContextServies fakeContextServies;
//        // בדיקת הוספת מכולה עם משקל לא תקין
//        [Fact]
//        public void AddContainer_WithInvalidWeight_ShouldReturnBadRequest()
//        {
//            // יצירת מכולה עם משקל לא תקין (שלילי)
//            var container = new Container
//            {
//                ImporterName = "Importer1",
//                SupplierName = "Supplier1",
//                Date = DateTime.Now,
//                Weight = -1000, // משקל שלילי לא תקין
//                Status = ContainerStatus.Arriving
//            };

//            // מנקים את הרשימה לפני כל בדיקה
//            fakeContextServies.ContainersList.Clear();

//            // מנסים להוסיף את המכולה
//            var fakeContext = new FakeContextServies();
//            var controller = new ContainersControllers(fakeContext);
//            var result = controller.Post(container);

//            // בדיקה שההחזרה היא BadRequest
//            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
//            Assert.Equal("Weight must be positive", badRequestResult.Value);
//        }

//        //// בדיקת הוספת מכולה עם מזהה כפול
//        //[Fact]
//        //public void AddContainer_WithDuplicateId_ShouldReturnBadRequest()
//        //{
//        //    // יצירת שתי מכולות עם אותו מזהה
//        //    var container1 = new Container { IdNum = 1, ImporterName = "Importer1", SupplierName = "Supplier1", Date = DateTime.Now, Weight = 5000, Status = ContainerStatus.Arriving };
//        //    var container2 = new Container { IdNum = 1, ImporterName = "Importer2", SupplierName = "Supplier2", Date = DateTime.Now, Weight = 4000, Status = ContainerStatus.Departing };

//        //    // מנקים את הרשימה ומוסיפים את המכולה הראשונה
//        //    DataContext.ContainersList.Clear();
//        //    DataContext.ContainersList.Add(container1);

//        //    // מנסים להוסיף את המכולה השנייה עם אותו מזהה
//        //    var controller = new ContainersController();
//        //    var result = controller.Post(container2);

//        //    // בדיקה שהתשובה היא BadRequest
//        //    var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
//        //    Assert.Equal("Container with the same ID already exists", badRequestResult.Value);
//        //}


//        // בדיקת מחיקת מכולה על פי מזהה
//        [Fact]
//        public void DeleteContainer_WithValidId_ShouldReturnOk()
//        {
//            // יצירת מכולה חדשה
//            var container = new Container { IdNum = 1, ImporterName = "Importer1", SupplierName = "Supplier1", Date = DateTime.Now, Weight = 5000, Status = ContainerStatus.Arriving };

//            // מנקים את הרשימה ומוסיפים את המכולה
//            fakeContextServies.ContainersList.Clear();
//            fakeContextServies.ContainersList.Add(container);

//            // מנסים למחוק את המכולה
//            var fakeContext = new FakeContextServies();
//            var controller = new ContainersControllers(fakeContext);
//            var result = controller.Delete(container.IdNum);

//            // בדיקה שהתשובה היא Ok
//            var okResult = Assert.IsType<OkResult>(result);
//            Assert.Equal(200, okResult.StatusCode);

//            // בדיקה שהמכולה נמחקה מהמערכת
//            var deletedContainer = fakeContextServies.ContainersList.FirstOrDefault(c => c.IdNum == container.IdNum);
//            Assert.Null(deletedContainer); // לא אמור להיות שום דבר עם מזהה זה
//        }

//        // בדיקת מחיקת מכולה לא קיימת
//        [Fact]
//        public void DeleteContainer_WithInvalidId_ShouldReturnNotFound()
//        {

//            // מנסים למחוק מכולה עם מזהה לא קיים

//            var fakeContext = new FakeContextServies();
//            var controller = new ContainersControllers(fakeContext);
//            var result = controller.Delete(999); // מזהה לא קיים

//            // בדיקה שהתשובה היא NotFound
//            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
//            Assert.Equal("Id container not found", notFoundResult.Value);
//        }
//    }
//}
