#include "LoadTicket.h"
#include "Operator.h"
#include "Data.h"

#include <fstream>
#include <sstream>
#include <iostream>

std::vector<TicketData> loadTicketsFromFile()
{
    std::vector<TicketData> tickets;
    std::ifstream file(TICKETS_FILE);

    if (!file.is_open())
    {
        std::cerr << "Error: Could not open file " << TICKETS_FILE << std::endl;
        return tickets;
    }

    std::string line, key, value;
    TicketData ticket;

    while (std::getline(file, line))
    {
        if (line.empty())
            continue;

        std::istringstream ss(line);
        if (std::getline(ss, key, '=') && std::getline(ss, value))
        {

            if (key == "CLIENT")
                ticket.clientName = value;
            else if (key == "TITLE")
                ticket.title = value;
            else if (key == "CONTENT")
                ticket.content = value;
            else if (key == "ASSIGNED_OPERATOR")
                ticket.assignedOperatorName = value;
            else if (key == "STATUS")
                ticket.status = value;
            else if (key == "OPERATOR_RESPONSE")
                ticket.operatorResponse = value;
        }

        if (!ticket.clientName.empty() && !ticket.title.empty() && !ticket.content.empty() &&
            !ticket.status.empty())
        {
            tickets.push_back(ticket);
            ticket = TicketData{};
        }
    }

    file.close();
    return tickets;
}

std::vector<TicketData> loadTicketsForOperator(const std::string &operatorName)
{
    std::vector<TicketData> allTickets = loadTicketsFromFile();
    std::vector<TicketData> operatorTickets;

    for (const auto &ticket : allTickets)
    {
        if (ticket.assignedOperatorName == operatorName)
        {
            operatorTickets.push_back(ticket);
        }
    }

    return operatorTickets;
}
