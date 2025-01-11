#ifndef FILEMANAGER_H
#define FILEMANAGER_H

#include <iostream>
#include <vector>
#include <fstream>

#include "Data.h"
#include "Stats.h"

namespace FileManager{
    bool GetUserData(const std::filesystem::path& filepath, const std::string& username, LoginData& data);

    static std::vector<std::string> ReadAllLines(const std::filesystem::path& filepath);
    static void WriteAllLines(const std::filesystem::path& filepath, const std::vector<std::string>& lines);

    TicketData GetActiveTicketData(const std::string& username);
    std::vector<TicketData> GetAllTickets();
    std::vector<TicketData> GetAllClosedTickets();
    void ChangeTicketAttribute(const std::string& clientName, const std::string& attributeName, const std::string& to);
    void WriteTicketDataToFile(const TicketData& ticketData, const std::filesystem::path& filepath = TICKETS_FILE_PATH);
    void DeleteTicket(const TicketData& ticketData);

    std::vector<std::string> GetAllOperators();
    std::vector<std::string> GetAllClients();

    FunctionalStats GetFunctionalStats();
    DisplayableStats GetDisplayableStats();

    bool CheckPaidVersion();
    bool TryActivatingPaidVersion(const std::string& attemptedKey);
    const std::string GetFirmName();

    std::string GetAttributeName(const std::string& attributeString, char separator = '=');
    std::string GetAttributeValue(const std::string& attributeString, char separator = '=');

    void ChangeAttributeName(const std::filesystem::path& filepath, 
        const std::string& attributeName, const std::string& newName, char separator = '=');

    void ChangeAttributeValue(const std::filesystem::path& filepath, 
        const std::string& attributeName, const std::string& newValue, char separator = '=');

    void DeleteAttributeByName(const std::filesystem::path& filepath,
        const std::string& attributeName, char separator = '=');

    void AppendToFile(const std::filesystem::path& filepath,
        const std::string& attributeName, const std::string& attributeValue, char separator);
}

#endif