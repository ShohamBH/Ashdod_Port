
//using Ashdod_Port;
//using Ashdod_Port.Core.Entities;


//namespace Ashdod_Port.Test
//{

//    public class SupplierTests
//    {
//        FakeContextServies fakeContextServies;
//        [Fact]
//        public void AddSupplier_WithValidDetails_ShouldAddSupplier()
//        {
//            // יוצרים ספק חדש
//            var supplier = new Supplier
//            {
//                Id = "123456789",
//                Phone = "0523456789",
//                Name = "Supplier A"
//            };

//            // מנקים את הרשימה לפני הבדיקה
//           fakeContextServies .SuppliersLst.Clear();

//            // מוסיפים את הספק לרשימה
//            fakeContextServies.SuppliersLst.Add(supplier);

//            // בודקים אם הספק אכן התווסף לרשימה
//            Assert.Contains(supplier, fakeContextServies.SuppliersLst);
//        }

//        [Fact]
//        public void AddSupplier_WithDuplicateId_ShouldNotAllowAddition()
//        {
//            // יוצרים שני ספקים עם אותו מזהה
//            var supplier1 = new Supplier { Id = "123456789", Phone = "0523456789", Name = "Supplier A" };
//            var supplier2 = new Supplier { Id = "123456789", Phone = "0533333333", Name = "Supplier B" };

//            // מנקים את הרשימה ומוסיפים ספק ראשון
//            fakeContextServies.SuppliersLst.Clear();
//            fakeContextServies.SuppliersLst.Add(supplier1);

//            // מנסים להוסיף ספק נוסף עם אותו מזהה ובודקים שאינו נוסף
//            bool supplierAdded = fakeContextServies.SuppliersLst.Contains(supplier2);
//            Assert.False(supplierAdded, "Supplier with duplicate ID was added.");
//        }

//        [Fact]
//        public void AddSupplier_WithDuplicatePhone_ShouldNotAllowAddition()
//        {
//            // יוצרים שני ספקים עם אותו טלפון
//            var supplier1 = new Supplier { Id = "123456789", Phone = "0523456789", Name = "Supplier A" };
//            var supplier2 = new Supplier { Id = "987654321", Phone = "0523456789", Name = "Supplier B" };

//            // מנקים את הרשימה ומוסיפים ספק ראשון
//            fakeContextServies.SuppliersLst.Clear();
//            fakeContextServies.SuppliersLst.Add(supplier1);

//            // מנסים להוסיף ספק נוסף עם אותו טלפון ובודקים שאינו נוסף
//            bool supplierAdded = fakeContextServies.SuppliersLst.Contains(supplier2);
//            Assert.False(supplierAdded, "Supplier with duplicate phone was added.");
//        }
//    }
//}

