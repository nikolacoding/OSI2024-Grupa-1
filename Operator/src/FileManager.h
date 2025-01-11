#ifndef FILEMANAGER_H
#define FILEMANAGER_H

#include <iostream>
#include <vector>
#include <fstream>

#include "Data.h"

namespace FileManager{

    static std::vector<std::string> ReadAllLines(const std::filesystem::path& filepath);
    static void WriteAllLines(const std::filesystem::path& filepath, const std::vector<std::string>& lines);

    TicketData GetTicketData(const std::string& username);
    std::vector<TicketData> GetAllTickets();

    std::vector<std::string> GetAllOperators();
    std::vector<std::string> GetAllClients();

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