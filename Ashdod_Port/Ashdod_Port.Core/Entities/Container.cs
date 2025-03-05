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
        private int id;//מספר זיהוי
        private string importerId; //שם יבואן
        private string supplierId;//שם ספק
        private int weight;//משקל מכולה
        private DateTime date;// תאריך עגינה 
        private ContainerStatus status;// סטטוס מכולה


        public Container() { }
        public Container(string importerId, string supplierId, DateTime date)
        {
            this.id = id++;
            this.importerId = importerId;
            this.supplierId = supplierId;
            this.date = date;
        }

        public int Id { get => id; set => id = value; }
        public string ImporterName { get => importerId; set => importerId = value; }
        public string SupplierName { get => supplierId; set => supplierId = value; }
        public DateTime Date { get => date; set => date = value; }
        public int Weight { get => weight; set => weight = value; }
        public ContainerStatus Status { get => status; set => status = value; }


        //public Importer Importer { get; set; }
        //public Supplier Supplier { get; set; }
        public Importer? Importer { get; set; } // אופציונלי
        public Supplier? Supplier { get; set; } // אופציונלי
    }
}