//using Ashdod_Port;
//using Ashdod_Port.Controllers;
//using Ashdod_Port.Core.Entities;
//using Microsoft.AspNetCore.Mvc;

//namespace Ashdod_Port.Test
//{
//    public class ContainersControllerTests
//    {

//        FakeContextServies fakeContextServies;
//        // ����� ����� ����� �� ���� �� ����
//        [Fact]
//        public void AddContainer_WithInvalidWeight_ShouldReturnBadRequest()
//        {
//            // ����� ����� �� ���� �� ���� (�����)
//            var container = new Container
//            {
//                ImporterName = "Importer1",
//                SupplierName = "Supplier1",
//                Date = DateTime.Now,
//                Weight = -1000, // ���� ����� �� ����
//                Status = ContainerStatus.Arriving
//            };

//            // ����� �� ������ ���� �� �����
//            fakeContextServies.ContainersList.Clear();

//            // ����� ������ �� ������
//            var fakeContext = new FakeContextServies();
//            var controller = new ContainersControllers(fakeContext);
//            var result = controller.Post(container);

//            // ����� ������� ��� BadRequest
//            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
//            Assert.Equal("Weight must be positive", badRequestResult.Value);
//        }

//        //// ����� ����� ����� �� ���� ����
//        //[Fact]
//        //public void AddContainer_WithDuplicateId_ShouldReturnBadRequest()
//        //{
//        //    // ����� ��� ������ �� ���� ����
//        //    var container1 = new Container { IdNum = 1, ImporterName = "Importer1", SupplierName = "Supplier1", Date = DateTime.Now, Weight = 5000, Status = ContainerStatus.Arriving };
//        //    var container2 = new Container { IdNum = 1, ImporterName = "Importer2", SupplierName = "Supplier2", Date = DateTime.Now, Weight = 4000, Status = ContainerStatus.Departing };

//        //    // ����� �� ������ �������� �� ������ �������
//        //    DataContext.ContainersList.Clear();
//        //    DataContext.ContainersList.Add(container1);

//        //    // ����� ������ �� ������ ������ �� ���� ����
//        //    var controller = new ContainersController();
//        //    var result = controller.Post(container2);

//        //    // ����� ������� ��� BadRequest
//        //    var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
//        //    Assert.Equal("Container with the same ID already exists", badRequestResult.Value);
//        //}


//        // ����� ����� ����� �� �� ����
//        [Fact]
//        public void DeleteContainer_WithValidId_ShouldReturnOk()
//        {
//            // ����� ����� ����
//            var container = new Container { IdNum = 1, ImporterName = "Importer1", SupplierName = "Supplier1", Date = DateTime.Now, Weight = 5000, Status = ContainerStatus.Arriving };

//            // ����� �� ������ �������� �� ������
//            fakeContextServies.ContainersList.Clear();
//            fakeContextServies.ContainersList.Add(container);

//            // ����� ����� �� ������
//            var fakeContext = new FakeContextServies();
//            var controller = new ContainersControllers(fakeContext);
//            var result = controller.Delete(container.IdNum);

//            // ����� ������� ��� Ok
//            var okResult = Assert.IsType<OkResult>(result);
//            Assert.Equal(200, okResult.StatusCode);

//            // ����� ������� ����� �������
//            var deletedContainer = fakeContextServies.ContainersList.FirstOrDefault(c => c.IdNum == container.IdNum);
//            Assert.Null(deletedContainer); // �� ���� ����� ��� ��� �� ���� ��
//        }

//        // ����� ����� ����� �� �����
//        [Fact]
//        public void DeleteContainer_WithInvalidId_ShouldReturnNotFound()
//        {

//            // ����� ����� ����� �� ���� �� ����

//            var fakeContext = new FakeContextServies();
//            var controller = new ContainersControllers(fakeContext);
//            var result = controller.Delete(999); // ���� �� ����

//            // ����� ������� ��� NotFound
//            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
//            Assert.Equal("Id container not found", notFoundResult.Value);
//        }
//    }
//}
