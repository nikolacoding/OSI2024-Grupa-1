#include "Operator.h"
#include "LoadTicket.h"
#include "Menu.h"

int main()
{
    std::cout << "<------Operatorski softver------>" << std::endl;
    std::string username;
    if (login(username))
    {
        std::cout << "Dobrodosli " << username << "!" << std::endl;
        std::vector<TicketData> tickets = loadTicketsForOperator(username);
        Menu meni(username, tickets);
        meni.runMenu();
    }

    else
        std::cout << "Login error" << std::endl;
    return 0;
}
