import React from 'react';
import BezoekersPortaalHeader from '../../BezoekersPortaalHeader';
import { useState, useEffect } from 'react';
import UserService from '../../../services/UserService';
import axios from 'axios';
import Tickets from './Orders';
import Orders from './Orders';

function Page_Tickets() {

    const [orders, setOrders] = useState([]);
    const [transferedTickets, setTransferedTickets] = useState([]);
    const [klantNummerOntvanger, setKlantNummerOntvanger] = useState();
    const [ticketNummer, setTicketNummer] = useState();

    
    useEffect(() => {
        axios.get(`https://localhost:7293/api/Reservation/getReservations/${UserService.getUser().id}`)
            .then(res => {
                setOrders(res.data)
                console.log(res.data)
            })

            axios.get(`https://localhost:7293/api/Ticket/getTransfered?id=${UserService.getUser().id}`)
            .then(res => {setTransferedTickets(res.data);
            console.log(res.data)})


    }, [])

    const ticketOverzetten = () => {

        axios.post("https://localhost:7293/api/ticket/transferticket",
          {
            visitorIdOwner: UserService.getUser().id,
            visitorIdReceiver: klantNummerOntvanger,
            ticketId: ticketNummer,

          }).then(res => console.log(res.data));

      }

    return (

        <>
            <BezoekersPortaalHeader></BezoekersPortaalHeader>
            <h3>Ordergeschiedenis</h3>
            <Orders orders={orders}></Orders>
            <hr></hr>
            <h4>Tickets overzetten naar andere klant</h4>
            <p>Wilt u de tickets overzetten naar een andere klant? Dat kan, u kunt onderstaand formulier invullen per ticket.</p>
            <form className="permissionForm" onSubmit={(e) => e.preventDefault()}>
                        <label id="label">Klantnummer van de ontvanger in cijfers: </label>
                        <input
                            required="Klantnummer is verplicht."
                            type="klantnummerOntvanger"
                            onChange={(e) => setKlantNummerOntvanger(e.target.value)}
                        ></input>
                        <label id="label">Ticketnummer in cijfers: </label>
                        <input
                            required="Ticketnummer is verplicht."
                            type="ticketnummer"
                            onChange={(e) => setTicketNummer(e.target.value)}
                        ></input>
                        <button
                            type="onSubmit"
                            disabled={klantNummerOntvanger && ticketNummer == ""}
                            id="button"
                            onClick={ticketOverzetten}
                        >
                            Zet ticket over
                        </button>
                    </form>

                    <h1>Transfered Ticket</h1>
                    {transferedTickets.map(ticket => {
                        return(
                            <div>
                                <p>Show: {ticket.performance.show.name} </p>
                                <p>Aanvang: {ticket.performance.startTime}</p>
                                <p>Stoel: {ticket.seat.seatNumber}</p>
                                <p>Rij: {ticket.seat.rowNumber}</p>
                            </div>
                        )
                    })}

        </>
    )

}
export default Page_Tickets