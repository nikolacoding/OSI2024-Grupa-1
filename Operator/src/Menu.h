#pragma once
#include <string>
#include <vector>

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
};
