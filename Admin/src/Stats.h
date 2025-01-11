#ifndef STATS_H
#define STATS_H

#include <iostream>
#include <map>

struct FunctionalStats {
    int numClientAccounts;
    int numOperatorAccounts;
    int numAdminAccounts;
};

struct DisplayableStats {
    int numActiveTickets;
    int numClosedTickets;
    std::map<std::string, int> openTicketsPerOperator;
    std::map<std::string, int> closedTicketsPerOperator;

    void display() const noexcept {
        std::cout << "Broj trenutno aktivnih tiketa: " << numActiveTickets << std::endl;
        std::cout << "Broj zatvorenih tiketa: " << numClosedTickets << std::endl;

        std::cout << "Broj tiketa po operateru: " << std::endl << std::endl;
        for (const auto& [key, value] : openTicketsPerOperator){
            std::cout << key << ":" << std::endl;
            std::cout << "  - Otvorenih: " << value << std::endl;
            std::cout << "  - Zatvorenih: " << closedTicketsPerOperator.at(key) << std::endl;
        }
    }
};

#endif