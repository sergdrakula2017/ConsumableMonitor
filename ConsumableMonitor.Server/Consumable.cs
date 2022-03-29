namespace ConsumableMonitor.Server
{
    public class Consumable
    {
        public int Id { get; set; }//индификатор
        public string Name { get; set; }//Наименовая картриджа 
        public DateTime dateTime { get; set;}//дата
        public String Status { get; set; }//место положение склад,установлен,списан
        public int numberOfPackages{ get; set; }//колличество упаковок с картриджом
        public int amountInAPackage { get; set; }//кол-во в упаковке 
        public int amountConsumable { get; set; }//общее кол-во картриджей
        public int packagingCost { get; set; }//стоимость ед-цы
        public int sum { get; set; }//общаяя сумма 
    }
}
 