#ifndef STATS_H
#define STATS_H

#include <iostream>
#include <algorithm>
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

    void display() const noexcept(false) {
        std::cout << "Broj trenutno aktivnih tiketa: " << numActiveTickets << std::endl;
        std::cout << "Broj zatvorenih tiketa: " << numClosedTickets << std::endl;

        std::cout << "Broj tiketa po operateru: " << std::endl << std::endl;
        for (const auto& [key, value] : openTicketsPerOperator){
            std::cout << key << ":" << std::endl;
            std::cout << "  - Otvorenih: " << value << std::endl;
            std::cout << "  - Zatvorenih: " << closedTicketsPerOperator.at(key) << std::endl;
        }
    }

    std::string getLeastOccupiedOperator() {
        auto it = std::min_element(openTicketsPerOperator.begin(), openTicketsPerOperator.end(), 
        [](const auto& L, const auto& R){ return L.second < R.second; });

        std::string min_k = it->first;
        int min_v = it->second;

        return min_k;
    }
};

#endif