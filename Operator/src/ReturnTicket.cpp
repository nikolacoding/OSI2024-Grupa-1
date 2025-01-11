#include "ReturnTicket.h"
#include "Data.h"

#include <fstream>
#include <sstream>
#include <iostream>
#include <vector>

bool returnTicket(const std::string& ticketTitle, const std::string& responseMessage) {
    std::ifstream inputFile(TICKETS_FILE_PATH);
    if (!inputFile.is_open()) {
        std::cerr << "Greska pri otvaranju datoteke." << std::endl;
        return false;
    }

    std::vector<std::string> fileLines;
    std::string line, key, value;
    bool ticketFound = false;
    bool inTargetTicket = false;

    while (std::getline(inputFile, line)) {
        fileLines.push_back(line);
        if (line.empty()) {
            inTargetTicket = false; 
            continue;
        }

        std::istringstream ss(line);
        if (std::getline(ss, key, '=') && std::getline(ss, value)) {
            if (key == "TITLE" && value == ticketTitle) {
                inTargetTicket = true;  
                ticketFound = true;
            }

            if (inTargetTicket) {
                if (key == "STATUS") {
                    line = "STATUS=Vracen"; 
                } else if (key == "OPERATOR_RESPONSE") {
                    line = "OPERATOR_RESPONSE=" + responseMessage; 
                }
            }
        }
    }

    inputFile.close();

    if (!ticketFound) {
        std::cerr << "Greska: Tiket sa nazivom \"" << ticketTitle << "\" nije pronadjen." << std::endl;
        return false;
    }

    
    std::ofstream outputFile(TICKETS_FILE_PATH, std::ios::trunc);
    if (!outputFile.is_open()) {
        std::cerr << "Greska kod otvaranja." << std::endl;
        return false;
    }

    for (const auto& savedLine : fileLines) {
        outputFile << savedLine << '\n';
    }

    outputFile.close();
    return true;
}
