#ifndef LOAD_TICKET_H
#define LOAD_TICKET_H

#include "Data.h"
#include <vector>
#include <string>

std::vector<TicketData> loadTicketsForOperator(const std::string& operatorName);

void displayMenu(const std::vector<TicketData>& tickets, const std::string& operatorName);

#endif 
