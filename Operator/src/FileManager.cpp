#include "FileManager.h"

bool FileManager::GetUserData(const std::filesystem::path &filename, const std::string &username, LoginData &data)
{
    std::ifstream stream(filename);

    std::string currentLine;
    while (std::getline(stream, currentLine))
    {
        std::string currentUsername = "";
        std::string currentPassword = "";

        bool flag = false;
        for (size_t i = 0; i < currentLine.size(); i++)
        {
            char currentChar = currentLine[i];
            if (currentChar == ':')
            {
                flag = true;
                continue;
            }
            if (!flag)
                currentUsername += currentChar;
            else
                currentPassword += currentChar;
        }

        if (username == currentUsername)
        {
            data.username = currentUsername;
            data.password = currentPassword;
            stream.close();
            return true;
        }
    }

    stream.close();
    std::cout << "Uneseno korisnicko ime nije pronadjeno." << std::endl;
    return false;
}

std::vector<std::string> FileManager::ReadAllLines(const std::filesystem::path &filepath)
{
    std::vector<std::string> ret;
    std::ifstream stream(filepath);

    std::string currentLine;
    while (std::getline(stream, currentLine))
        ret.push_back(currentLine);

    stream.close();
    return ret;
}

void FileManager::WriteAllLines(const std::filesystem::path &filepath, const std::vector<std::string> &lines)
{
    std::ofstream stream(filepath);

    for (const auto &l : lines)
        stream << l << std::endl;

    stream.close();
}

TicketData FileManager::GetActiveTicketData(const std::string &username)
{
    std::ifstream stream(TICKETS_FILE_PATH);

    TicketData data;
    std::vector<std::string> relevantLines;
    relevantLines.resize(TICKET_ATTRIBUTE_COUNT);

    std::string currentLine;
    while (std::getline(stream, currentLine))
    {
        if (GetAttributeValue(currentLine) == username)
        {
            relevantLines[0] = GetAttributeValue(currentLine); // ime
            for (size_t i = 1; i < TICKET_ATTRIBUTE_COUNT; i++)
            {
                std::getline(stream, currentLine);
                relevantLines[i] = GetAttributeValue(currentLine);
            }

            data.clientName = relevantLines[0];
            data.title = relevantLines[1];
            data.content = relevantLines[2];
            data.assignedOperatorName = relevantLines[3];
            data.status = relevantLines[4];
            data.operatorResponse = relevantLines[5];
        }
    }

    stream.close();
    return data;
}

std::vector<TicketData> FileManager::GetAllTickets()
{
    std::vector<TicketData> data;

    std::ifstream stream(TICKETS_FILE_PATH);
    std::string currentLine;

    while (std::getline(stream, currentLine))
    {
        if (GetAttributeName(currentLine, '=') == "CLIENT")
        {
            data.push_back(GetActiveTicketData(GetAttributeValue(currentLine)));
        }
    }

    stream.clear();
    return data;
}

std::vector<TicketData> FileManager::GetAllClosedTickets()
{
    std::vector<TicketData> data;

    std::ifstream stream(ARCHIVED_TICKETS_FILE_PATH);

    std::vector<std::string> relevantStrings;
    relevantStrings.resize(TICKET_ATTRIBUTE_COUNT);
    TicketData currentData;
    std::string currentLine;
    while (std::getline(stream, currentLine))
    {
        if (GetAttributeName(currentLine) == "CLIENT")
        {
            relevantStrings[0] = GetAttributeValue(currentLine);

            for (size_t i = 1; i < TICKET_ATTRIBUTE_COUNT; i++)
            {
                std::getline(stream, currentLine);
                relevantStrings[i] = GetAttributeValue(currentLine);
            }

            currentData.clientName = relevantStrings[0];
            currentData.title = relevantStrings[1];
            currentData.content = relevantStrings[2];
            currentData.assignedOperatorName = relevantStrings[3];
            currentData.status = relevantStrings[4];
            currentData.operatorResponse = relevantStrings[5];

            data.push_back(currentData);
        }
    }

    stream.clear();
    return data;
}

void FileManager::ChangeTicketAttribute(const std::string &clientName,
                                        const std::string &attributeName, const std::string &to)
{

    auto allTickets = GetAllTickets();
    std::vector<std::string> allLines;
    for (const auto &t : allTickets)
    {
        allLines.push_back("CLIENT=" + t.clientName);
        allLines.push_back("TITLE=" + t.title);
        allLines.push_back("CONTENT=" + t.content);
        allLines.push_back("ASSIGNED_OPERATOR=" + t.assignedOperatorName);
        allLines.push_back("STATUS=" + t.status);
        allLines.push_back("OPERATOR_RESPONSE=" + t.operatorResponse);
        allLines.push_back("\n");
    }

    for (size_t i = 0; i < allLines.size(); i++)
    {
        if (allLines[i] == "CLIENT=" + clientName)
        {
            for (size_t j = 0; j < TICKET_ATTRIBUTE_COUNT; j++)
            {
                if (GetAttributeName(allLines[i + j]) == attributeName)
                {
                    allLines[i + j] = attributeName + "=" + to;
                    goto WRITE;
                }
            }
        }
    }

WRITE:
    std::cout << "Writing..." << std::endl;
    WriteAllLines(TICKETS_FILE_PATH, allLines);
}

void FileManager::WriteTicketDataToFile(const TicketData &ticketData, const std::filesystem::path &filepath)
{
    std::ofstream stream(filepath, std::ios_base::app);

    stream << "CLIENT=" << ticketData.clientName << std::endl;
    stream << "TITLE=" << ticketData.title << std::endl;
    stream << "CONTENT=" << ticketData.content << std::endl;
    stream << "ASSIGNED_OPERATOR=" << ticketData.assignedOperatorName << std::endl;
    stream << "STATUS=" << ticketData.status << std::endl;
    stream << "OPERATOR_RESPONSE=" << ticketData.operatorResponse << std::endl
           << std::endl;

    stream.close();
}

void FileManager::DeleteTicket(const TicketData &ticketData)
{
    std::vector<TicketData> allTickets = GetAllTickets();
    std::vector<TicketData> newTickets(allTickets.size());

    auto it = std::copy_if(allTickets.begin(), allTickets.end(), newTickets.begin(), [&ticketData](const TicketData &ticket)
                           { return ticketData.clientName != ticket.clientName; });

    newTickets.resize(allTickets.size() - 1);

    // brisanje starog sadrzaja
    std::ofstream delStream(TICKETS_FILE_PATH, std::ios::trunc);

    // upis novog
    for (const auto &ticket : newTickets)
    {
        WriteTicketDataToFile(ticket);
    }
}

std::vector<std::string> FileManager::GetAllOperators()
{
    std::vector<std::string> ret;

    std::ifstream stream(OPERATOR_ACCOUNTS_FILE_PATH);

    std::string currentLine;
    while (std::getline(stream, currentLine))
        ret.push_back(GetAttributeName(currentLine, ':'));

    stream.close();
    return ret;
}

std::vector<std::string> FileManager::GetAllClients()
{
    std::vector<std::string> ret;

    std::ifstream stream(CLIENT_ACCOUNTS_FILE_PATH);

    std::string currentLine;
    while (std::getline(stream, currentLine))
        ret.push_back(GetAttributeName(currentLine, ':'));

    stream.close();
    return ret;
}

FunctionalStats FileManager::GetFunctionalStats()
{
    FunctionalStats ret;

    ret.numClientAccounts = GetAllClients().size();
    ret.numOperatorAccounts = GetAllOperators().size();
    ret.numAdminAccounts = GetAllOperators().size();

    return ret;
}

DisplayableStats FileManager::GetDisplayableStats()
{
    DisplayableStats ret;

    auto openTickets = GetAllTickets();
    auto closedTickets = GetAllClosedTickets();
    ret.numActiveTickets = openTickets.size();
    ret.numClosedTickets = closedTickets.size();

    // std::map<std::string, int> openTicketsPerOperator;
    // std::map<std::string, int> closedTicketsPerOperator;
    auto allOperators = GetAllOperators();
    for (const auto &o : allOperators)
    {
        ret.openTicketsPerOperator[o] = 0;
        ret.closedTicketsPerOperator[o] = 0;
    }

    for (const auto &ticket : openTickets)
    {
        if (ticket.assignedOperatorName == "")
            continue;

        ret.openTicketsPerOperator[ticket.assignedOperatorName]++;
    }

    for (const auto &ticket : closedTickets)
    {
        if (ticket.assignedOperatorName == "")
            continue;

        ret.closedTicketsPerOperator[ticket.assignedOperatorName]++;
    }

    return ret;
}

bool FileManager::CheckPaidVersion()
{
    std::ifstream stream(GLOBAL_DATA_FILE_PATH);

    std::string currentLine;
    while (std::getline(stream, currentLine))
    {
        if (GetAttributeName(currentLine, '=') == "PAIDVERSION")
            return std::stoi(GetAttributeValue(currentLine, '='));
    }

    stream.close();
    return false;
}

bool FileManager::TryActivatingPaidVersion(const std::string &attemptedKey)
{
    std::ifstream stream(KEYS_FILE_PATH);

    std::string currentLine;
    while (std::getline(stream, currentLine))
    {
        if (currentLine == attemptedKey)
            return true;
    }

    stream.close();
    return false;
}

const std::string FileManager::GetFirmName()
{
    std::ifstream stream(GLOBAL_DATA_FILE_PATH);

    std::string currentLine;
    while (std::getline(stream, currentLine))
    {
        if (GetAttributeName(currentLine) == "FIRMNAME")
            return GetAttributeValue(currentLine);
    }

    return "";
}

std::string FileManager::GetAttributeName(const std::string &attributeString, char separator)
{
    std::string ret = "";

    for (size_t i = 0; i < attributeString.size(); i++)
    {
        char currentChar = attributeString[i];
        if (currentChar == separator)
            break;

        ret += currentChar;
    }

    return ret;
}

std::string FileManager::GetAttributeValue(const std::string &attributeString, char separator)
{
    std::string ret = "";

    bool passedSeparator = false;
    for (size_t i = 0; i < attributeString.size(); i++)
    {
        char currentChar = attributeString[i];

        if (passedSeparator)
        {
            ret += currentChar;
            continue;
        }

        if (currentChar == separator)
            passedSeparator = true;
    }

    return ret;
}

void FileManager::ChangeAttributeName(const std::filesystem::path &filepath,
                                      const std::string &attributeName, const std::string &newName, char separator)
{
    auto lines = ReadAllLines(filepath);

    for (auto &l : lines)
    {
        if (GetAttributeName(l, separator) == attributeName)
        {
            std::string val = GetAttributeValue(l, separator);
            l = newName + separator + val;
            break;
        }
    }

    WriteAllLines(filepath, lines);
}

void FileManager::ChangeAttributeValue(const std::filesystem::path &filepath,
                                       const std::string &attributeName, const std::string &newValue, char separator)
{

    auto lines = ReadAllLines(filepath);

    for (auto &l : lines)
    {
        if (GetAttributeName(l, separator) == attributeName)
        {
            l = attributeName + separator + newValue;
            break;
        }
    }

    WriteAllLines(filepath, lines);
}

void FileManager::DeleteAttributeByName(const std::filesystem::path &filepath,
                                        const std::string &attributeName, char separator)
{

    auto lines = ReadAllLines(filepath);
    std::vector<std::string> modLines;

    for (const auto &l : lines)
    {
        if (GetAttributeName(l, separator) == attributeName)
            continue;
        modLines.push_back(l);
    }

    WriteAllLines(filepath, modLines);
}

void FileManager::AppendToFile(const std::filesystem::path &filepath,
                               const std::string &attributeName, const std::string &attributeValue, char separator)
{

    std::ofstream stream;
    stream.open(filepath, std::ios_base::app); // otvaranje u append rezimu
    stream << attributeName << separator << attributeValue;
    stream.close();
}