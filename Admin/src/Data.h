#ifndef DATA_H
#define DATA_H

#include <string>
#include <filesystem>

#pragma region Constants
const std::filesystem::path ADMIN_ACCOUNTS_FILE_PATH = "..\\..\\Data\\AdminAccounts.txt";
const std::filesystem::path OPERATOR_ACCOUNTS_FILE_PATH = "..\\..\\Data\\OperatorAccounts.txt";
const std::filesystem::path CLIENT_ACCOUNTS_FILE_PATH = "..\\..\\Data\\ClientAccounts.txt";
const std::filesystem::path GLOBAL_DATA_FILE_PATH = "..\\..\\Data\\GlobalData.txt";
const std::filesystem::path TICKETS_FILE_PATH = "..\\..\\Data\\Tickets.txt";
#pragma endregion

struct TicketData {
    std::string clientName;
    std::string title;
    std::string content;
    std::string status;
    std::string assignedOperatorName;
    std::string operatorResponse;

    void display() const noexcept {
        std::printf("Ime: %s\nNaslov: %s\nSadrzaj: %s\nStatus: %s\nOperater: %s\nOdgovor: %s\n",
            clientName.c_str(), title.c_str(), content.c_str(), 
            status.c_str(), assignedOperatorName.c_str(), operatorResponse.c_str());
    }

    void displayShort() const noexcept {
        std::printf("[%s] %s\n", clientName.c_str(), title.c_str());
    }
};

struct LoginData {
    std::string username;
    std::string password;
};

#endif