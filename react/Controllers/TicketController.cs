using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]

public class TicketController : ControllerBase
{
    TheaterDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public TicketController(TheaterDbContext context)
    {
        _context = context;
    }

    // GetTicket    
    [HttpGet]
    public IActionResult GetTicket()
    {
        var ticket = _context.Tickets
        .ToList();
        return Ok(ticket);
    }

    // GetTicketById
    [HttpGet("{id}")]
    public IActionResult GetTicketById(int id)
    {
        var ticket = _context.Tickets
        .FirstOrDefault(t => t.Id == id);
        if (ticket == null)
        {
            return NotFound();
        }
        return Ok(ticket);
    }

    // verander de available van een ticket
    [HttpPut]
    public IActionResult ChangeTicket(int id)
    {
        var ticket = _context.Tickets
        .FirstOrDefault(t => t.Id == id);
        if (ticket == null)
        {
            return NotFound();
        }
        ticket.isAvailable = false;
        _context.SaveChanges();
        return Ok(ticket);
    }

    [HttpPost]
    [Route("createticket")]
    public IActionResult CreateTicket([FromBody] TicketDTO ticketDto)
    {
        Console.WriteLine(ticketDto);
        var performance = _context.Performances.FirstOrDefault(p => p.Id == ticketDto.PerformanceId);
        var seat = _context.Seats.FirstOrDefault(s => s.Id == ticketDto.SeatId);
        //var reservation = _context.Reservations.FirstOrDefault(r => r.Id == ticketDto.ReservationId);


        var ticket = new Ticket
        {
            Id = ticketDto.Id,
            Price = ticketDto.Price,
            Seat = seat,
            Performance = performance,
            //Reservation = reservation,
            isTransfered = false
        };

        _context.Tickets.Add(ticket);
        _context.SaveChanges();

        return Ok(ticket);
    }

    [HttpDelete]
    [Route("deleteticketwithseatid")]
    public IActionResult DeleteTicketWithSeatId(int seatId)
    {
        var seat = _context.Seats.SingleOrDefault(s => s.Id == seatId);
        if (seat == null)
        {
            return NotFound();
        }

        var ticket = _context.Tickets.Where(t => t.Seat.Id == seatId).First();

        if (ticket == null)
        {
            return NotFound();
        }

        _context.Tickets.Remove(ticket);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPost]
    [Route("transferTicket")]
    public IActionResult transferTicket([FromBody] TicketTransferDTO TicketTransferDTO)
    {

        var receiverVisitor = _context.Visitors.Where(v => v.Id == 2).FirstOrDefault();
        var oldTicket = _context.Tickets.Include(t=> t.Seat).
        Include(t=> t.Performance).FirstOrDefault(t => t.Id == TicketTransferDTO.ticketId);
        
        var newTicket = new TransferedTicket(oldTicket, receiverVisitor);
        _context.TransferedTickets.Add(newTicket);
        _context.SaveChanges();
        return Ok();
    }

    [HttpGet]
    [Route("getTransfered")]
    public async Task<ActionResult<List<TransferedTicket>>> getTransfered(int id)
    {
        return await _context.TransferedTickets.Where(t => t.Visitor.Id == id).Include(t => t.Seat).Include(t => t.Performance) .ToListAsync();

    }


    public class TicketDTO
    {
        public int Id { get; set; }
        public int SeatId { get; set; }
        public int PerformanceId { get; set; }
        //public int ReservationId { get; set; }
        public double Price { get; set; }
        public Boolean isTransfered {get;set;}
        
    }

    public class TicketTransferDTO
    {
        
        public int visitorIdReceiver { get; set; }
        public int ticketId { get; set; }
    }
}