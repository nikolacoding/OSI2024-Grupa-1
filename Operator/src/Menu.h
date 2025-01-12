#pragma once
#include <string>
#include <vector>
#include <fstream>
#include <sstream>

#include "Data.h"
class Menu
{
private:
    std::string operatorName;
    std::vector<TicketData> tickets;

public:
    Menu(const std::string &name, const std::vector<TicketData> &ticketList);
    void displayMenu() const;
    void runMenu();
    void ChangeTicketStatus(int index, std::string status);
    void ChangeOperatorResponse(int index, std::string response);
    void CloseTicket(int index, std::string response);
};
