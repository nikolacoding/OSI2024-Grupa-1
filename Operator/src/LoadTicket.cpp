#include "LoadTicket.h"
#include "Data.h"

#include <fstream>
#include <sstream>
#include <iostream>

std::vector<TicketData> loadTicketsForOperator(const std::string& operatorName) {
    std::vector<TicketData> tickets;
    std::ifstream file(TICKETS_FILE_PATH);

    if (!file.is_open()) {
        std::cerr << "Greska pri otvaranju fajla." << std::endl;
        return tickets;
    }

    std::string line, key, value;
    TicketData ticket;

    while (std::getline(file, line)) {
        if (line.empty()) continue; 

        std::istringstream ss(line);
        if (std::getline(ss, key, '=') && std::getline(ss, value)) {
           
            if (key == "ASSIGNED_OPERATOR" && value != operatorName) {
               
                ticket = TicketData{}; 
                continue;
            }

            
            if (key == "CLIENT") ticket.clientName = value;
            else if (key == "TITLE") ticket.title = value;
            else if (key == "CONTENT") ticket.content = value;
            else if (key == "ASSIGNED_OPERATOR") ticket.assignedOperatorName = value;
            else if (key == "STATUS") ticket.status = value;
            else if (key == "OPERATOR_RESPONSE") {
                ticket.operatorResponse = value;

                
                tickets.push_back(ticket);

                
                ticket = TicketData{};
            }
        }
    }

    file.close();
    return tickets;
}


void displayMenu(const std::vector<TicketData>& tickets, const std::string& operatorName) {
    std::cout << "Prijavljeni operater - [" << operatorName << "]" << std::endl;

    if (tickets.empty()) {
        std::cout << "Dodijeljeni tiketi:\nNema tiketa dodeljenih ovom operateru." << std::endl;
        return;
    }

    std::cout << "Dodijeljeni tiketi:" << std::endl;
    for (size_t i = 0; i < tickets.size(); ++i) {
        std::cout << "ID:" << i + 1 << " - [" << tickets[i].title << "]" << std::endl;
    }
}
