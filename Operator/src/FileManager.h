#ifndef FILEMANAGER_H
#define FILEMANAGER_H

#include <iostream>
#include <vector>
#include <fstream>

#include "Data.h" 


namespace FileManager{
    bool GetUserData(const std::filesystem::path& filepath, const std::string& username, LoginData& data);

    TicketData GetTicketData(const std::string& username);
    std::vector<TicketData> GetAllTickets();

    std::string GetAttributeValue(const std::string& attributeString, char separator = '=');
}
    #endif