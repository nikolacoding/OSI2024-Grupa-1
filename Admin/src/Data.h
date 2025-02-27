#ifndef DATA_H
#define DATA_H

#include <string>
#include <filesystem>

#pragma region Paths
const std::filesystem::path PATH_PREFIX = "..\\..\\Data\\";
const std::filesystem::path ADMIN_ACCOUNTS_FILE_PATH = PATH_PREFIX / "AdminAccounts.txt";
const std::filesystem::path OPERATOR_ACCOUNTS_FILE_PATH = PATH_PREFIX / "OperatorAccounts.txt";
const std::filesystem::path CLIENT_ACCOUNTS_FILE_PATH = PATH_PREFIX / "ClientAccounts.txt";
const std::filesystem::path GLOBAL_DATA_FILE_PATH = PATH_PREFIX / "GlobalData.txt";
const std::filesystem::path TICKETS_FILE_PATH = PATH_PREFIX / "Tickets.txt";
const std::filesystem::path ARCHIVED_TICKETS_FILE_PATH = PATH_PREFIX / "ArchivedTickets.txt";
const std::filesystem::path KEYS_FILE_PATH = PATH_PREFIX / "ActivationKeys.txt";
#pragma endregion


#pragma region Constants
constexpr int MAX_FREE_OPERATOR_ACCOUNTS = 2;
constexpr int MAX_FREE_ADMIN_ACCOUNTS = 1;
constexpr int TICKET_ATTRIBUTE_COUNT = 6;
#pragma endregion

struct TicketData {
    std::string clientName;
    std::string title;
    std::string content;
    std::string status;
    std::string assignedOperatorName;
    std::string operatorResponse;

    bool operator==(const TicketData& other){
        return clientName == other.clientName &&
               title == other.title &&
               content == other.content &&
               status == other.status &&
               assignedOperatorName == other.assignedOperatorName &&
               operatorResponse == other.operatorResponse;
    }

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