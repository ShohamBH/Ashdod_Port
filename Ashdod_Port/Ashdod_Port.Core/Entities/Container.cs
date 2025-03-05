namespace Ashdod_Port.Core.Entities
{
    public enum ContainerStatus
    {
        Arriving,
        Departing,
        Waiting
    }
    public class Container
    {
<<<<<<< HEAD
        private int id;//מספר זיהוי
=======
        private int idNum;//מספר זיהוי
>>>>>>> 4811816a9a0098ff7f3e96c3b56f0b7a7afd2164
        private string importerId; //שם יבואן
        private string supplierId;//שם ספק
        private int weight;//משקל מכולה
        private DateTime date;// תאריך עגינה 
        private ContainerStatus status;// סטטוס מכולה


        public Container() { }
        public Container(string importerId, string supplierId, DateTime date)
        {
<<<<<<< HEAD
            this.id = id++;
=======
            this.IdNum = idNum++;
>>>>>>> 4811816a9a0098ff7f3e96c3b56f0b7a7afd2164
            this.importerId = importerId;
            this.supplierId = supplierId;
            this.date = date;
        }

<<<<<<< HEAD
        public int Id { get => id; set => id = value; }
=======
        public int IdNum { get => idNum; set => idNum = value; }
>>>>>>> 4811816a9a0098ff7f3e96c3b56f0b7a7afd2164
        public string ImporterName { get => importerId; set => importerId = value; }
        public string SupplierName { get => supplierId; set => supplierId = value; }
        public DateTime Date { get => date; set => date = value; }
        public int Weight { get => weight; set => weight = value; }
        public ContainerStatus Status { get => status; set => status = value; }


<<<<<<< HEAD
        //public Importer Importer { get; set; }
        //public Supplier Supplier { get; set; }
        public Importer? Importer { get; set; } // אופציונלי
        public Supplier? Supplier { get; set; } // אופציונלי
=======

>>>>>>> 4811816a9a0098ff7f3e96c3b56f0b7a7afd2164
    }
}