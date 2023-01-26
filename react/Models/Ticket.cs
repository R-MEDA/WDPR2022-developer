public class Ticket
{
    public Ticket()
    {
        isTransfered = false;
    }
    public int Id { get; set; }
    public bool isAvailable { get; set; }
    public double Price { get; set; }
    public  Seat Seat { get; set; }
    public  Performance Performance { get; set; }
    //public  Reservation Reservation { get; set; }
    public Boolean isTransfered {get; set;}
}

public class TransferedTicket {

    public TransferedTicket()
    {

    }
    public TransferedTicket(Ticket t, Visitor _visitor){

        Id = t.Id;
        Price = t.Price;
        Seat = t.Seat;
        Visitor = _visitor;
        Performance = t.Performance;
    }
    public int Id {get; set;}
    public double? Price {get; set;}
    public Seat? Seat {get; set;}
    public Performance? Performance{get;set;}
    public Visitor? Visitor {get; set;}
}
