#ifndef DATA_H
#define DATA_H

#include <string>
#include <filesystem>

#pragma region Constants
const std::filesystem::path PATH_PREFIX = "..\\..\\Data\\";
const std::filesystem::path ADMIN_ACCOUNTS_FILE_PATH = PATH_PREFIX / "AdminAccounts.txt";
const std::filesystem::path OPERATOR_ACCOUNTS_FILE_PATH = PATH_PREFIX / "OperatorAccounts.txt";
const std::filesystem::path CLIENT_ACCOUNTS_FILE_PATH = PATH_PREFIX / "ClientAccounts.txt";
const std::filesystem::path GLOBAL_DATA_FILE_PATH = PATH_PREFIX / "GlobalData.txt";
const std::filesystem::path TICKETS_FILE_PATH = PATH_PREFIX / "Tickets.txt";
const std::filesystem::path ARCHIVED_TICKETS_FILE_PATH = PATH_PREFIX / "ArchivedTickets.txt";
const std::filesystem::path KEYS_FILE_PATH = PATH_PREFIX / "ActivationKeys.txt";
constexpr int MAX_FREE_OPERATOR_ACCOUNTS = 2;
constexpr int MAX_FREE_ADMIN_ACCOUNTS = 1;
constexpr int TICKET_ATTRIBUTE_COUNT = 6;
#pragma endregion

struct TicketData
{
    std::string clientName;
    std::string title;
    std::string content;
    std::string status;
    std::string assignedOperatorName;
    std::string operatorResponse;

    void display() const noexcept
    {
        std::printf("Ime: %s\nNaslov: %s\nSadrzaj: %s\nStatus: %s\nOperater: %s\nOdgovor: %s\n",
                    clientName.c_str(), title.c_str(), content.c_str(),
                    status.c_str(), assignedOperatorName.c_str(), operatorResponse.c_str());
    }

    void displayShort(int index) const noexcept
    {
        std::printf("ID:%d - [%s] %s\n", index + 1, clientName.c_str(), title.c_str());
    }
};

struct LoginData
{
    std::string username;
    std::string password;
};

#endif