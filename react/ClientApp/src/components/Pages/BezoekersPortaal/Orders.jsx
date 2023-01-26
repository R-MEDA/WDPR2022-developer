import { useEffect } from "react"

const Orders = (props) => {

    const tickets = props.orders.map(order => {
        return (
            <li key={order.id}>

                <br></br>
                <br></br>
                <p>OrderId: {order.id}</p>
                
                <br></br>
                <p>Gereserveerde stoelen</p>
                {order.tickets.map(ticket => {
                    return (
                        <>
                            
                        
                                <p>Show: {ticket.performance.show.name} </p>
                                <p>Prijs: {ticket.price}</p>
                                <p>Rij: {ticket.seat.rowNumber}</p>
                                <p>Stoel: {ticket.seat.seatNumber}</p>
                                

                            
                            <br></br>
                        </>
                    )
                })}

            </li>

        )
    })


    return (
        <>
            <ul>
                {tickets}
            </ul>
        </>
    )
}

export default Orders;